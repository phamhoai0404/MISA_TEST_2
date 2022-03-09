using MISA.Fresher.Web12.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    /// <summary>
    /// Phiếu chi
    /// </summary>
    /// CreatedBy: HoaiPT(08/03/2022)
    public class CaPayment
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid? CaPaymentId { get; set; }


        /// <summary>
        /// Số phiếu chi
        /// </summary>
        [NotEmpty]
        [PropertyName("Số phiếu chi")]
        public string CaPaymentNo { get; set; }

        // <summary>
        /// Id của nhà cung cấp
        /// </summary>
        [Primarykey]
        [PropertyName("Id của nhà cung cấp")]
        public Guid? AccountObjectId { get; set; }

        /// <summary>
        /// Người nhận
        /// </summary>
        [PropertyName("Người nhận")]
        public string? Receiver { get; set; }

        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        [PropertyName("Địa chỉ")]
        public string? Address { get; set; }

        // <summary>
        /// Lý do
        /// </summary>
        [PropertyName("Lý do")]
        public string? Resion { get; set; }

        // <summary>
        /// Mã nhà cung cấp
        /// </summary>
        [Primarykey]
        [PropertyName("Id của nhân viên")]
        public Guid? EmployeeId { get; set; }


        /// <summary>
        /// Ngày phiếu chi
        /// </summary>
        [NotEmpty]
        [PropertyName("Ngày phiếu chi")]
        public DateTime CaPaymentDate { get; set; }

        // <summary>
        /// Ngày hạch toán
        /// </summary>
        [NotEmpty]
        [PropertyName("Ngày hạch toán")]
        public DateTime PostedDate { get; set; }

        // <summary>
        /// Tổng tiền
        /// </summary>
        [PropertyName("Tổng tiền")]
        public float TotalAmount { get; set; }


        /// <summary>
        /// File đính kèm
        /// </summary>
        [PropertyName("File đính kèm")]
        public string? File { get; set; }




        /// <summary>
        /// Ngày tạo 
        /// </summary>
        [PropertyName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        [PropertyName("Người tạo")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        [PropertyName("Ngày cập nhật")]
        public string? ModifiedDate { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        [PropertyName("Người cập nhật")]
        public string? ModifiedBy { get; set; }


        #region NotMap
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        [PropertyName("Mã nhà cung cấp")]
        public string? AccountObjectCode { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        [PropertyName("Tên nhà cung cấp")]
        public string? AccountObjectName { get; set; }
        #endregion


        #endregion

    }
}
