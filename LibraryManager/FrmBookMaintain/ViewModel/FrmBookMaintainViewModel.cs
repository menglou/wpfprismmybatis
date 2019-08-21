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
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FrmBookMaintain.ViewModel
{
    [Export(typeof(FrmBookMaintainViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FrmBookMaintainViewModel : NotificationObject
    {
        public IRegionManager IRegionmanager { get; set; }


        public DelegateCommand<object[]> ViewLoad { get; set; }

        public DelegateCommand<string> RedirctCommand { get; set; }

        public DelegateCommand<object> DataGridAction { get; set; }

        public DelegateCommand ComboxChanged { get; set; }

        public List<TextBlock> txtboxlist = new List<TextBlock>();

        public List<Image> imagelist = new List<Image>();

        public string Imagetobase64 { get; set; }

        #region 属性
        private ObservableCollection<Books> listbook = new ObservableCollection<Books>();

        public ObservableCollection<Books> ListBook
        {
            get { return listbook; }
            set
            {
                listbook = value;
                RaisePropertyChanged("ListBook");
            }
        }

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


        private ObservableCollection<Categories> categorieslist = new ObservableCollection<Categories>();

        public ObservableCollection<Categories> Categorieslist
        {
            get { return categorieslist; }
            set
            {
                categorieslist = value;
                RaisePropertyChanged("Categorieslist");
            }
        }

        private ObservableCollection<Publishers> publisherslist = new ObservableCollection<Publishers>();
        public ObservableCollection<Publishers> Publisherslist
        {
            get { return publisherslist; }
            set
            {
                publisherslist = value;
                RaisePropertyChanged("Publisherslist");
            }
        }

        private Guid? categortid = null;

        public Guid? CategoryId
        {
            get { return categortid; }
            set
            {
                categortid = value;
                RaisePropertyChanged("CategoryId");
            }
        }

        private Guid? publisherid;

        public Guid? Publisherid
        {
            get { return publisherid; }
            set
            {
                publisherid = value;
                RaisePropertyChanged("Publisherid");
            }
        }

        private string bookbarcode;
        public string BookBarcode
        {
            get { return bookbarcode; }
            set
            {
                bookbarcode = value;
                RaisePropertyChanged("BookBarcode");
            }
        }

        private string bookname;
        public string BookName
        {
            get { return bookname; }
            set
            {
                bookname = value;
                RaisePropertyChanged("BookName");
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private string fistpage ;
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
        private string nextpage ;
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
        private string lastpage ;
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
        private string redirttopage ;
        public string Redirttopage
        {
            get { return redirttopage; }
            set
            {
                redirttopage = value;
                RaisePropertyChanged("Redirttopage");
            }
        }

        private string booknames;

        public string BookNames
        {
            get { return booknames; }
            set
            {
                booknames = value;
                RaisePropertyChanged("BookNames");
            }
        }
        private Guid? bookcatatory;
        public Guid? BookCategory
        {
            get { return bookcatatory; }
            set
            {
                bookcatatory = value;
                RaisePropertyChanged("BookCategory");
            }
        }

        private Guid? publisher;
        public Guid? PublisherId
        {
            get { return publisher; }
            set
            {
                publisher = value;
                RaisePropertyChanged("PublisherId");
            }
        }


        private string publishername;
        public string PublisherName
        {
            get { return publishername; }
            set
            {
                publishername = value;
                RaisePropertyChanged("PublisherName");
            }
        }

        private DateTime publishtime;
        public DateTime PublishDate
        {
            get { return publishtime; }
            set
            {
                publishtime = value;
                RaisePropertyChanged("PublishDate");
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                RaisePropertyChanged("Author");
            }
        }

        private string unitprice;
        public string UnitPrice
        {
            get { return unitprice; }
            set
            {
                unitprice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }

        private string barcode;
        public string BarCode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                RaisePropertyChanged("BarCode");
            }
        }
        private string bookcount;
        public string BookCount
        {
            get { return bookcount; }
            set
            {
                bookcount = value;
                RaisePropertyChanged("BookCount");
            }
        }
        private string position;
        public string BookPosition
        {
            get { return position; }
            set
            {
                position = value;
                RaisePropertyChanged("BookPosition");
            }
        }

        private string bookimage;

        public string BookImage
        {
            get { return bookimage; }
            set
            {
                bookimage = value;
                RaisePropertyChanged("BookImage");
            }
        }

        private Guid? bookid = null;
        public Guid? BookId
        {
            get { return bookid; }
            set
            {
                bookid = value;
                RaisePropertyChanged("BookId");
            }
        }


        #endregion

        protected override void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }

        public FrmBookMaintainViewModel()
        {
            IRegionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RedirctCommand = new DelegateCommand<string>(EventAction);
            DataGridAction = new DelegateCommand<object>(ClicDatagrid);
            ViewLoad = new DelegateCommand<object[]>(OnLoad);
            ComboxChanged = new DelegateCommand(Combox_Changed);
        }

        public void Combox_Changed()
        {
            foreach (var item in txtboxlist)
            {
                if (item.Name == "pageindex")
                {
                    item.Text = "1";
                }
            }
        }

        /// <summary>
        /// button按钮的事件动作
        /// </summary>
        /// <param name="param"></param>
        public void EventAction(string param)
        {
            switch (param)
            {
                case "btnsearch":
                    Books book = new Books()
                    {
                        BookCategory = CategoryId,
                        BarCode = BookBarcode,
                        BookName = BookName
                    };
                    SearchBookInfo(book);
                    break;
                case "btndelete":
                    //todo
                    break;
                case "btnclosefrm":
                    IRegionmanager.RequestNavigate("MainRegion", "MainPage");
                    break;
                case "btnselectpic":
                    //todo
                    SelectPic();
                    break;
                case "btnsavemodify":
                    //todo
                    Books books = new Books()
                    {
                        BookName = this.BookNames,
                        BookCategory=this.BookCategory,
                        PublisherId=this.PublisherId,
                        PublishDate=this.PublishDate,
                        Author=this.Author,
                        UnitPrice=Convert.ToDecimal(this.UnitPrice),
                        BookPosition=this.BookPosition,
                        BookImage= Imagetobase64,
                        BookId=this.BookId,
                    };
                    SaveModifyBook(books);
                    break;
            }
        }
        /// <summary>
        /// grid单元行双击查看详情
        /// </summary>
        /// <param name="sender"></param>
        public void ClicDatagrid(object sender)
        {
            DataGrid datagrid = (DataGrid)sender;
            if (datagrid.SelectedItem != null)
            {
                var result = datagrid.SelectedItem as Books;

                Books book = new Books()
                {
                    BookId = result.BookId
                };
           

                List<Books> booklistparam = new List<Books>();
                new BLL.AddBook.AddBookBLL().SelectBookInfobyCondition<Books>(DAL.SQLID.AddBook.AddBook.select_book, book, booklistparam);

                //展示图书图片
                foreach (var item in imagelist)
                {
                    if (item is Image)
                    {
                        if (booklistparam.Count != 0)
                        {
                            item.Source = Picbasetoimage.PicBase64ToImage.GetImageFromBase64(booklistparam[0].BookImage.ToString());
                        }
                    }
                }

                if (booklistparam.Count != 0)
                {
                    this.BookNames = booklistparam[0].BookName;
                    this.BookCategory = booklistparam[0].BookCategory;
                    this.PublisherId = booklistparam[0].PublisherId;
                    this.PublishDate = booklistparam[0].PublishDate;
                    this.Author = booklistparam[0].Author;
                    this.UnitPrice = booklistparam[0].UnitPrice.ToString();
                    this.BarCode = booklistparam[0].BarCode;
                    this.BookPosition = booklistparam[0].BookPosition;
                    this.BookCount = booklistparam[0].BookCount.ToString();
                    this.BookId = booklistparam[0].BookId;
                   // this.BookImage = booklistparam[0].BookImage;
                    Imagetobase64 = booklistparam[0].BookImage;
                }


            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="param"></param>
        public void OnLoad(object[] param)
        {
            categorieslist.Clear();
            publisherslist.Clear();

            imagelist.Clear();
            txtboxlist.Clear();
            if (param.Count() != 0)
            {
                foreach (var item in param)
                {
                    if (item.GetType() == typeof(TextBlock))
                    {
                        TextBlock txtblcok = item as TextBlock;
                        txtboxlist.Add(txtblcok);
                    }
                    if(item.GetType() == typeof(Image))
                    {
                        Image image = item as Image;
                        imagelist.Add(image);
                    }
                }
            }

            //获取所有的
            List<Categories> catlis = new List<Categories>();
            List<Publishers> publist = new List<Publishers>();
            new BLL.AddBook.AddBookBLL().GetAllCategories(DAL.SQLID.AddBook.AddBook.select_allCategories, null, catlis);
            // categorieslist = new ObservableCollection<Categories>();

            new BLL.AddBook.AddBookBLL().GetAllPublishers(DAL.SQLID.AddBook.AddBook.select_allPublishers, null, publist);
            // publisherslist = new ObservableCollection<Publishers>(publist);

            foreach (var item in catlis)
            {
                categorieslist.Add(item);
            }
            foreach (var item in publist)
            {
                publisherslist.Add(item);
            }

        }

        /// <summary>
        /// 查询图书信息
        /// </summary>
        /// <param name="book"></param>
        public void SearchBookInfo(Books book)
        {
            ListBook.Clear();

            Fistpage = "0";//0代表false 1代表true
            Nextpage = "0";
            Previewpage = "0";
            LastPage = "0";
            Redirttopage = "0";


            foreach (var item in txtboxlist)
            {
                if (item.Name == "pagesize")
                {
                    book.PageSize = Convert.ToInt32(item.Text);
                }
                if (item.Name == "pageindex")
                {
                    book.PageIndex = Convert.ToInt32(item.Text);
                }
            }

            List<Books> bookslist = new List<Books>();

            new BLL.BookMaintain.BookMaintainBLL().SearchBookinfoList<Books>(DAL.SQLID.BookMaintain.BookMaintain.selelct_book_bycontation, book, bookslist);


            if (bookslist.Count != 0)
            {
                foreach (var item in bookslist)
                {
                    ListBook.Add(item);
                }
            }

            if (ListBook.Count != 0)
            {
                int Total = ListBook[0].PageCount;

                int PageSize = 0;

                foreach (var item in txtboxlist)
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

                    if(Convert.ToInt32( PageCount)>1)
                    {
                        Fistpage = "1";//0代表false 1代表true
                        Nextpage = "1";
                        Previewpage = "1";
                        LastPage = "1";
                        Redirttopage = "1";
                    }
                    //else
                    //{
                    //    Fistpage = "0";//0代表false 1代表true
                    //    Nextpage = "0";
                    //    Previewpage = "0";
                    //    LastPage = "0";
                    //    Redirttopage = "0";
                    //}
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
                    //else
                    //{
                    //    Fistpage = "0";//0代表false 1代表true
                    //    Nextpage = "0";
                    //    Previewpage = "0";
                    //    LastPage = "0";
                    //    Redirttopage = "0";
                    //}
                }
            }
            else
            {
                PageCount = "0";
                Fistpage = "0";//0代表false 1代表true
                Nextpage = "0";
                Previewpage = "0";
                LastPage = "0";
                Redirttopage = "0";
            }
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        public void SelectPic()
        {
            string filename = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif|所有文件|*.*";

            openFileDialog.Title = "选择图片";

            if (openFileDialog.ShowDialog() == true)
            {

                Imagetobase64 = Picbasetoimage.PicBase64ToImage.GetBase64FromImage(openFileDialog.FileName);

                filename = openFileDialog.FileName;
                BookImage = openFileDialog.FileName;
                if (imagelist.Count != 0)
                {
                    foreach (var item in imagelist)
                    {
                        if (item.Name == "selectiamge")
                        {
                            item.Source = new BitmapImage(new Uri(filename));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="bookparam"></param>
        public void SaveModifyBook(Books bookparam)
        {

            try
            {
                int result = new BLL.BookMaintain.BookMaintainBLL().UpdateBookInfo(DAL.SQLID.BookMaintain.BookMaintain.bookmaintain_update_book, bookparam);

                if(result==1)
                {
                    MessageBox.Show("保存修改成功");
                    
                    //更新datagrid表中的数据
                    foreach (var item in ListBook)
                    {
                        if(item.BookId== bookparam.BookId)
                        {
                            item.BookName = this.BookNames;
                            item.BookCategory = this.BookCategory;
                            item.PublisherId = this.PublisherId;
                            item.PublishDate = this.PublishDate;
                            item.Author = this.Author;
                            item.UnitPrice = Convert.ToDecimal(this.UnitPrice);
                            item.BookPosition = this.BookPosition;
                            item.BookImage = Imagetobase64;
                            item.PublisherName = this.PublisherName;
                        }
                    }
                    this.BookNames = string.Empty;
                    this.BookCategory = null;
                    this.PublisherId = null;
                    this.PublishDate = DateTime.Now;
                    this.Author = string.Empty;
                    this.UnitPrice = string.Empty;
                    this.BookPosition = string.Empty;
                    this.BookNames = string.Empty;
                    this.BookImage = string.Empty;
                    this.BookCount = string.Empty;
                    this.BarCode = string.Empty;
                    this.BookId = null;
                }
                else
                {
                    MessageBox.Show("保存修改失败");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
