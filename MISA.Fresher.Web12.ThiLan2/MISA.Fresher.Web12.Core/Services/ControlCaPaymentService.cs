using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Services
{
    public class ControlCaPaymentService : IControlCaPaymentService
    {
        #region Property
        IControlCaPaymentRepository _controlCaPaymentRepository;
        ICaPaymentRepository _caPaymentRepository;
        ICaPaymentService _caPaymentService;
       
        #endregion


        #region Contructor
        public ControlCaPaymentService(IControlCaPaymentRepository controlCaPaymentRepository, ICaPaymentRepository caPaymentRepository, ICaPaymentService caPaymentService)
        {
            this._controlCaPaymentRepository = controlCaPaymentRepository;
            this._caPaymentRepository = caPaymentRepository;
            this._caPaymentService = caPaymentService;
            
        }
        #endregion
        public int InsertControlService(ControlCaPayment entity)
        {

            //Thực hiện check not null rỗng
            this._caPaymentService.ValidateNotEmpty(entity.CaPayment);

            //Thực hiện check định đạng của code
            this._caPaymentService.ValidateCode(entity.CaPayment.CaPaymentNo);

            //Kiểm tra xem mã đã trùng hay chưa, nếu mà trùng rồi thì dừng chương trình và báo lỗi
            Boolean temp = this._caPaymentRepository.CheckDuplicate_IsUpdate(false, null, "CaPaymentNo", entity.CaPayment.CaPaymentNo);
            if (temp)
            {
                throw new MISAValidateException(
                       String.Format(Core.Resourcs.ResourceVN.InforDuplicate, "Mã"),
                       Core.Resourcs.ErrorCode.Duplicate
                   );
            }

          

           

            return _controlCaPaymentRepository.InsertControlCaPayment(entity);
        }
    }
}
