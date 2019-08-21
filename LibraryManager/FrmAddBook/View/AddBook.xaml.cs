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
using FrmAddBook.ViewModel;

namespace FrmAddBook.View
{
    [Export("FrmAddBook/AddBook")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    /// <summary>
    /// AddBook.xaml 的交互逻辑
    /// </summary>
    public partial class AddBook : UserControl
    {
        public AddBook()
        {
            InitializeComponent();
        }

        [Import]
        public AddBookViewModel addbookviewmodel
        {
            set { this.DataContext = value; }
        }
    }
}
