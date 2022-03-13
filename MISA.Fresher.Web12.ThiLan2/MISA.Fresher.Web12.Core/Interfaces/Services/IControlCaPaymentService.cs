using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Services
{
    public interface IControlCaPaymentService
    {
        /// <summary>
        /// Thực hiện thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int InsertControlService(ControlCaPayment entity);
    }
}
