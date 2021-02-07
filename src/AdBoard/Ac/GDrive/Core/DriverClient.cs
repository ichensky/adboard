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
    public class DriverClient : IDriverClient
    {
        private Queue<GoogleCredential> credentialsForFilesUpload;

        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly DriverServiceFactory driverServiceFactory;

        public DriverClient(DriverServiceFactory driverServiceFactory)
        {
            this.driverServiceFactory = driverServiceFactory;
            this.credentialsForFilesUpload = new Queue<GoogleCredential>(this.driverServiceFactory.Credentials);
        }

        public async Task<string> UploadImage(int fileSizeMB, Stream stream, string name)
        {
            //
            // TODO: think about load balancing, caching 
            //

            await semaphore.WaitAsync();
            try
            {
                using var drive = await driverServiceFactory.CreateDriveServiceWithEnoughSpace(fileSizeMB);
                var id = await drive.UploadImage(stream, name);
                return id;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
