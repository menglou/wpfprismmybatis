using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace LibraryManager
{
    public class QuickStartBootstrapper : MefBootstrapper
    {
        public static string modulepath = System.Configuration.ConfigurationManager.AppSettings["ModulePath"];

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.ComposeExportedValue(this.Container); //这个是必写的
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(this.GetType().Assembly));//加载自身所在的程序集

            DirectoryInfo di = new DirectoryInfo(modulepath);
            DirectoryInfo[] dirs = di.GetDirectories();

            foreach (var item in dirs)
            {

                DirectoryCatalog directoryCatalog = new DirectoryCatalog(item.FullName);

                this.AggregateCatalog.Catalogs.Add(directoryCatalog);

            }

        }

        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }
    }
}
