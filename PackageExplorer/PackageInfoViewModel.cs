using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PackageExplorer
{
    public class PackageInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string packageName;
        private List<PlatformType> platForms;
        private Dictionary<string, int> libCountMap;
        private Dictionary<string, int> buildCountMap;
        private int dependencyCount;

        public string PackageName
        {
            get { return packageName; }
            set
            {
                packageName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PackageName"));
            }
        }

        public List<PlatformType> PlatForms
        {
            get { return platForms; }
            set
            {
                platForms = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlatForms"));
            }
        }

        //public string GetLibCountMap()
        //{

        //}

        //public Dictionary<string,int> SetLibCountMap()
        //{

        //}

        public string ConvertCountMapToString(string countMapName)
        {
            Dictionary<string, int> countMap = new Dictionary<string, int>();
            switch (countMapName)
            {
                case "lib":
                    countMap = libCountMap;
                    break;
                case "build":
                    countMap = buildCountMap;
                    break;
            }

            string resutl = "";
            foreach (string platform in Enum.GetNames(typeof(PlatformType)))
            {
                resutl += string.Format("{0}({1}) ",platform,countMap[platform]);
            }
            return resutl;
        }

        public Dictionary<string, int> LibCountMap
        {
            get { return libCountMap; }
            set
            {
                libCountMap = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LibCountMap"));
            }
        }

        public Dictionary<string, int> BuildCountMap
        {
            get
            {
                return buildCountMap;
            }
            set
            {
                this.buildCountMap = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuildCountMap"));
            }
        }

        public int DependencyCount
        {
            get { return dependencyCount; }
            set
            {
                this.dependencyCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DependencyCount"));
            }
        }

    }
}
