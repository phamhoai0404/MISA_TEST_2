using MISA.Fresher.Web12.Core.Entities;
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


        /// <summary>
        /// Thực hiện cả master và listDetail
        /// </summary>
        /// <param name="id">Mã của CaPayment</param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(11/03/2022)
        public int DeleteByCaPaymentId(Guid id);

        /// <summary>
        /// Thực hiện thêm vào data base caPayment và list caPaymentDetail
        /// </summary>
        /// <param name="entity">Cả entity Control</param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(13/03/2022)
        public int InsertControlCaPayment(ControlCaPayment entity);
    }
}
