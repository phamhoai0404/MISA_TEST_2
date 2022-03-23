using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface IAccountObjectRepository : IBaseRepository<AccountObject>
    {
       /// <summary>
       /// Thực hiện lấy dữ liệu phân trang
       /// </summary>
       /// <param name="pageIndex">Số trang đang đứng</param>
       /// <param name="pageSize">Kích thước trang</param>
       /// <param name="searchText">Từ khóa tìm kiếm</param>
       /// <param name="accountObjectGroupCode">Mã của nhóm khách hàng</param>
       /// <param name="provinceOrCity">Tên thành phố</param>
       /// <param name="district">Tên quận huyện</param>
       /// <param name="wardOrCommune">Tên xã phường</param>
       /// <returns></returns>
       /// CreatedBy: HoaiPT(18/03/2022)
        object GetPagingV2(int pageIndex, int pageSize, string searchText, 
                           string? accountObjectGroupCode, string? provinceOrCity,
                             string? district, string? wardOrCommune);

        /// <summary>
        /// Thực hiện xóa nhiều bản ghi theo list id
        /// </summary>
        /// <param name="listId">Chuỗi id ngăn cách nhau bởi dấu (,)</param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(21/03/2022)
        int DeleteManyId(string listId);

        public IEnumerable<AccountObject> GetExportData(int pageIndex, int pageSize, string searchText,
                           string? accountObjectGroupCode, string? provinceOrCity,
                             string? district, string? wardOrCommune);
    }
}
