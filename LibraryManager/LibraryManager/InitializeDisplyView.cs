using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    [ModuleExport(typeof(InitializeDisplyView))]
    public class InitializeDisplyView:IModule
    {
        public Microsoft.Practices.Prism.Regions.IRegionManager _regionManager;

        [ImportingConstructor]
        public InitializeDisplyView(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RequestNavigate("MainRegion", "MainPage");
        }
    }
}
