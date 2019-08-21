using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Log
{
   public interface IcustomerLog
    {
        void WriteBussLogStart(string message, string metthodname, string modulename);
        void WriteBussLogEndError(string message, string metthodname, string modulename);
        void WriteBussLogEndOK(string message, string metthodname, string modulename);

    }
}
