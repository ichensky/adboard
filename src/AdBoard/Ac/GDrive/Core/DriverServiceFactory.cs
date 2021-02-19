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
        private readonly DriveClientOptions driveClientOptions;

        public IEnumerable<GoogleCredential> Credentials { get => credentials; }

        public DriverServiceFactory(IOptions<GDriveKeysOptions> keys, IOptions<DriveClientOptions> driveClientOptions)
            : this(keys.Value, driveClientOptions.Value) { }

        private DriverServiceFactory(GDriveKeysOptions keys, DriveClientOptions driveClientOptions)
        {
            this.credentials = ValidateKeys(keys);
            this.driveClientOptions = driveClientOptions;
        }

        private IEnumerable<GoogleCredential> ValidateKeys(GDriveKeysOptions keys)
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
                var service = new DriverServiceDecorator(credential, driveClientOptions);

                if (await service.IsEnoughSpaceForFileUpload(fileSizeMB))
                {
                    return service;
                }
            }

            throw new Exception("All keys are used.");
        }
    }
}
