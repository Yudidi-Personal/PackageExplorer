using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PackageExplorer
{
    public class PackageInfo
    {
        private string packageName;
        private List<PlatformInfo> platformList;

        public string PackageName
        {
            get { return packageName; }
        }

    }
}
