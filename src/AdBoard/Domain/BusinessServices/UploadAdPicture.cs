using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BusinessServices
{
    public class UploadAdPicture
    {
        private readonly IDriverClient driverClient;
        private readonly ILogger<UploadAdPicture> logger;

        public UploadAdPicture(IDriverClient driverClient, ILogger<UploadAdPicture> logger)
        {
            this.driverClient = driverClient;
            this.logger = logger;
        }

        public async Task UploadPicture(int fileSizeMB, Stream stream, string name) {

            logger.LogInformation($"Uploading image '{name}' with size '{fileSizeMB}' to google drive");
            
            await driverClient.UploadImage(fileSizeMB, stream, name);
        }
    }
}
