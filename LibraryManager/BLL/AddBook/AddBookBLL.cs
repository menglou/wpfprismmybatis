using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;
using DAL;
using DAL.DBAccess;
using System.Collections;

namespace BLL.AddBook
{
  public  class AddBookBLL
    {
        /// <summary>
        /// 获取所有的书分类
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public void GetAllCategories<T>(string statementname,object parammodel,IList<T> resultObject)
        {
           // MyBatisHelper.QueryForList<Categories>(statementname, parammodel);

              MyBatisHelper.QueryForList(statementname, parammodel, resultObject);
            
        }
        
        /// <summary>
        /// 获取所有的出版社
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public void GetAllPublishers<T>(string statementname, object parammodel, IList<T> resultObject)
        {
            MyBatisHelper.QueryForList<T>(statementname, parammodel, resultObject);
        }

        /// <summary>
        /// 新增图书
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public object AddBook(string statementname, object parammodel)
        {
            return MyBatisHelper.Save(statementname, parammodel);
        }

        public void SelectBookInfobyCondition<T>(string statementname, object parammodel, IList<T> resultObject)
        {
            MyBatisHelper.QueryForList<T>(statementname, parammodel, resultObject);
        }

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public int UpdateBookInfo(string statementname, object parammodel)
        {
           return MyBatisHelper.Update(statementname, parammodel);
        }
    }
}
