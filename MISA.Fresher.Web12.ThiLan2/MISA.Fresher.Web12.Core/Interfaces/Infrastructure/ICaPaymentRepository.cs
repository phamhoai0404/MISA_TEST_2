using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface ICaPaymentRepository : IBaseRepository<CaPayment>
    {
        /// <summary>
        /// Thực hiện lấy ra mã CaPaymentNo mã
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// Created: HoaiPT(14/02/2022)
        string getCaPaymentNoMax();

        /// <summary>
        /// Thực hiện phân trang dữ liệu theo bộ lọc và từ khóa tìm kiếm truyền vào
        /// </summary>
        /// <param name="pageIndex">Chỉ số trang đang đứng</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="searchText">Từ khóa tìm kiếm</param>
        /// <param name="startTime">Từ thời gian</param>
        /// <param name="endTime">Đến thời gian</param>
        /// <returns></returns>
        object GetPagingV2(int pageIndex, int pageSize, string searchText,
                           DateTime? startTime, DateTime? endTime);

    }
}
