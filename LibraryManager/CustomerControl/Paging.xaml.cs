using EntityModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel;
 

namespace CustomerControl
{
    /// <summary>
    /// Paging.xaml 的交互逻辑
    /// </summary>
    public partial class Paging : UserControl
    {
        private BLL.BookMaintain.BookMaintainBLL bookmaintainb = new BLL.BookMaintain.BookMaintainBLL();

        public Paging()
        {
           // this.DataContext = this;
            InitializeComponent();
           
            
        }

        public static string pagesize;
        public static string pagesizes;
        /// <summary>
        /// 每页显示多少
        /// </summary>
        public string PageSize
        {
            get { return (string)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(string), typeof(Paging), new PropertyMetadata(null));



        /// <summary>
        /// 页码
        /// </summary>
        public string PageIndex
        {
            get { return (string)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(string), typeof(Paging), new PropertyMetadata("1"));




        public ObservableCollection<Books> BookList
        {
            get { return (ObservableCollection<Books>)GetValue(BookListProperty); }
            set { SetValue(BookListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BookListProperty =
            DependencyProperty.Register("BookList", typeof(ObservableCollection<Books>), typeof(Paging), new PropertyMetadata(null));




        public ObservableCollection<Readers> ReaderList
        {
            get { return (ObservableCollection<Readers>)GetValue(ReaderListProperty); }
            set { SetValue(ReaderListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReaderList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReaderListProperty =
            DependencyProperty.Register("ReaderList", typeof(ObservableCollection<Readers>), typeof(Paging), new PropertyMetadata(null));



        public string PageCount
        {
            get { return (string)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(string), typeof(Paging), new PropertyMetadata("0"));




        /// <summary>
        /// 首页
        /// </summary>
        public string ButtonFistpage
        {
            get { return (string)GetValue(ButtonFistpageProperty); }
            set { SetValue(ButtonFistpageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonFistpage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonFistpageProperty =
            DependencyProperty.Register("ButtonFistpage", typeof(string), typeof(Paging), new PropertyMetadata(null));

        /// <summary>
        /// 下一页
        /// </summary>
        public string ButtonNexpage
        {
            get { return (string)GetValue(ButtonNexpageProperty); }
            set { SetValue(ButtonNexpageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonFistpage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonNexpageProperty =
            DependencyProperty.Register("ButtonNexpage", typeof(string), typeof(Paging), new PropertyMetadata(null));

        /// <summary>
        /// 上一页
        /// </summary>
        public string ButtonPreviewpage
        {
            get { return (string)GetValue(ButtonPreviewpageProperty); }
            set { SetValue(ButtonPreviewpageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonFistpage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonPreviewpageProperty =
            DependencyProperty.Register("ButtonPreviewpage", typeof(string), typeof(Paging), new PropertyMetadata(null));

        /// <summary>
        /// 最后一页
        /// </summary>
        public string ButtonLastpage
        {
            get { return (string)GetValue(ButtonLastpageProperty); }
            set { SetValue(ButtonLastpageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonFistpage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonLastpageProperty =
            DependencyProperty.Register("ButtonLastpage", typeof(string), typeof(Paging), new PropertyMetadata(null));


        /// <summary>
        /// 跳转至
        /// </summary>
        public string ButtonRedirttopage
        {
            get { return (string)GetValue(ButtonRedirttopageProperty); }
            set { SetValue(ButtonRedirttopageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonFistpage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonRedirttopageProperty =
            DependencyProperty.Register("ButtonRedirttopage", typeof(string), typeof(Paging), new PropertyMetadata(null));



        /// <summary>
        /// 分类id
        /// </summary>
        public Guid? BookCategoryId
        {
            get { return (Guid?)GetValue(BookCategoryIdProperty); }
            set { SetValue(BookCategoryIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BookCategoryId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BookCategoryIdProperty =
            DependencyProperty.Register("BookCategoryId", typeof(Guid?), typeof(Paging), new PropertyMetadata(null));



        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode
        {
            get { return (string)GetValue(BarcodeProperty); }
            set { SetValue(BarcodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Barcode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BarcodeProperty =
            DependencyProperty.Register("Barcode", typeof(string), typeof(Paging), new PropertyMetadata(null));


        /// <summary>
        /// 书名
        /// </summary>
        public string BookName
        {
            get { return (string)GetValue(BookNameProperty); }
            set { SetValue(BookNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BookName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BookNameProperty =
            DependencyProperty.Register("BookName", typeof(string), typeof(Paging), new PropertyMetadata(null));










        private static void PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {

            pagesizes = pagesize;

        }



        public void comboxpagesize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PageSize = ((ComboBoxItem)comboxpagesize.SelectedItem).Content.ToString();
                PageIndex = "1";
                var s = BookList;
                var ss= PageIndex;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfistpage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = "1";

            Books book = new Books()
            {
                BookCategory= BookCategoryId,
                BookName= BookName,
                BarCode= Barcode,
                PageIndex=Convert.ToInt32(PageIndex),
                PageSize=Convert.ToInt32(PageSize)
            };

            List<Books> bookslist = new List<Books>();

            bookmaintainb.SearchBookinfoList<Books>(DAL.SQLID.BookMaintain.BookMaintain.selelct_book_bycontation, book, bookslist);
            BookList.Clear();
            if (bookslist.Count!=0)
            {
                foreach (var item in bookslist)
                {
                    BookList.Add(item);
                }
            }
            //上一页，首页不可用，其他可以用
            ButtonFistpage = "0";
            ButtonNexpage = "1";
            ButtonPreviewpage = "0";
            ButtonLastpage = "1";
            ButtonRedirttopage = "1";

            //btnfistpage.IsEnabled = false;
            //btnnextpage.IsEnabled = true;
            //btnpreviewpage.IsEnabled = false;
            //btnlastpage.IsEnabled = true;
            //btnredirettopage.IsEnabled = true;
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnnextpage_Click(object sender, RoutedEventArgs e)
        {

            PageIndex = (Convert.ToInt32(PageIndex) + 1).ToString();

            int pagecount = Convert.ToInt32(PageCount);

            Books book = new Books()
            {
                BookCategory = BookCategoryId,
                BookName = BookName,
                BarCode = Barcode,
                PageIndex = Convert.ToInt32(PageIndex),
                PageSize = Convert.ToInt32(PageSize)
            };

            List<Books> bookslist = new List<Books>();

            bookmaintainb.SearchBookinfoList<Books>(DAL.SQLID.BookMaintain.BookMaintain.selelct_book_bycontation, book, bookslist);
            BookList.Clear();
            if (bookslist.Count != 0)
            {
                foreach (var item in bookslist)
                {
                    BookList.Add(item);
                }
            }
            if (Convert.ToInt32(PageIndex) >= pagecount)
            {
                //上一页，首页不可用，其他可以用
                ButtonFistpage = "1";
                ButtonNexpage = "0";
                ButtonPreviewpage = "1";
                ButtonLastpage = "0";
                ButtonRedirttopage = "1";

                //btnfistpage.IsEnabled = true;
                //btnnextpage.IsEnabled = false;
                //btnpreviewpage.IsEnabled = true;
                //btnlastpage.IsEnabled = false;
                //btnredirettopage.IsEnabled = true;
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnpreviewpage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = (Convert.ToInt32(PageIndex) - 1).ToString();

            int pagecount =Convert.ToInt32( PageCount);

            Books book = new Books()
            {
                BookCategory = BookCategoryId,
                BookName = BookName,
                BarCode = Barcode,
                PageIndex = Convert.ToInt32(PageIndex),
                PageSize = Convert.ToInt32(PageSize)
            };

            List<Books> bookslist = new List<Books>();

            bookmaintainb.SearchBookinfoList<Books>(DAL.SQLID.BookMaintain.BookMaintain.selelct_book_bycontation, book, bookslist);
            BookList.Clear();
            if (bookslist.Count != 0)
            {
                foreach (var item in bookslist)
                {
                    BookList.Add(item);
                }
            }
            if (Convert.ToInt32(PageIndex) == 1)
            {
                //上一页，首页不可用，其他可以用
                ButtonFistpage = "0";
                ButtonNexpage = "1";
                ButtonPreviewpage = "0";
                ButtonLastpage = "1";
                ButtonRedirttopage = "1";

                //btnfistpage.IsEnabled = false;
                //btnnextpage.IsEnabled = true;
                //btnpreviewpage.IsEnabled = false;
                //btnlastpage.IsEnabled = true;
                //btnredirettopage.IsEnabled = true;
            }

        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnlastpage_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = PageCount;

            Books book = new Books()
            {
                BookCategory = BookCategoryId,
                BookName = BookName,
                BarCode = Barcode,
                PageIndex = Convert.ToInt32(PageIndex),
                PageSize = Convert.ToInt32(PageSize)
            };

            List<Books> bookslist = new List<Books>();

            bookmaintainb.SearchBookinfoList<Books>(DAL.SQLID.BookMaintain.BookMaintain.selelct_book_bycontation, book, bookslist);
            BookList.Clear();
            if (bookslist.Count != 0)
            {
                foreach (var item in bookslist)
                {
                    BookList.Add(item);
                }
            }
            //上一页，首页不可用，其他可以用
            ButtonFistpage = "1";
            ButtonNexpage = "0";
            ButtonPreviewpage = "1";
            ButtonLastpage = "0";
            ButtonRedirttopage = "1";

            //btnfistpage.IsEnabled = true;
            //btnnextpage.IsEnabled = false;
            //btnpreviewpage.IsEnabled = true;
            //btnlastpage.IsEnabled = false;
            //btnredirettopage.IsEnabled = true;
        }
        /// <summary>
        /// 跳转页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnredirettopage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
