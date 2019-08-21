using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using EntityModel;
using System.Windows;
using System.Windows.Controls;
using Interfaces.Log;
using System.Reflection;

namespace FrmMemberManager.ViewModel
{
    [Export(typeof(FrmMemberManagerViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FrmMemberManagerViewModel : NotificationObject
    {
        public IRegionManager IRegionmanager { get; set; }


        public DelegateCommand<object[]> ViewLoad { get; set; }

        public DelegateCommand<string> RedirctCommand { get; set; }

        public DelegateCommand<object> DataGridAction { get; set; }

        public List<TextBlock> txtblocklist = new List<TextBlock>();

        private ObservableCollection<ReaderRoles> readerrols = new ObservableCollection<ReaderRoles>();

        [Import]
        public IcustomerLog IcustomerLog { get; set; }

        public ObservableCollection<ReaderRoles> Readerrols
        {
            get { return readerrols; }
            set
            {
                readerrols = value;
                RaisePropertyChanged("Readerrols");
            }
        }

        private ObservableCollection<Readers> readerslist = new ObservableCollection<Readers>();
        /// <summary>
        /// datagrid的数据源
        /// </summary>
        public ObservableCollection<Readers> Readerslist
        {
            get { return readerslist; }
            set
            {
                readerslist = value;
                RaisePropertyChanged("Readerslist");
            }
        }

        private ObservableCollection<Readers> listreader = new ObservableCollection<Readers>();
        public ObservableCollection<Readers> Listreader
        {
            get { return listreader; }
            set
            {
                listreader = value;
                RaisePropertyChanged("Listreader");
            }
        }

        #region MyRegion
        private Readers readers = new Readers();
        public Readers Readers
        {
            get
            {
                return readers;
            }
            set
            {
                readers = value;
                RaisePropertyChanged("Readers");
            }
        }


        private string readingcard;
        public string ReadingCard
        {
            get { return readingcard; }
            set
            {
                readingcard = value;
                RaisePropertyChanged("ReadingCard");
            }
        }
        private string idcard;
        public string IdCard
        {
            get { return idcard; }
            set
            {
                idcard = value;
                RaisePropertyChanged("IdCard");
            }
        }

        private Guid? roleid;
        public Guid? RoleId
        {
            get { return roleid; }
            set
            {
                roleid = value;
                RaisePropertyChanged("RoleId");
            }
        }

        //男
        private bool gendermale;
        public bool Gendermale
        {
            get { return gendermale; }
            set
            {
                gendermale = value;
                RaisePropertyChanged("Gendermale");
            }
        }

        //女
        private bool genderfelmale;
        public bool GenderFelmale
        {
            get { return genderfelmale; }
            set
            {
                genderfelmale = value;
                RaisePropertyChanged("GenderFelmale");
            }
        }

        /// <summary>
        ///总页数
        /// </summary>
        private string pagecount;
        public string PageCount
        {
            get { return pagecount; }
            set
            {
                pagecount = value;
                RaisePropertyChanged("PageCount");
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private string fistpage;
        public string Fistpage
        {
            get { return fistpage; }
            set
            {
                fistpage = value;
                RaisePropertyChanged("Fistpage");
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private string nextpage;
        public string Nextpage
        {
            get { return nextpage; }
            set
            {
                nextpage = value;
                RaisePropertyChanged("Nextpage");
            }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private string previewpage;
        public string Previewpage
        {
            get { return previewpage; }
            set
            {
                previewpage = value;
                RaisePropertyChanged("Previewpage");
            }
        }

        /// <summary>
        /// 尾页
        /// </summary>
        private string lastpage;
        public string LastPage
        {
            get { return lastpage; }
            set
            {
                lastpage = value;
                RaisePropertyChanged("LastPage");
            }
        }

        /// <summary>
        /// 跳转
        /// </summary>
        private string redirttopage;
        public string Redirttopage
        {
            get { return redirttopage; }
            set
            {
                redirttopage = value;
                RaisePropertyChanged("Redirttopage");
            }
        }

        private string readercount;
        public string ReaderCount
        {
            get { return readercount; }
            set
            {
                readercount = value;
                RaisePropertyChanged("ReaderCount");
            }
        }

        #endregion



        public FrmMemberManagerViewModel()
        {
            IRegionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            ViewLoad = new DelegateCommand<object[]>(OnLoad);
            RedirctCommand = new DelegateCommand<string>(ButtonAction);
            DataGridAction = new DelegateCommand<object>(ClicDatagrid);
        }

        /// <summary>
        /// 按钮的click事件
        /// </summary>
        /// <param name="param"></param>
        public void ButtonAction(string param)
        {
            switch (param)
            {
                case "btnserachbyrole":
                    //todo
                    Readers readers = new Readers()
                    {
                        ReadingCard = this.ReadingCard,
                        RoleId = this.RoleId,
                        IDCard = this.IdCard
                    };
                    SearchReaderlist(readers);
                    break;
                case "btnconfirmadd":
                    //todo
                    Readers reader = new Readers()
                    {
                        ReaderName = this.Readers.ReaderName,
                        ReadingCard = this.Readers.ReadingCard,
                        RoleId = this.Readers.RoleId,
                        PostCode = this.Readers.PostCode,
                        PhoneNumber = this.Readers.PhoneNumber,
                        ReaderAddress = this.Readers.ReaderAddress,
                    };
                    if (Gendermale == true)
                    {
                        reader.Gender = "男";
                    }
                    if (GenderFelmale == true)
                    {
                        reader.Gender = "女";
                    }
                    AddMember(reader);
                    break;
            }
        }

        /// <summary>
        /// grid行双击事件
        /// </summary>
        /// <param name="param"></param>
        public void ClicDatagrid(object sender)
        {
            DataGrid datagrid = (DataGrid)sender;
            if (datagrid.SelectedItem != null)
            {
                var result = datagrid.SelectedItem as Readers;

                Readers readersparam = new Readers()
                {
                    ReaderId=result.ReaderId
                };
                List<Readers> readerlist = new List<Readers>();

                new BLL.MemberManager.MemberManagerBLL().GetReaderByReaderid<Readers>(DAL.SQLID.MemberManager.MemberManager.select_ReadersByReaderid, readersparam, readerlist);

                if(readerlist.Count!=0)
                {
                    foreach (var item in readerlist)
                    {
                        Listreader.Add(item);
                    }
                }

            }
        }

        private void SearchReaderlist(Readers reader)
        {

            IcustomerLog.WriteBussLogStart("开始查询", MethodBase.GetCurrentMethod().ToString(), "FrmMemberManager");


            Readerslist.Clear();

            Fistpage = "0";//0代表false 1代表true
            Nextpage = "0";
            Previewpage = "0";
            LastPage = "0";
            Redirttopage = "0";

            foreach (var item in txtblocklist)
            {
                if (item.Name == "pagesize")
                {
                    reader.PageSize = Convert.ToInt32(item.Text);
                }
                if (item.Name == "pageindex")
                {
                    reader.PageIndex = Convert.ToInt32(item.Text);
                }
            }

            List<Readers> readerlsit = new List<Readers>();

            new BLL.MemberManager.MemberManagerBLL().GetReaderByCondation<Readers>(DAL.SQLID.MemberManager.MemberManager.select_Readers, reader, readerlsit);

            if (readerlsit.Count != 0)
            {
                ReaderCount = readerlsit[0].ReaderCount.ToString();

                foreach (var item in readerlsit)
                {
                    if (item.StatusId == 0)
                    {
                        item.StatusName = "正常";
                    }
                    else if (item.StatusId == 1)
                    {
                        item.StatusName = "禁用";
                    }
                    else
                    {
                        item.StatusName = "注销";
                    }
                    Readerslist.Add(item);
                }

                if (readerlsit.Count != 0)
                {
                    int Total = readerlsit[0].PageCount;

                    int PageSize = 0;

                    foreach (var item in txtblocklist)
                    {
                        if (item.Name == "pagesize")
                        {
                            PageSize = Convert.ToInt32(item.Text);
                        }
                    }

                    int pc = Total / PageSize;

                    if (Total % PageSize == 0)
                    {
                        PageCount = pc.ToString();

                        if (Convert.ToInt32(PageCount) > 1)
                        {
                            Fistpage = "1";//0代表false 1代表true
                            Nextpage = "1";
                            Previewpage = "1";
                            LastPage = "1";
                            Redirttopage = "1";
                        }
                    }
                    else
                    {
                        PageCount = (pc + 1).ToString();

                        if (Convert.ToInt32(PageCount) > 1)
                        {
                            Fistpage = "0";//0代表false 1代表true
                            Nextpage = "1";
                            Previewpage = "0";
                            LastPage = "1";
                            Redirttopage = "1";
                        }
                    }

                }
                else
                {
                    Fistpage = "0";//0代表false 1代表true
                    Nextpage = "0";
                    Previewpage = "0";
                    LastPage = "0";
                    Redirttopage = "0";
                }
            }

        }

        private void AddMember(Readers reader)
        {
            object result = new BLL.MemberManager.MemberManagerBLL().AddReader(DAL.SQLID.MemberManager.MemberManager.insert_Readers, reader);

            if (result != null)
            {
                MessageBox.Show("添加成功");
                Readers = null;
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        public void OnLoad(object[] param)
        {

            if (param.Count() != 0)
            {
                foreach (var item in param)
                {
                    if (item.GetType() == typeof(TextBlock))
                    {
                        TextBlock txtblock = item as TextBlock;
                        txtblocklist.Add(txtblock);
                    }
                }
            }


            List<ReaderRoles> readerroleslist = new List<ReaderRoles>();
            new BLL.MemberManager.MemberManagerBLL().GetAllReaderRoles<ReaderRoles>(DAL.SQLID.MemberManager.MemberManager.select_allReaderRoles, null, readerroleslist);

            if (readerroleslist.Count != 0)
            {
                foreach (var item in readerroleslist)
                {
                    Readerrols.Add(item);
                }
            }

        }
    }
}
