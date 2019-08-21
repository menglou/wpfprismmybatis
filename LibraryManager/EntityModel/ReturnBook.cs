using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// 还书表
    /// </summary>
   public class ReturnBook
    {
        public Guid ReturnId { get; set; }
        /// <summary>
        /// 借书明细id
        /// </summary>
        public Guid BorrowDetailId { get; set; }

        /// <summary>
        /// 还书时间
        /// </summary>
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// 还书时管理员
        /// </summary>
        public string AdminName_R { get; set; }
    }
}
