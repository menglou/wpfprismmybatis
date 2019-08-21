using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;

namespace EntityModel
{
   public class Books:NotificationObject
    {
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

        private Guid? publishid = null;

        public Guid? PublisherId
        {
            get { return publishid; }
            set
            {
                publishid = value;
                RaisePropertyChanged("PublisherId");
            }
        }
        public DateTime PublishDate { get; set; }

        private Guid? bookcategory = null;
        public Guid? BookCategory
        {
            get { return bookcategory; }
            set
            {
                bookcategory = value;
                RaisePropertyChanged("BookCategory");
            }
        }
        private decimal unitprice;
        public decimal UnitPrice
        {
            get { return unitprice; }
            set
            {
                unitprice = value;
                RaisePropertyChanged("UnitPrice");
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
        private int bookcount;
        public int BookCount
        {
            get { return bookcount; }
            set
            {
                bookcount = value;
                RaisePropertyChanged("BookCount");
            }
        }
        private int remainder;
        /// <summary>
        /// 可借总数
        /// </summary>
        public int Remainder
        {
            get { return remainder; }
            set
            {
                remainder = value;
                RaisePropertyChanged("Remainder");
            }
        }
        private string bookposition;
        /// <summary>
        /// 图书位置
        /// </summary>
        public string BookPosition
        {
            get { return bookposition; }
            set
            {
                bookposition = value;
                RaisePropertyChanged("BookPosition");
            }
        }
        private DateTime regtime;
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime RegTime
        {
            get { return regtime; }
            set
            {
                regtime = value;
                RaisePropertyChanged("RegTime");
            }
            
        }

        private string publisername;
        public string PublisherName
        {
            get { return publisername; }
            set
            {
                publisername = value;
                RaisePropertyChanged("PublisherName");
            }
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        protected override void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}
