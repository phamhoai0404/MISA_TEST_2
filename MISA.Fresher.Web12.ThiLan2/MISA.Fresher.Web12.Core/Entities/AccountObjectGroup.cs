using MISA.Fresher.Web12.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    /// <summary>
    /// Nhóm nhà cung cấp
    /// </summary>
    /// CreatedBy: HoaiPT(24/02/2022)
    public class AccountObjectGroup
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid AccountObjectGroupId { get; set; }

        /// <summary>
        /// Mã nhóm nhà cung cấp
        /// </summary>
        [NotEmpty]
        [PropertyName("Mã nhóm nhà cung cấp")]
        public string AccountObjectGroupCode { get; set; }

        /// <summary>
        /// Tên nhóm nhà cung cấp
        /// </summary>
        [NotEmpty]
        [PropertyName("Tên nhóm nhà cung cấp")]
        public string AccountObjectGroupName { get; set; }


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
        #endregion
    }
}
