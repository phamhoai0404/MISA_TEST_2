using MISA.Fresher.Web12.Core.MISAAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Entities
{
    /// <summary>
    /// Nhà cung cấp
    /// </summary>
    /// CreatedBy: HoaiPT(24/02/2022)
    /// UpdatedBy: HoaiPT(25/02/2022)
    public class AccountObject
    {
        #region Property

        /// <summary>
        /// Khóa chính
        /// </summary>
        [Primarykey]
        public Guid? AccountObjectId { get; set; }

        /// <summary>
        /// Mã nhà cung cấp
        /// </summary>
        [NotEmpty]
        [NotDuplicate]
        [PropertyName("Mã nhà cung cấp")]
        public string AccountObjectCode { get; set; }

        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        [NotEmpty]
        [PropertyName("Tên nhà cung cấp")]
        public string? AccountObjectName { get; set; }


        /// <summary>
        /// Mã số thuế
        /// </summary>
        [PropertyName("Mã số thuế")]
        public string? TaxCode { get; set; }


        /// <summary>
        /// Số điện thoại
        /// </summary>
        [PropertyName("Số điện thoại")]
        public string? Phone { get; set; }

        /// <summary>
        /// Tên miền website
        /// </summary>
        [PropertyName("Tên miền website")]
        public string? Website { get; set; }

        /// <summary>
        /// Danh sách nhóm nhà cung cấp
        /// </summary>
        [PropertyName("Danh sách nhóm nhà cung cấp")]
        public string? AccountObjectGroupListId { get; set; }


        /// <summary>
        /// Địa chỉ
        /// </summary>
        [PropertyName("Địa chỉ")]
        public string? Address { get; set; }


        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [PropertyName("Mã nhân viên")]
        [Foreignkey]
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Xưng hô trong liên hệ
        /// </summary>
        [PropertyName("Xưng hô trong liên hệ")]
        public string? Prefix { get; set; }

        /// <summary>
        /// Họ tên người liên hệ
        /// </summary>
        [PropertyName("Họ tên người liên hệ")]
        public string? EinvoiceContactName { get; set; }


        /// <summary>
        /// Số điện thoại người liên hệ
        /// </summary>
        [PropertyName("Số điện thoại người liên hệ")]
        public string? EinvoiceContactMobile { get; set; }


        /// <summary>
        /// Email người liên hệ
        /// </summary>
        [PropertyName("Email người liên hệ")]
        public string? EinvoiceContactEmail { get; set; }

        /// <summary>
        /// Đại diện pháp luật
        /// </summary>
        [PropertyName("Đại diện pháp luật")]
        public string? LegalRepresentative { get; set; }

        /// <summary>
        /// Mã điều khoản
        /// </summary>
        [PropertyName("Mã điều khoản")]
        [Foreignkey]
        public Guid? PaymentTermId { get; set; }

        /// <summary>
        /// Nợ tối đa
        /// </summary>
        [PropertyName("Nợ tối đa")]
        public decimal? MaximizeDebtAmount { get; set; }


        /// <summary>
        /// Số ngày được nợ
        /// </summary>
        [PropertyName("Số ngày được nợ")]
        public int? DueTime { get; set; }


        /// <summary>
        /// Danh sách số tài khoản ngân hàng
        /// </summary>
        [PropertyName("Danh sách số tài khoản ngân hàng")]
        public string? AccountObjectBankAccount { get; set; }


        /// <summary>
        /// Danh sách địa chỉ
        /// </summary>
        [PropertyName("Danh sách địa chỉ")]
        public string? AccountObjectShippingAddress { get; set; }


        /// <summary>
        /// Đất nước
        /// </summary>
        [PropertyName("Đất nước")]
        public string? Country { get; set; }

        /// <summary>
        /// Quận huyện
        /// </summary>
        [PropertyName("Quận huyện")]
        public string? District { get; set; }

        /// <summary>
        /// Phường xã
        /// </summary>
        [PropertyName("Phường xã")]
        public string? WardOrCommune { get; set; }

        /// <summary>
        /// Thành phố
        /// </summary>
        [PropertyName("Thành phố")]
        public string? ProvinceOrCity { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [PropertyName("Ghi chú")]
        public string? Description { get; set; }

        /// <summary>
        /// Mã tài khoản công nợ
        /// </summary>
        [PropertyName("Mã tài khoản công nợ")]
        [Foreignkey]
        public Guid? PayAccountId { get; set; }


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

        #region Notmap
        /// <summary>
        /// Mã tài khoản công nợ
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? PayAccountCode { get; set; }

        /// <summary>
        /// Tên tài khoản công nợ
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? PayAccountName { get; set; }


        /// <summary>
        /// Mã nhân viên
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? FullName { get; set; }

        /// <summary>
        /// Mã điều khoản
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? PaymentTermCode { get; set; }

        /// <summary>
        /// Tên điều khoản
        /// (Propertity bỏ qua khi thực hiện post hay put
        /// (Vì không có trong cơ sử dữ liệu))
        /// </summary>
        [NotMapSQL]
        public string? PaymentTermName { get; set; }

        #endregion
    }
}
