using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageExplorer
{
    public class FileEx
    {
        public static void ExtractFile(string sourceZipFile, string targetFolder)
        {
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);
            else
                Directory.Delete(targetFolder);

            ZipFile.ExtractToDirectory(sourceZipFile, targetFolder);
        }
    }
}
