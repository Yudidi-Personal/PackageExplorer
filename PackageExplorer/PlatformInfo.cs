using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageExplorer
{
    public class PlatformInfo
    {
        private string platForm;
        private List<string> assembliesInLib;
        private List<string> assembliesInBuild;
        private List<string> dependencies;

        public string PlatForm
        {
            get { return platForm; }
            set { platForm = value; }
        }

        public List<string> AssembliesInLib
        {
            get { return assembliesInLib; }
            set { assembliesInLib = value; }
        }

        public List<string> AssembliesInBuild
        {
            get { return assembliesInBuild; }
            set { assembliesInBuild = value; }
        }

        public List<string> Dependencies
        {
            get { return dependencies; }
            set { dependencies = value; }
        }
    }
}
