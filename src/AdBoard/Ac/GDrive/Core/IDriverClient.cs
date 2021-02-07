﻿using System.IO;
using System.Threading.Tasks;

namespace Ac.GDrive.Core
{
    public interface IDriverClient
    {
        Task<string> UploadImage(int fileSizeMB, Stream stream, string name);
    }
}