using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ac.GDrive.Configuration
{
    public class DriveClientOptions
    {
        public int RetryCount { get; set; }

        public int RetryDelayInSeconds { get; set; }
    }
}
