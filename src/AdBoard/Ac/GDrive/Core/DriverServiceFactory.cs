using Ac.GDrive.Configuration;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public class DriverServiceFactory : IDriverServiceFactory
    {
        private readonly IEnumerable<GoogleCredential> credentials;

        public IEnumerable<GoogleCredential> Credentials { get => credentials; }

        public DriverServiceFactory(IOptions<GDriveKeys> keys) : this(keys.Value) { }

        public DriverServiceFactory(GDriveKeys keys)
        {
            this.credentials = ValidateKeys(keys);
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
    
        public async Task<DriverServiceDecorator> CreateDriveServiceWithEnoughSpace(int fileSizeMB)
        {
            if (fileSizeMB < 1)
            {
                throw new ArgumentException(nameof(fileSizeMB));
            }

            foreach (var credential in this.credentials)
            {
                var service = new DriverServiceDecorator(credential);

                if (await service.IsEnoughSpaceForFileUpload(fileSizeMB))
                {
                    return service;
                }
            }

            throw new Exception("All keys are used.");
        }
    }
}
