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
        private GDriveKeys keys;
        private DriverServiceDecorator? service;
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public DriverServiceFactory(IOptions<GDriveKeys> keys) : this(keys.Value) { }

        public DriverServiceFactory(GDriveKeys keys)
        {
            ValidateKeys(keys);
            this.keys = keys;
        }

        private void ValidateKeys(GDriveKeys keys)
        {
            if (keys.Count == 0)
            {
                throw new ArgumentException("Should be at least one key");
            }
            foreach (var key in keys)
            {
                GoogleCredential.FromJson(key);
            }
        }

        public async Task<DriverServiceDecorator> CreateDriveForUploadingFiles(int spaceMB = 500) 
        {
            //
            // TODO: think about load balancing
            //

            if (this.service != null && await this.service.IsEnoughSpaceForFileUpload(spaceMB))
            {
                return service;
            }

            await semaphore.WaitAsync();
            try
            {
                this.service = await FindDriveWithEnoughSpace(spaceMB);
            }
            finally
            {
                semaphore.Release();
            }

            return this.service;
        }

        private async Task<DriverServiceDecorator> FindDriveWithEnoughSpace(int spaceMB)
        {
            foreach (var key in keys)
            {
                var client = GoogleCredential.FromJson(key).CreateScoped(DriveService.Scope.Drive);
                var driveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = client });
                var service = new DriverServiceDecorator(driveService);
                if (await service.IsEnoughSpaceForFileUpload(spaceMB))
                {
                    return service;
                }
            }
                
            throw new Exception("All keys are used.");
        }
    }
}
