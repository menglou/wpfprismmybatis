using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MemberManager
{
   public class MemberManagerBLL
    {
        public void GetAllReaderRoles<T>(string statementname,object parammodel,IList<T>resultclass)
        {
            DAL.DBAccess.MyBatisHelper.QueryForList<T>(statementname, parammodel, resultclass);
        }

        public object AddReader(string statementname,object parammodel)
        {
            return DAL.DBAccess.MyBatisHelper.Save(statementname, parammodel);
        }

        public void GetReaderByCondation<T>(string statementname, object parammodel, IList<T> resultclass)
        {
            DAL.DBAccess.MyBatisHelper.QueryForList<T>(statementname, parammodel, resultclass);
        }

        public void GetReaderByReaderid<T>(string statementname, object parammodel, IList<T> resultclass)
        {
            DAL.DBAccess.MyBatisHelper.QueryForList<T>(statementname, parammodel, resultclass);
        }
    }
}
