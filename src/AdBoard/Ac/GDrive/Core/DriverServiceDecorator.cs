using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public class DriverServiceDecorator
    {
        private readonly DriveService service;

        public DriverServiceDecorator(DriveService service)
        {
            this.service = service;
        }

        public async Task DeleteFile(string id)
        {
            var request = service.Files.Delete(id);
            await request.ExecuteAsync();
        }

        public async Task<string> UploadImage(Stream stream, string name)
        {
            var file = new Google.Apis.Drive.v3.Data.File
            {
                Name = name,
            };
            var request = service.Files.Create(file, stream, "image/jpg");
            request.Fields = "id";

            await request.UploadAsync();

            var id = request.ResponseBody.Id;

            //var downloadUrl = "https://drive.google.com/uc?export=download&id=" + id;
            //var viewUrl = "https://drive.google.com/uc?export=view&id=" + id;
            //var url = "https://drive.google.com/thumbnail?id=" + id + "&sz=w" + 1024;

            return id;
        }

        public async Task<long> AvailableSpaceGoogleDrive()
        {
            var get = service.About.Get();
            get.Fields = "storageQuota";
            var about = await get.ExecuteAsync();
            var sq = about.StorageQuota;
            if (sq.Limit == null || sq.Usage == null)
            {
                throw new Exception("Smth gone wrong");
            }
            return sq.Limit.Value - sq.Usage.Value;
        }

        public async Task<bool> CheckIfFileUploadedToGoogle(string id)
        {
            var listRequest = service.Files.List();
            listRequest.Q = $"appProperties has  {{ key = 'id' and value='{id}' }}";
            var files = await listRequest.ExecuteAsync();

            return files.Files.Count > 0;
        }

        public async Task<bool> IsEnoughSpaceForFileUpload(int spaceMB)
        {
            if (spaceMB < 10)
            {
                throw new ArgumentException("space value should be bigger then 10mb");
            }
            var space = await AvailableSpaceGoogleDrive();
            return space > spaceMB * 1024 * 1024; //100mb
        }

        public async Task AddPermissionsAnyOneReader(string id)
        {
            await service.Permissions.Create(new Permission()
            {
                Kind = "drive#permission",
                Type = "anyone",
                Role = "reader",
            }, id).ExecuteAsync();
        }

        public async Task<IEnumerable<Google.Apis.Drive.v3.Data.File>> ListAllFiles()
        {
            var list = new List<Google.Apis.Drive.v3.Data.File>();
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            listRequest.Fields = "nextPageToken, files(id, name)";

            FileList? fileList = null;

            do
            {
                fileList = await listRequest.ExecuteAsync();
                list.AddRange(fileList.Files);
                listRequest.PageToken = fileList.NextPageToken;
            } while (!string.IsNullOrEmpty(fileList.NextPageToken));

            return list;
        }
    }
}
