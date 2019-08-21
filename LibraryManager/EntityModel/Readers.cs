using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace EntityModel
{
   public class Readers:NotificationObject
    {
        private Guid? readerid;
        public Guid? ReaderId
        {
            get { return readerid; }
            set
            {
                readerid = value;
                RaisePropertyChanged("ReaderId");
            }
        }
        private string readingcard;
        /// <summary>
        /// 借阅证编号
        /// </summary>
        public string ReadingCard
        {
            get { return readingcard; }
            set
            {
                readingcard = value;
                RaisePropertyChanged("ReadingCard");
            }
        }
        private string readername;
        public string ReaderName
        {
            get { return readername; }
            set
            {
                readername = value;
                RaisePropertyChanged("ReaderName");
            }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                RaisePropertyChanged("Gender");
            }
        }
        private string idcard;
        public string IDCard
        {
            get { return idcard; }
            set
            {
                idcard = value;
                RaisePropertyChanged("IDCard");
            }
        }
        private string raderaddress;
        public string ReaderAddress
        {
            get { return raderaddress; }
            set
            {
                raderaddress = value;
                RaisePropertyChanged("ReaderAddress");
            }
        }
        private string postcode;
        public string PostCode
        {
            get { return postcode; }
            set
            {
                postcode = value;
                RaisePropertyChanged("PostCode");
            }
        }
        private string phonenumber;
        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                phonenumber = value;
                RaisePropertyChanged("PhoneNumber");
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
        private string readerimage;
        public string ReaderImage
        {
            get { return readerimage; }
            set
            {
                readerimage = value;
                RaisePropertyChanged("ReaderImage");
            }
        }

        private DateTime regtime;
        public DateTime RegTime
        {
            get { return regtime; }
            set
            {
                regtime = value;
                RaisePropertyChanged("RegTime");
            }
        }

        private string readerpwd;
        public string ReaderPwd
        {
            get { return readerpwd; }
            set
            {
                readerpwd = value;
                RaisePropertyChanged("ReaderPwd");
            }
        }

        private int adminid;
        public int AdminId
        {
            get { return adminid; }
            set
            {
                adminid = value;
                RaisePropertyChanged("AdminId");
            }
        }

        private int statusid;
        public int StatusId
        {
            get { return statusid; }
            set
            {
                statusid = value;
                RaisePropertyChanged("StatusId");
            }
        }
        private string statusname;

        public string StatusName
        {
            get { return statusname; }
            set
            {
                statusname = value;
                RaisePropertyChanged("StatusName");
            }
        }

        private int readercount;
        public int ReaderCount
        {
            get { return readercount; }
            set
            {
                readercount = value;
                RaisePropertyChanged("ReaderCount");
            }
        }

        private string roleName;
        public string RoleName
        {
            get { return roleName; }
            set
            {
                roleName = value;
                RaisePropertyChanged("RoleName");
            }
        }

        public int PageCount { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        protected override void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}
