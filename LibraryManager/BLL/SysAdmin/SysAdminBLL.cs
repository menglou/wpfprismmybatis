using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityModel;

namespace BLL.SysAdmin
{
   public  class SysAdminBLL
    {
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public object Save(string statementname,object parammodel)
        {
            return DAL.DBAccess.MyBatisHelper.Save(statementname, parammodel);
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="statementname"></param>
        /// <param name="parammodel"></param>
        /// <returns></returns>
        public int Update(string statementname, object parammodel)
        {
            return DAL.DBAccess.MyBatisHelper.Update(statementname, parammodel);
        }

        public EntityModel.SysAdmin SelectSysAdminInfo(string statementname, object parammodel)
        {
            return DAL.DBAccess.MyBatisHelper.QueryForObject<EntityModel.SysAdmin>(statementname, parammodel);
        }
    }
}
