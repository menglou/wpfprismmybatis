using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using BLL;
using DAL.SQLID;
using EntityModel;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;

namespace FrmAddBook.ViewModel
{
    [Export(typeof(AddBookViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
   public class AddBookViewModel:NotificationObject
    {
        public IRegionManager IRegionmanager { get; set; }

        public DelegateCommand<object[]> ViewLoad { get; set; }

        public DelegateCommand<string> RedirctCommand { get; set; }

        public DelegateCommand<object> DataGridAction { get; set; }


        public List<Button> buttonlist = new List<Button>();

        public List<TextBox> txtboxist = new List<TextBox>();

        public List<ComboBox> comboxlist = new List<ComboBox>();

        public List<Image> imagelist = new List<Image>();


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



        #region 属性

        private ObservableCollection<Books> booklist=new ObservableCollection<Books>();

        public ObservableCollection<Books> Booklist
        {
            get { return booklist; }
            set
            {
                booklist = value;
                RaisePropertyChanged("Booklist");
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

        private DateTime publishtime=DateTime.Now;
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

        private Guid? bookid=null;
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

        public string Imagetobase64 { get; set; }


        protected override void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }

        public AddBookViewModel()
        {
            IRegionmanager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RedirctCommand = new DelegateCommand<string>(SkipTargetPage);
            ViewLoad = new DelegateCommand<object[]>(OnLoad);
            DataGridAction = new DelegateCommand<object>(ClicDatagrid);
        }

        /// <summary>
        /// 双机grid行
        /// </summary>
        /// <param name="sender"></param>
        public void ClicDatagrid(object sender)
        {
            DataGrid datagrid = (DataGrid)sender;
            if(datagrid.SelectedItem!=null)
            {
                var result = datagrid.SelectedItem as Books;

                Books book = new Books()
                {
                    BookId = result.BookId
                };

                List<Books> booklistparam = new List<Books>();
                new BLL.AddBook.AddBookBLL().SelectBookInfobyCondition<Books>(DAL.SQLID.AddBook.AddBook.select_book, book, booklistparam);

                foreach (var item in imagelist)
                {
                    if (item is Image)
                    {
                        if (booklistparam.Count != 0)
                        {
                            item.Source = PicStream.PicToStream.GetImageFromBase64(booklistparam[0].BookImage.ToString());
                        }
                    }
                }



                if (booklistparam.Count != 0)
                {
                    this.BookName = booklistparam[0].BookName;
                    this.BookCategory = booklistparam[0].BookCategory;
                    this.PublisherId = booklistparam[0].PublisherId;
                    this.PublishDate = booklistparam[0].PublishDate;
                    this.Author = booklistparam[0].Author;
                    this.UnitPrice = booklistparam[0].UnitPrice.ToString();
                    this.BarCode = booklistparam[0].BarCode;
                    this.BookPosition = booklistparam[0].BookPosition;
                    this.BookCount = booklistparam[0].BookCount.ToString();
                    this.BookId = booklistparam[0].BookId;
                    this.BookImage= booklistparam[0].BookImage;
                }
            }
        }

        public void SkipTargetPage(string param)
        {
            switch(param)
            {
                case "btnStartcamera":
                    //todo
                    break;
                case "btnclosecamera":
                    //todo
                    break;
                case "btnstartpic":
                    //todo
                    break;
                case "btnclearpic":
                    //todo
                    foreach (var item in imagelist)
                    {
                        if(item.Name== "selectbookimage")
                        {
                            BookImage = string.Empty;
                        }
                    }
                    break;
                case "btnselectpic":
                    //todo
                    SelectPic();
                    break;
                case "btnconfirmadd":
                    //todo
                    ConfirmAdd();
                    break;
                case "btnclosefrm":
                    //todo
                    IRegionmanager.RequestNavigate("MainRegion", "MainPage");//返回主页
                    break;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="param"></param>
        public void OnLoad(object[] param)
        {
            buttonlist.Clear();
            txtboxist.Clear();
            comboxlist.Clear();
            imagelist.Clear();

            categorieslist.Clear();
            publisherslist.Clear();
            if (param.Count()!=0)
            {
                foreach (var item in param)
                {
                    if(item.GetType()==typeof(Button))
                    {
                        Button btn = item as Button;
                        buttonlist.Add(btn);
                    }
                    else if(item.GetType() == typeof(TextBox))
                    {
                        TextBox textbox = item as TextBox;
                        txtboxist.Add(textbox);
                    }
                    else if(item.GetType() == typeof(ComboBox))
                    {
                        ComboBox combox = item as ComboBox;
                        comboxlist.Add(combox);
                    }
                    else if(item.GetType() == typeof(Image))
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

            //foreach (var item in comboxlist)
            //{
            //    if(item.Name== "combookcatatory")
            //    {
            //        item.ItemsSource = Categorieslist;
            //        item.SelectedValuePath = "CategoryId";
            //        item.DisplayMemberPath = "CategoryName";
            //    }
            //    if(item.Name == "combookpubisher")
            //    {
            //        item.ItemsSource = Publisherslist;
            //        item.SelectedValuePath = "PublisherId";
            //        item.DisplayMemberPath = "PublisherName";
            //    }
            //}



        }

        /// <summary>
        /// 新增和更新
        /// </summary>
        private void ConfirmAdd()
        {
            //根据图书条码查询时候存在此图书
            

            Books book = new Books()
            {
                Author = Author,
                BarCode = BarCode,
                BookCategory = bookcatatory,
                BookCount =Convert.ToInt32(BookCount),
                BookImage = Imagetobase64,
                BookName = BookName,
                BookPosition = BookPosition,
                PublishDate = PublishDate,
                PublisherId = PublisherId,
                PublisherName=PublisherName,
                Remainder =Convert.ToInt32(BookCount),
                UnitPrice =Convert.ToDecimal(UnitPrice),
            };

            Books selelctbook = new Books()
            {
                BookId = this.BookId,
            };

            List<Books> booklists = new List<Books>();
            new BLL.AddBook.AddBookBLL().SelectBookInfobyCondition<Books>(DAL.SQLID.AddBook.AddBook.select_book, selelctbook, booklists);

            if(booklists.Count!=0)
            {
                foreach (var item in booklists)
                {
                    item.Author = Author;
                    item.BookCategory = bookcatatory;
                    item.BookCount = Convert.ToInt32(BookCount);
                    item.BookImage = Imagetobase64;
                    item.BookName = BookName;
                    item.BookPosition = BookPosition;
                    item.PublishDate = PublishDate;
                    item.PublisherId = PublisherId;
                    item.PublisherName = PublisherName;
                    item.Remainder = Convert.ToInt32(BookCount);
                    item.UnitPrice = Convert.ToDecimal(UnitPrice);
                    item.BarCode = BarCode;
                }
                //更新
                int results = new BLL.AddBook.AddBookBLL().UpdateBookInfo(DAL.SQLID.AddBook.AddBook.update_book, booklists[0]);

                if(results!=1)
                {
                    MessageBox.Show("更新失败！");
                }
                else
                {
                    MessageBox.Show("更新图书信息成功！");
                    
                    foreach (var item in Booklist)
                    {
                        if(item.BookId== this.BookId)
                        {
                            item.Author = Author;
                            item.BarCode = BarCode;
                            item.BookCategory = bookcatatory;
                            item.BookCount = Convert.ToInt32(BookCount);
                            item.BookImage = Imagetobase64;
                            item.BookName = BookName;
                            item.BookPosition = BookPosition;
                            item.PublishDate = PublishDate;
                            item.PublisherId = PublisherId;
                            item.PublisherName = PublisherName;
                            item.Remainder = Convert.ToInt32(BookCount);
                            item.UnitPrice = Convert.ToDecimal(UnitPrice);
                        }
                    }
                    //清空所有的信息
                    foreach (var item in txtboxist)
                    {
                        if (item is TextBox)
                        {
                            item.Text = string.Empty;
                        }
                    }
                    foreach (var item in comboxlist)
                    {
                        if (item is ComboBox)
                        {
                            item.SelectedIndex = -1;
                        }
                    }
                    foreach (var item in imagelist)
                    {
                        if (item is Image)
                        {
                            BookImage = string.Empty;
                            GetImage(BookImage);
                        }
                    }
                }
            }
            else
            {
                object result = new BLL.AddBook.AddBookBLL().AddBook(DAL.SQLID.AddBook.AddBook.insert_book, book);

                if (result != null)
                {
                    MessageBox.Show("添加成功！");

                    Guid? guid = new Guid(result.ToString());
                    book.BookId = guid;
                    booklist.Add(book);


                    //清空所有的信息
                    foreach (var item in txtboxist)
                    {
                        if (item is TextBox)
                        {
                            item.Text = string.Empty;
                        }
                    }
                    foreach (var item in comboxlist)
                    {
                        if (item is ComboBox)
                        {
                            item.SelectedIndex = -1;
                        }
                    }
                    foreach (var item in imagelist)
                    {
                        if (item is Image)
                        {
                            BookImage = string.Empty;
                            GetImage(BookImage);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
        }

        public void SelectPic()
        {
            string filename = string.Empty;

            OpenFileDialog OpenFileDialog = new OpenFileDialog();

            OpenFileDialog.Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif|所有文件|*.*";

            OpenFileDialog.Title = "选择图片";

            if( OpenFileDialog.ShowDialog()==true)
            {

                Imagetobase64 = PicStream.PicToStream.GetBase64FromImage(OpenFileDialog.FileName);

                filename = OpenFileDialog.FileName;
                BookImage = OpenFileDialog.FileName;
                //if (imagelist.Count!=0)
                //{
                //    foreach (var item in imagelist)
                //    {
                //        if(item.Name== "selectbookimage")
                //        {
                //            item.Source= new BitmapImage(new Uri(filename));
                //        }
                //    }
                //}
            }

            GetImage(BookImage);//释放资源
        }

        
        /// <summary>
        /// 释放图片
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private static BitmapImage GetImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();

            if (File.Exists(imagePath))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;

                using (Stream ms = new MemoryStream(File.ReadAllBytes(imagePath)))
                {
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }

            return bitmap;
        }

    }
}
