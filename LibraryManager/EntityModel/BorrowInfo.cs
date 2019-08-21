using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// 借书信息
    /// </summary>
   public class BorrowInfo
    {
        /// <summary>
        /// 出借id
        /// </summary>
        public Guid BorrowId { get; set; }

        /// <summary>
        /// 读者id
        /// </summary>
        public Guid ReaderId { get; set; }
        /// <summary>
        /// 借书时间
        /// </summary>
        public DateTime BorrowDate { get; set; }
        /// <summary>
        /// 借书的管理员
        /// </summary>
        public string AdminName_B { get; set; }
    }
}
