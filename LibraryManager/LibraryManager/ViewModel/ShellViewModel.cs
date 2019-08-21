using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;

namespace LibraryManager.ViewModel
{
    [Export(typeof(ShellViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
   public class ShellViewModel
    {
        public IRegionManager IRegionmanager { get; set; }

        public DelegateCommand<string> RedirctCommand  { get; set; }


        public ShellViewModel()
        {
            IRegionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RedirctCommand = new DelegateCommand<string>(SkipTargetPage);
        }


        public void SkipTargetPage(string param)
        {
            switch(param)
            {
                case "addbook":
                    //todo
                    IRegionmanager.RequestNavigate("MainRegion", "FrmAddBook/AddBook");
                    break;
                case "bookshelves":
                    //todo
                    break;
                case "bookmaintain":
                    //todo
                    IRegionmanager.RequestNavigate("MainRegion", "FrmBookMaintain/FrmBookMaintain");
                    break;
                case "membermanager":
                    //todo
                    IRegionmanager.RequestNavigate("MainRegion", "FrmMemberManager/FrmMemberManager");
                    break;
                case "bookborrow":
                    //todo
                    break;
                case "bookreturn":
                    //todo
                    break;
                case "modifypwd":
                    //todo
                    break;
                case "closefrm":
                    //todo
                    break;
            }
        }
    }
}
