using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ac.GDrive.Configuration
{
    public class DriveClientOptions
    {
        [Min(1)]
        public int RetryCount { get; set; }

        [Min(1)]
        public int RetryDelayInSeconds { get; set; }
    }
}
