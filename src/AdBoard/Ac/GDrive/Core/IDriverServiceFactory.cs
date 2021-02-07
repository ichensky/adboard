using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public interface IDriverServiceFactory
    {
        Task<DriverServiceDecorator> CreateDriveForUploadingFile(int spaceMB = 500);
    }
}