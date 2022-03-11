using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Exceptions
{
    public class MISAValidateException: Exception
    {
        string? MsgErrorValiate = null;
        string? CodeError = null;

        public MISAValidateException(string msg, string? codeError)
        {
            this.MsgErrorValiate = msg;
            this.CodeError = codeError;
        }

        public override string Message
        {
            get
            {
                return this.MsgErrorValiate;
            }
        }

        public override string Source
        {
            get
            {
                return this.CodeError;
            }
        }
    }
}
