﻿using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            int codeMax = int.Parse(_accountObjectRepository.GetCodeMax().Substring(3)) ;

            //Mã code mới sinh ra sẽ bằng giá trị lớn nhất hiện tại cộng thêm 1
            var codeNew = codeMax +1 + "";
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
        #endregion
    }
}