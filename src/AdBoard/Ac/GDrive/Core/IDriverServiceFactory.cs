using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public interface IDriverServiceFactory
    {
        Task<DriverServiceDecorator> CreateDriveForUploadingFiles(int spaceMB = 500);
    }
}