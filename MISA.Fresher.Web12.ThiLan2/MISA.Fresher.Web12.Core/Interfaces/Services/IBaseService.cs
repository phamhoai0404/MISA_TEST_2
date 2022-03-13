using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Services
{

    public interface IBaseService<MISAEnity> 
    {

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns></returns>
        /// Created: HoaiPT(27/01/2022)
        /// Update: HoaiPT(07/02/2022)
        int InsertService(MISAEnity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">Cả đối tượng </param>
        /// <param name="entityId">Id của đối tượng cần thực thực hiện sửa dữ liệu</param>
        /// <returns></returns>
        /// Created: HoaiPT(27/01/2022)
        /// Update: HoaiPT(07/02/2022)
        int UpdateService(Guid entityId, MISAEnity entity);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId">Id của đối tượng cần thực hiện xóa</param>
        /// <returns></returns>
        /// Created: HoaiPT(27/01/2022)
        /// Update: HoaiPT(07/02/2022)
        int DeleteService(Guid entityId);

        /// <summary>
        /// Thực hiện lấy dữ liệu và phân trang tìm kiếm
        /// </summary>
        /// <param name="searchText">Nhập vào từ tìm kiếm</param>
        /// <param name="pageSize">Nhập vào kích thước trang</param>
        /// <param name="pageIndex">Nhập vào thứ tự trang</param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(17/02/2022)
        /// UpdateBy: HoaiPT(01/03/2022)
        object GetPagingService(string searchText, int pageSize, int pageIndex);


        /// <summary>
        /// Thực hiện kiểm tra dữ liệu không được để trống 
        /// </summary>
        /// <param name="entity">Cả đối tượng truyền vào</param>
        /// <exception cref="MISAValidateException"></exception>
        /// CreatedBy: HoaiPT(07/02/2022)
        public void ValidateNotEmpty(MISAEnity entity);
    }
}
