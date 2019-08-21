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
using System.Windows.Shapes;
using BLL;
using EntityModel;
using LibraryManager.ViewModel;

namespace LibraryManager
{
    [Export(typeof(Shell))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    /// <summary>
    /// Shell.xaml 的交互逻辑
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }

        [Import]
        public ShellViewModel shellviewmodel
        {
            set { this.DataContext = value; }
        }


        //private void btnaddbook_Click(object sender, RoutedEventArgs e)
        //{
        //    EntityModel.SysAdmin sysadmin = new SysAdmin
        //    {
        //        AdminName="张伟",
        //        LoginPwd="zw123456",
        //        StatuId=0
        //    };

        //    try
        //    {
        //        int result = new BLL.SysAdmin.SysAdminBLL().Save(DAL.SQLID.SysAdmin.SysAdmin.insert_sysadmin, sysadmin);

        //        if(result==0)
        //        {
        //            MessageBox.Show("添加成功");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void btnmodifypwd_Click(object sender, RoutedEventArgs e)
        //{
        //    EntityModel.SysAdmin sysadmin = new SysAdmin
        //    {
        //        LoginPwd = "zw654321",
        //    };
        //    try
        //    {
        //        int result = new BLL.SysAdmin.SysAdminBLL().Update(DAL.SQLID.SysAdmin.SysAdmin.insert_sysadmin, sysadmin);

        //        if (result ==1)
        //        {
        //            MessageBox.Show("修改成功");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void btnclosefrm_Click(object sender, RoutedEventArgs e)
        //{
        //    EntityModel.SysAdmin sysadmin = new SysAdmin
        //    {
        //        AdminId = 1000,
        //    };
        //    try
        //    {
        //         EntityModel.SysAdmin sysadminmodel= new BLL.SysAdmin.SysAdminBLL().SelectSysAdminInfo(DAL.SQLID.SysAdmin.SysAdmin.select_sysadmin, sysadmin);

                
        //    } 
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
