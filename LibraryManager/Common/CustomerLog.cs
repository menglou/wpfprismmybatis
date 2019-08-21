using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Logging;
using System.ComponentModel.Composition;
using Interfaces.Log;

namespace Common
{
    [Export(typeof(IcustomerLog))]
    public class CustomerLog : Interfaces.Log.IcustomerLog
    {
        public void WriteBussLogEndError(string message, string metthodname, string modulename)
        {
            string messages = message + metthodname + modulename;
            LogHelper loghelper = new LogHelper();
            loghelper.Log(messages, Category.Info, Priority.Medium);
        }

        public void WriteBussLogEndOK(string message, string metthodname, string modulename)
        {
            string messages = message + metthodname + modulename;
            LogHelper loghelper = new LogHelper();
            loghelper.Log(messages, Category.Info, Priority.Medium);
        }

        public void WriteBussLogStart(string message, string metthodname, string modulename)
        {
            string messages = message + metthodname + modulename;
            LogHelper loghelper = new LogHelper();
            loghelper.Log(messages, Category.Info, Priority.Medium);
        }
    }
}
