using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Services
{
    public interface ICaPaymentService : IBaseService<CaPayment>
    {

        /// <summary>
        /// Thực hiện lấy ra mã CaPaymentNo mới tự tăng
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(01/03/2022)
        string getCodeNewService();

        /// <summary>
        /// Thực hiện check mã lỗi
        /// </summary>
        /// <param name="code"></param>
        void ValidateCode(string code);

        /// <summary>
        /// Thực hiện phân trang dữ liệu với bộ lọc
        /// </summary>
        /// <param name="searchText">Từ khóa tìm kiếm</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="pageIndex">Trang đang đứng</param>
        /// <param name="objectFilter">Bộ lọc </param>
        /// <returns></returns>
        object GetPagingServiceV2(string searchText, int pageSize, int pageIndex, FilterCaPayment objectFilter);
    }
}
