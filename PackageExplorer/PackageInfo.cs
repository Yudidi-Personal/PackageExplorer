using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PackageExplorer
{
    public class PackageInfo
    {
        private string packageName;
        //private List<PlatformInfo> platformList;

        private PlatformInfo android;

        public PlatformInfo Android
        {
            get { return android; }
            set { android = value; }
        }

        private PlatformInfo iOS;

        public PlatformInfo IOS
        {
            get { return iOS; }
            set { iOS = value; }
        }


        public string PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        }

        public string Platforms
        {
            get
            {
                string r = "";
                foreach (PlatformInfo platform in platformList)
                {
                    r += string.Format("{0},", platform.PlatForm);
                }
                return r;
            }
        }

        public List<PlatformInfo> PlatformList
        {
            get { return platformList; }
            set { platformList = value; }
        }
    }
}
