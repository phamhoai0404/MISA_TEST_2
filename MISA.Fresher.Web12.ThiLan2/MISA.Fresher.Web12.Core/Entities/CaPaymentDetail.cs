using MISA.Fresher.Web12.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    /// <summary>
    /// Chi tiết phiếu chi
    /// </summary>
    /// CreatedBy: HoaiPT(09/03/2022)
    public class CaPaymentDetail
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid? CaPaymentDetailId { get; set; }

        /// <summary>
        /// Id của phiếu chi
        /// </summary>
        [PropertyName("Id của phiếu chi")]
        public Guid? CaPaymentId { get; set; }

        /// <summary>
        /// Diễn giả
        /// </summary>
        [PropertyName("Diễn giả")]
        public string? DecriptionDetail { get; set; }

        /// <summary>
        /// Id tài khoản nợ
        /// </summary>
        [PropertyName("Id tài khoản nợ")]
        public string? DebitAccountId { get; set; }

        /// <summary>
        /// Id tài khoản có
        /// </summary>
        [PropertyName("Id tài khoản có")]
        public string? CreditAccountId { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        [PropertyName("Số tiền")]
        public float? Amount { get; set; }

        /// <summary>
        /// Id nhà cung cấp
        /// </summary>
        [PropertyName("Id nhà cung cấp")]
        public Guid? AccountObjectId { get; set; }

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
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người cập nhật
        /// </summary>
        [PropertyName("Người cập nhật")]
        public string? ModifiedBy { get; set; }

        #region NotMap
        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        [NotMapSQL]
        [PropertyName("Mã nhà cung cấp")]
        public string AccountObjectCode { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        [NotMapSQL]
        [PropertyName("Tên nhà cung cấp")]
        public string? AccountObjectName { get; set; }

        #endregion

        #endregion
    }
}
