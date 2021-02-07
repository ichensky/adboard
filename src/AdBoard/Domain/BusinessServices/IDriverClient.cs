using System.IO;
using System.Threading.Tasks;

namespace Domain.BusinessServices
{
    public interface IDriverClient
    {
        Task<string> UploadImage(int fileSizeMB, Stream stream, string name);
    }
}