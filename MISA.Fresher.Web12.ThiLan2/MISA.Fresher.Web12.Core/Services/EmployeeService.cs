
using Dapper;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.Fresher.Web12.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Property
        IEmployeeRepository _employeeRepository;
        #endregion


        #region Contructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion


        #region Methods

        protected override void ValidateInsertCustomer(Employee employee)
        {
            //2. Ngày sinh không được lớn hơn ngày hiện tại
            this.ValidateDateOfBirth(employee.DateOfBirth);

            //3. Phải có định dạng mẫu employee NV-[]
            this.ValidateEmployeeCode(employee.EmployeeCode);
        }
        protected override void ValidateUpdateCustomer(Guid employeeId, Employee employee)
        {
            //2. Ngày sinh không được lớn hơn ngày hiện tại
            this.ValidateDateOfBirth(employee.DateOfBirth);

            //3. Phải có định dạng mẫu employee NV-[]
            this.ValidateEmployeeCode(employee.EmployeeCode);
        }

        /// <summary>
        /// Thực hiện Validate ngày sinh không được lớn hơn thời gian hiện tại
        /// </summary>
        /// <param name="dateTime">Ngày tháng năm sinh</param>
        /// <exception cref="MISAValidateException"></exception>
        private void ValidateDateOfBirth(DateTime? dateTime)
        {
            if (dateTime > DateTime.Now)
            {
                throw new MISAValidateException(String.Format(Core.Resourcs.ResourceVN.ErrorDateOfBirth));
            }
        }

        /// <summary>
        /// Thực hiện validate Mã phải có định dạng NV-
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(17/02/2022)
        private void ValidateEmployeeCode(string employeeCode)
        {
            string strRegex = @Core.Resourcs.EntitiesVN.EmployeeVN.RegexEmployeeCode;

            Regex regexCode = new Regex(strRegex);
            if (!regexCode.IsMatch(employeeCode))
            {
                throw new MISAValidateException(String.Format(Core.Resourcs.ResourceVN.ErrorFormatCode));
            }
        }

        public int DeleteManyService(List<string> listEmployeeId)
        {
            
            for (int i = 0; i < listEmployeeId.Count; i++)
                {
                    if (listEmployeeId[i].Length != 36)
                    {
                        listEmployeeId.RemoveAt(i);
                        i--;
                    }
                }
            int res = 0;
            if(listEmployeeId.Count > 0)
            {
                 res = _employeeRepository.DeleteManyId(listEmployeeId);
            }
            return res;
           
        }

        public string GetEmployeeCodeNew()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
