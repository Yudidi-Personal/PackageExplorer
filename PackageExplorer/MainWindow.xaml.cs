using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace PackageExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<PackageInfoViewModel> packages;
        private string extractTargetFolder = @"C:\UnZipNuGetPackages";
        private const string NameSpaceOfNuspecFile = "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadPackagesClick(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            //System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
            //txtPackageFolder.Text = folderBrowserDialog.SelectedPath;
            //}
            txtPackageFolder.Text = @"C:\NuGetLocalHosts";

            //ExtractAllNupkgFiles();
            //CollectAllPackagesInfo();
            packages = new List<PackageInfoViewModel>() {
                new PackageInfoViewModel()
                {
                    PackageName ="package name",
                    PlatForms = new List<Platform>()
                    {
                        Platform.WLM
                    },
                    LibCountMap  = new Dictionary<string, int>()
                    {
                        { "WLM",1 }
                    },
                    BuildCountMap  = new Dictionary<string, int>()
                    {
                        { "WLM",2 }
                    },
                    DependencyCount = 3
                }
            };
            Display();
        }

        private void ExtractAllNupkgFiles()
        {
            if (Directory.Exists(extractTargetFolder))
                Directory.Delete(extractTargetFolder, true);

            string[] nupkgFiles = Directory.GetFiles(extractTargetFolder, "*.nupkg", SearchOption.AllDirectories);
            foreach (var nupkg in nupkgFiles)
            {
                FileEx.ExtractFile(nupkg, System.IO.Path.Combine(extractTargetFolder, new FileInfo(nupkg).Name));
            }
        }

        private void CollectAllPackagesInfo()
        {
            string packageName;

            packages = new List<PackageInfoViewModel>();
            string[] nuspecFiles = Directory.GetFiles(extractTargetFolder, "*.nuspec", SearchOption.AllDirectories);
            foreach (var nuspecFile in nuspecFiles)
            {

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(nuspecFile);
                XmlNamespaceManager xmlns = new XmlNamespaceManager(xmldoc.NameTable);
                xmlns.AddNamespace("a", NameSpaceOfNuspecFile);
                XmlNode id = xmldoc.SelectSingleNode("a:package/a:metadata/a:id", xmlns);//ByTag;

                packageName = id.InnerText;
                packages.Add(new PackageInfoViewModel() { PackageName = packageName });

                CollectPackageInfoByStatistics(nuspecFile, packageName);
            }
        }

        private void CollectPackageInfoByStatistics(string nuspecFile, string packageName)
        {
            //platform
            string packageFolder = Directory.GetParent(nuspecFile).FullName;

            var setPlatform = new Action<string>((libOrBuildFolder) =>
            {
                if (!Directory.Exists(libOrBuildFolder))
                    return;

                string[] subFolders = Directory.GetDirectories(libOrBuildFolder, "*.*", SearchOption.TopDirectoryOnly);
                string subFolderName;
                foreach (var subFolder in subFolders)
                {
                    subFolderName = new DirectoryInfo(subFolder).Name;

                    if (subFolderName.Contains("MonoAndroid"))
                    {
                        packages.Last().PlatForms.Add((Platform)Enum.Parse(typeof(Platform), "Android"));
                    }

                    if (subFolderName.Contains("ios"))
                    {
                        packages.Last().PlatForms.Add((Platform)Enum.Parse(typeof(Platform), "Ios"));
                    }

                    if (subFolderName.Contains("net"))
                    {
                        packages.Last().PlatForms.Add((Platform)Enum.Parse(typeof(Platform), "WLM"));
                    }
                }
            });

            if (Directory.Exists(System.IO.Path.Combine(packageFolder, "lib")))
                setPlatform(System.IO.Path.Combine(packageFolder, "lib"));
            else
                setPlatform(System.IO.Path.Combine(packageFolder, "build"));

            //count


        }

        private void SetPlatform(string libOrBuildFolder)
        {

        }

        private void CountAssembly()
        {

        }

        private void Display()
        {
            lvwPackageInfo.ItemsSource = packages;
        }
    }
}
