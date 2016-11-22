using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageExplorer
{
    public class PlatformInfo
    {
        private List<string> libCountMap;
        private List<string> buildCountMap;
        private List<string> dependencyCount;

        public List<string> LibCountMap
        {
            get { return libCountMap; }
        }

        public List<string> BuildCountMap
        {
            get { return buildCountMap; }
        }

        public List<string> DependencyCount
        {
            get { return dependencyCount; }
        }
    }

}
