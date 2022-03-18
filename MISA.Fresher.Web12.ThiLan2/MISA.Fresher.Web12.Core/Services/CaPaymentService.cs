using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public object GetPagingServiceV2(string searchText, int pageSize, int pageIndex, FilterCaPayment objectFilter)
        {
            DateTime startTime = DateTime.MinValue;//Mặc định nó sẽ là nhỏ nhất trong vũ trụ
            DateTime endTime = DateTime.MaxValue;//Mặc định nó sẽ là lớn nhất trong vũ trụ

            if(objectFilter.StartTime != null)//Nếu nó có giá trị thì gán bằng giá trị
            {
                startTime = (DateTime)objectFilter.StartTime;
            }
            if(objectFilter.EndTime != null)//Nếu nó có giá trị thì gán bằng giá trị
            {
                endTime = (DateTime)objectFilter.EndTime;
            }
            return _caPaymentRepository.GetPagingV2(pageIndex, pageSize, searchText, startTime, endTime);
        }


        public string getCodeNewService()
        {
            //Thực hiện lấy ra chỉ là số mà thôi bỏ đi phần chữ và số 0 thừa
            int codeMax = int.Parse(_caPaymentRepository.getCaPaymentNoMax().Substring(2)) + 1;
            //Mã code mới sinh ra sẽ bằng giá trị lớn nhất hiện tại cộng thêm 1
            var codeNew = codeMax + "";
            switch (codeNew.Length)
            {
                case 1:
                    codeNew = "PC0000" + codeNew;
                    break;
                case 2:
                    codeNew = "PC000" + codeNew;
                    break;
                case 3:
                    codeNew = "PC00" + codeNew;
                    break;
                case 4:
                    codeNew = "PC0" + codeNew;
                    break;
                default:
                    codeNew = "PC" + codeNew;
                    break;
            }
            return codeNew;
        }

        public void ValidateCode(string code)
        {
            string strRegex = @Core.Resourcs.EntitiesVN.CaPaymentVN.RegexCaPaymentCode;

            Regex regexCode = new Regex(strRegex);
            if (!regexCode.IsMatch(code))
            {
                throw new MISAValidateException(
                    String.Format(Core.Resourcs.ResourceVN.ErrorFormatCode),
                    Core.Resourcs.ErrorCode.NotFormat
                );
            }
        }
    }
}
