using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    public class ControlCaPayment
    {
        public CaPayment? CaPayment { get; set; }
        public List<CaPaymentDetail>? ListCaPaymentDetail { get; set; }
    }
}
