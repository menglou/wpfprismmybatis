using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FrmBookMaintain.ViewModel;

namespace FrmBookMaintain.View
{
    [Export("FrmBookMaintain/FrmBookMaintain")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    /// <summary>
    /// FrmBookMaintain.xaml 的交互逻辑
    /// </summary>
    public partial class FrmBookMaintain : UserControl
    {
        public FrmBookMaintain()
        {
            InitializeComponent();
        }

        [Import]
        public FrmBookMaintainViewModel frmBookMaintainViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
