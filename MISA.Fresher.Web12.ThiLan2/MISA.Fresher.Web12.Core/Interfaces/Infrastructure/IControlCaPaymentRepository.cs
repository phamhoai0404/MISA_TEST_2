using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface IControlCaPaymentRepository
    {
        /// <summary>
        /// Thực hiện lấy toàn bộ master và list detail
        /// </summary>
        /// <param name="caPaymentId">mã của master</param>
        /// <returns></returns>
        object GetByCaPaymentId(Guid caPaymentId);
    }
}
