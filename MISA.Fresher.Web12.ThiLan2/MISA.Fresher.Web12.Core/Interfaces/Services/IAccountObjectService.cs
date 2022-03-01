using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Services
{
    public interface IAccountObjectService : IBaseService<AccountObject>
    {
        /// <summary>
        /// Thực hiện lấy ra mã code mới tự tăng
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(01/03/2022)
        string getCodeNewService();
    }
}
