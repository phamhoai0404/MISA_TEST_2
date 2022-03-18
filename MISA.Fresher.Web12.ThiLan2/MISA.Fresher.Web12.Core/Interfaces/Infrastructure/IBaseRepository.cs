using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<MISAEnity>
    {
        /// <summary>
        /// Lấy toàn bộ
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISAEnity> GetAll();

        /// <summary>
        /// Lấy thông tin theo mã
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(24/01/2022)
        public MISAEnity GetById(Guid Id);

        /// <summary>
        /// Thực hiện xóa dòng và gây ảnh hưởng đến bao nhiêu dòng theo mã
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(24/01/2022)
        public int Delete(Guid id);

        /// <summary>
        /// Tồn tại id trong bảng
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// true: tồn tại,
        /// false: không tồn tại
        /// </returns>
        /// Created: HoaiPT(18/01/2022)
        public bool ExistId(Guid id);

        /// <summary>
        /// Thực hiện chèn được 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created: HoaiPT(27/01/2022)
        int Insert(MISAEnity entity);

        /// <summary>
        /// Thực hiện sửa gây ảnh hưởng đến bao nhiêu dòng
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// Created: HoaiPT(27/01/2022)
        int Update(Guid entityId, MISAEnity entity);

        /// <summary>
        /// Thực hiện kiểm tra xem có tồn tại hay chưa
        /// </summary>
        /// <param name="isUpate">true: là kiểm tra khi thực hiện update, false: không phải update</param>
        /// <param name="id">cần truyền vào</param>
        /// <returns>
        /// true: tồn tại
        /// false: chưa tồn tại
        /// </returns>
        bool CheckDuplicate_IsUpdate(bool isUpate, Guid? id, string propName, string propValue);

        /// <summary>
        /// Thực hiện lấy dữ liệu export excel theo bảng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: HoaiPT(11/02/2022)
        /// Update: HoaiPT(12/02/2022)
        public IEnumerable<MISAEnity> GetDataExport();

        /// <summary>
        /// Thực hiện phân trang và tìm kiếm lấy dữ liệu
        /// </summary>
        /// <param name="pageIndex">Số thứ tự trang</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="searchText">Từ khóa tìm kiếm</param>
        /// <returns></returns>
        /// Created: HoaiPT(17/02/2022)
        /// UpdateBy: HoaiPT(01/03/2022)
        object GetPaging(int pageIndex, int pageSize, string searchText);




        /// <summary>
        /// Lấy ra mã code lớn nhất có trong entity hiện tại
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(13/02/2022)
        /// UpdatedBy: HoaiPT(01/03/2022)
        string GetCodeMax();
    }
}
