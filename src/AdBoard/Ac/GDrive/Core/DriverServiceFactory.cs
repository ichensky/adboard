using Ac.GDrive.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public class DriverServiceFactory : IDriverServiceFactory
    {
        private IEnumerable<GoogleCredential> credentials;
        private Queue<GoogleCredential> credentialsForFilesUpload;

        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public DriverServiceFactory(IOptions<GDriveKeys> keys) : this(keys.Value) { }

        public DriverServiceFactory(GDriveKeys keys)
        {
            this.credentials = ValidateKeys(keys);
            this.credentialsForFilesUpload = new Queue<GoogleCredential>(this.credentials);
        }

        private IEnumerable<GoogleCredential> ValidateKeys(GDriveKeys keys)
        {
            if (keys.Count == 0)
            {
                throw new ArgumentException("Should be at least one key");
            }
            foreach (var key in keys)
            {
                yield return GoogleCredential.FromJson(key).CreateScoped(DriveService.Scope.Drive);
            }
        }

        public async Task<DriverServiceDecorator> CreateDriveForUploadingFile(int spaceMB = 500)
        {
            //
            // TODO: think about load balancing
            //

            await semaphore.WaitAsync();
            try
            {
                var service = await CreateDriveWithEnoughSpace(spaceMB);
                return service;
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async Task<DriverServiceDecorator> CreateDriveWithEnoughSpace(int spaceMB)
        {
            foreach (var credential in this.credentialsForFilesUpload)
            {
                var service = CreateDrive(credential);
                if (await service.IsEnoughSpaceForFileUpload(spaceMB))
                {
                    return service;
                }
                this.credentialsForFilesUpload.Dequeue();
            }

            throw new Exception("All keys are used.");
        }

        private DriverServiceDecorator CreateDrive(GoogleCredential credential)
        {
            var driveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential });
            var service = new DriverServiceDecorator(driveService);
            return service;
        }
    }
}
