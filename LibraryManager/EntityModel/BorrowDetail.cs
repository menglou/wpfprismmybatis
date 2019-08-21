using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    /// <summary>
    /// 图书借阅详细
    /// </summary>
  public  class BorrowDetail
    {
        /// <summary>
        /// 明细id
        /// </summary>
        public Guid BorrowDetailId { get; set; }

        /// <summary>
        /// 借书id
        /// </summary>
        public Guid BorrowId { get; set; }

        /// <summary>
        /// 图书id
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 借书总数
        /// </summary>
        public int BorrowCount { get; set; }

        /// <summary>
        /// 已还
        /// </summary>
        public int ReturnCount { get; set; }

        /// <summary>
        /// 未还
        /// </summary>
        public int NonReturnCount { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime Expire { get; set; }
    }
}
