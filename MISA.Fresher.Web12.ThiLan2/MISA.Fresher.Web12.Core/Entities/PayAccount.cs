using MISA.Fresher.Web12.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    /// <summary>
    /// Tài khoản công nợ
    /// </summary>
    /// CreatedBy: HoaiPT(24/02/2022)
    public class PayAccount
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid PayAccountId { get; set; }

        /// <summary>
        /// Mã điều khoản
        /// </summary>
        [NotEmpty]
        [PropertyName("Mã tài khoản công nợ")]
        public string PayAccountCode { get; set; }

        /// <summary>
        /// Tên điều khoản
        /// </summary>
        [NotEmpty]
        [PropertyName("Tên tài khoản công nợ")]
        public string PayAccountName { get; set; }


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
        #endregion
    }
}
