using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface ICaPaymentRepository : IBaseRepository<CaPayment>
    {
        /// <summary>
        /// Thực hiện lấy ra mã CaPaymentNo mã
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// Created: HoaiPT(14/02/2022)
        string getCaPaymentNoMax();
    }
}
