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
    public class AccountObjectService : BaseService<AccountObject>, IAccountObjectService
    {
        #region Property
        IAccountObjectRepository _accountObjectRepository;
        #endregion

        #region Contructor
        public AccountObjectService(IAccountObjectRepository accountObjectRepository) : base(accountObjectRepository)
        {
            _accountObjectRepository = accountObjectRepository;
        }

        #endregion

        #region Methods

        public string getCodeNewService()
        {
            //Thực hiện lấy ra chỉ là số mà thôi bỏ đi phần chữ và số 0 thừa
            int codeMax = int.Parse(_accountObjectRepository.GetCodeMax().Substring(3)) + 1  ;

            //Mã code mới sinh ra sẽ bằng giá trị lớn nhất hiện tại cộng thêm 1
            var codeNew = codeMax  + "";
            switch (codeNew.Length)
            {
                case 1:
                    codeNew = "NCC0000" + codeNew;
                    break;
                case 2:
                    codeNew = "NCC000" + codeNew;
                    break;
                case 3:
                    codeNew = "NCC00" + codeNew;
                    break;
                case 4:
                    codeNew = "NCC0" + codeNew;
                    break;
                default:
                    codeNew = "NCC" + codeNew;
                    break;
            }
            return codeNew;

        }

        public object GetPagingServiceV2(string searchText, int pageSize, int pageIndex, FilterAccountObject listText)
        {
            //Duyệt tất cả các property của đối tượng
            var props = typeof(FilterAccountObject).GetProperties();
            string temp = "";
            foreach (var prop in props)
            {
                //Lấy tên của property
                var propName = prop.Name;
                var propValue = prop.GetValue(listText);
                if (propValue != null)
                {
                    temp += temp == "" ? $" vee.{propName} = '{propValue}' " : $" AND vee.{propName}= '{propValue}' ";
                }
            }
            if (temp == "") temp = " 1 = 1 ";
       
            return _accountObjectRepository.GetPagingV2(pageIndex, pageSize, searchText, temp);
        }

        protected override void ValidateInsertCustomer(AccountObject accountObject)
        {
            //Kiểm tra đúng định dạng mã hay không
            this.ValidateAc0countObjectCode(accountObject.AccountObjectCode);
        }
        protected override void ValidateUpdateCustomer(Guid Id, AccountObject accountObject)
        {
            //Kiểm tra đúng định dạng mã hay không
            this.ValidateAc0countObjectCode(accountObject.AccountObjectCode);
        }

        /// <summary>
        /// Thực hiện kiểm tra đúng định dạng mã hay không
        /// </summary>
        /// <param name="accountObjectCode"></param>
        /// <exception cref="MISAValidateException"></exception>
        /// CreatedBy: HoaiPT(03/03/2022)
        private void ValidateAc0countObjectCode(string accountObjectCode)
        {
            string strRegex = @Core.Resourcs.EntitiesVN.AccountObjectVN.RegexAccountObjectCode;

            Regex regexCode = new Regex(strRegex);
            if (!regexCode.IsMatch(accountObjectCode))
            {
                throw new MISAValidateException(
                    String.Format(Core.Resourcs.ResourceVN.ErrorFormatCode),
                    Core.Resourcs.ErrorCode.NotFormat
                );
            }
        }
        #endregion
    }
}
