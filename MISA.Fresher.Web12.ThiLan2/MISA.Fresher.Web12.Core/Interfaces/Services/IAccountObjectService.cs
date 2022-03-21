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

        /// <summary>
        /// Thực hiện lấy dữ liệu và phân trang tìm kiếm
        /// </summary>
        /// <param name="searchText">Nhập vào từ tìm kiếm</param>
        /// <param name="pageSize">Nhập vào kích thước trang</param>
        /// <param name="pageIndex">Nhập vào thứ tự trang</param>
        /// <param name="listText">Chuỗi tìm kiếm truyền vào</param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(10/03/2022)
        object GetPagingServiceV2(string searchText, int pageSize, int pageIndex , FilterAccountObject listText);

        /// <summary>
        /// Thực hiện truyền vào listId để thực hiện xóa
        /// </summary>
        /// <param name="listId">Danh sách các Id</param>
        /// <returns></returns>
        int DeleteManyService(List<string> listId);
    }
}
