using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel;
using DAL;

namespace BLL.BookMaintain
{
   public class BookMaintainBLL
    {
        public void SearchBookinfoList<T>(string statementName, object parameterObject, IList<T> resultObject)
        {
            DAL.DBAccess.MyBatisHelper.QueryForList<T>(statementName, parameterObject, resultObject);
        }

        public int UpdateBookInfo(string statementName, object parameterObject)
        {
          return  DAL.DBAccess.MyBatisHelper.Update(statementName, parameterObject);
        }
    }
}
