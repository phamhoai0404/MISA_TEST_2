using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Services
{
    public class CaPaymentService : BaseService<CaPayment>, ICaPaymentService
    {
        #region Property
        ICaPaymentRepository  _caPaymentRepository;
        #endregion
        public CaPaymentService(ICaPaymentRepository caPaymentRepository) : base(caPaymentRepository)
        {
            _caPaymentRepository = caPaymentRepository;
        }

        public object GetPagingServiceV2(string searchText, int pageSize, int pageIndex, FilterCaPayment listText)
        {
            string k = "1 = 1";//Cái này cần đi hỏi lại các anh
            return _caPaymentRepository.GetPagingV2(pageIndex, pageSize, searchText, k);
        }
    }
}
