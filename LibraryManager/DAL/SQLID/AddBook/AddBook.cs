using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQLID.AddBook
{
   public class AddBook
    {
        /// <summary>
        /// 获取所有的书分类id
        /// </summary>
        public const string select_allCategories = "select_allCategories";
        /// <summary>
        /// 获取所有的出版社id
        /// </summary>
        public const string select_allPublishers = "select_allPublishers";
        /// <summary>
        /// 添加图书
        /// </summary>
        public const string insert_book = "insert_book";
        /// <summary>
        /// 查询图书信息 根据条件
        /// </summary>
        public const string select_book = "select_book";
        /// <summary>
        /// 更新图书信息
        /// </summary>
        public const string update_book = "update_book";
    }
}
