using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class ReaderRoles
    {
        public Guid? RoleId { get; set; }
        public string RoleName { get; set; }
        public int AllowDays { get; set; }
        public int AllowCounts { get; set; }
    }
}
