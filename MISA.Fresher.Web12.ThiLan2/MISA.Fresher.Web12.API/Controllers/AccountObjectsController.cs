using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountObjectsController : MISABaseController<AccountObject>
    {
        #region Fields
        IAccountObjectService _accountObjectService;
        IAccountObjectRepository _accountObjectRepository;
        #endregion

        #region Contructor
        public AccountObjectsController(IAccountObjectRepository accountObjectRepository, IAccountObjectService accountObjectService) : base(accountObjectRepository, accountObjectService)
        {
            this._accountObjectRepository = accountObjectRepository;
            this._accountObjectService = accountObjectService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy ra mã thêm mới tiếp theo
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(11/02/2022)
        [HttpGet("CodeNew")]
        public IActionResult GetCodeNew()
        {
            try
            {
                var res = _accountObjectService.getCodeNewService();
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return this.AllException(ex, null);
            }

        }



        /// <summary>
        /// Thực hiện xuất ra file excel danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(14/02/2022)
        [HttpGet("Excel")]
        public IActionResult exportExcel()
        {
            //Thực hiện tạo ra file excel mới và sau khi làm xong  đóng lại luôn
            using (var workbook = new XLWorkbook())
            {
                //Tạo ra sheet mới trong file excel có tên là DANH SÁCH NHÂN VIÊN
                var worksheet = workbook.Worksheets.Add(Core.Resourcs.EntitiesVN.EmployeeVN.TitleExcelExport);

                //Thực hiện style cho title
                var title = worksheet.Range("A1:U1");
                title.Value = Core.Resourcs.EntitiesVN.EmployeeVN.TitleExcelExport;
                title.Merge();
                this.StyleTitle(title, 16, "Arial");

                //Cách ra một cell và gộp các cell ấy lại
                var distance = worksheet.Range("A2:U2");
                distance.Merge();

                //Thực hiện style cho title của table
                var titleTable = worksheet.Range("A3:U3");
                titleTable.Style.Fill.BackgroundColor = XLColor.Gray;//Thiết lập màu cho background
                this.StyleBorder(titleTable);//Thiết lập các border cho cell của title
                this.StyleTitle(titleTable, 10, "Arial");
                this.SetValueTitle(worksheet, 3);

                //Thực hiện lấy dữ liệu từ database gồm các list Emloyee
                var listAccount = _accountObjectRepository.GetDataExport();
                int index = 4;//dòng đầu tiên của dữ liệu
                int number = 1;//Dùng đếm số thứ tự của các dòng
                foreach (var account in listAccount)
                {
                    worksheet.Cell(index, 1).Value = number++;
                    worksheet.Cell(index, 2).Value = account.AccountObjectCode;
                    worksheet.Cell(index, 3).Value = account.AccountObjectName;
                    worksheet.Cell(index, 4).Value = account.Address;
                    worksheet.Cell(index, 5).Value = account.Country;
                    worksheet.Cell(index, 6).Value = account.DueTime;
                    worksheet.Cell(index, 7).Value = account.MaximizeDebtAmount;
                    worksheet.Cell(index, 8).Value = account.Prefix;
                    worksheet.Cell(index, 9).Value = account.EinvoiceContactName;
                    worksheet.Cell(index, 10).Value = $"'{account.EinvoiceContactMobile}";
                    worksheet.Cell(index, 11).Value = account.EinvoiceContactEmail;
                    worksheet.Cell(index, 12).Value = account.LegalRepresentative;
                    worksheet.Cell(index, 13).Value = account.PayAccountCode;
                    worksheet.Cell(index, 14).Value = account.PayAccountName;
                    worksheet.Cell(index, 15).Value = account.PaymentTermCode;
                    worksheet.Cell(index, 16).Value = account.PaymentTermName;
                    worksheet.Cell(index, 17).Value = account.TaxCode;
                    worksheet.Cell(index, 18).Value = account.Website;
                    worksheet.Cell(index, 19).Value = account.EmployeeCode;
                    worksheet.Cell(index, 20).Value = account.FullName;
                    worksheet.Cell(index, 21).Value = $"'{account.Phone}";

                    index++;//Sau khi nhập dữ liệu của một Employee thì tiếp tục nhập  dòng kế tiếp
                }
                var rangeData = worksheet.Range($"A4:U{index - 1}");//Tất cả dữ 
                this.StyleBorder(rangeData);//Thiết lập các border cho cell của data 
                rangeData.Style.Font.SetFontName("Times New Roman");//Thiết lập font chữ cho từng cell của data là dạng Times New Roman

                //Căn giữa cho dòng excel
                var rangeCountry = worksheet.Range($"E4:E{index - 1}");
                var rangePrefix = worksheet.Range($"H4:H{index - 1}");
                rangeCountry.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                rangePrefix.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


                //Thiết lập độ rộng cho các cột của sheet A, B, C
                this.SetColumnWidth(worksheet);

                using (var stream = new MemoryStream())
                {
                    //Lưu lại file excel
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    //Trả về cho client file excel
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Core.Resourcs.EntitiesVN.EmployeeVN.FileNameExcel);

                }
            }

        }

        #endregion

        #region Method Private For Style Export Excel

        /// <summary>
        /// Thực hiện style cho border của cell excel
        /// </summary>
        /// <param name="titleTable"></param>
        /// Created: HoaiPT(14/02/2022)
        private void StyleBorder(IXLRange titleTable)
        {
            titleTable.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);
            titleTable.Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
            titleTable.Style.Border.SetRightBorder(XLBorderStyleValues.Thin);
            titleTable.Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
        }

        /// <summary>
        /// Thực hiện style cho tiêu đề với cỡ chữ, kiểu chữ
        /// </summary>
        /// <param name="titleTable"></param>
        /// <param name="fontSize">Cỡ chữ</param>
        /// <param name="fontName">Kiểu chữ</param>
        /// Created: HoaiPT(14/02/2022)
        private void StyleTitle(IXLRange titleTable, int fontSize, string fontName)
        {
            titleTable.Style.Font.Bold = true;
            titleTable.Style.Font.FontSize = fontSize;
            titleTable.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            titleTable.Style.Font.SetFontName(fontName);
        }

        /// <summary>
        /// Thiết lập giá trị cho title table
        /// </summary>
        /// <param name="worksheet">Sheet thiết lập</param>
        /// <param name="first">Dòng bắt đầu</param>
        /// Created: HoaiPT(14/02/2022)
        private void SetValueTitle(IXLWorksheet worksheet, int first)
        {
            worksheet.Cell(first, 1).Value = Core.Resourcs.EntitiesVN.EmployeeVN.Number;
            worksheet.Cell(first, 2).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.AccountObjectCode;
            worksheet.Cell(first, 3).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.AccountObjectName;
            worksheet.Cell(first, 4).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.Address;
            worksheet.Cell(first, 5).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.Country;
            worksheet.Cell(first, 6).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.DueTime;
            worksheet.Cell(first, 7).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.MaximizeDebtAmount;
            worksheet.Cell(first, 8).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.Prefix;
            worksheet.Cell(first, 9).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.EinvoiceContactName;
            worksheet.Cell(first, 10).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.EinvoiceContactMobile;
            worksheet.Cell(first, 11).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.EinvoiceContactEmail;
            worksheet.Cell(first, 12).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.LegalRepresentative;
            worksheet.Cell(first, 13).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.PayAccountCode;
            worksheet.Cell(first, 14).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.PayAccountName;
            worksheet.Cell(first, 15).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.PaymentTermCode;
            worksheet.Cell(first, 16).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.PaymentTermName;
            worksheet.Cell(first, 17).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.TaxCode;
            worksheet.Cell(first, 18).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.Website;
            worksheet.Cell(first, 19).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.EmployeeCode;
            worksheet.Cell(first, 20).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.FullName;
            worksheet.Cell(first, 21).Value = Core.Resourcs.EntitiesVN.AccountObjectVN.Phone;

        }

        /// <summary>
        /// Thiết lập độ rộng của từng cột cell A, B, C
        /// </summary>
        /// <param name="worksheet"></param>
        /// Created: HoaiPT(14/02/2022)
        private void SetColumnWidth(IXLWorksheet worksheet)
        {
            worksheet.Column("A").Width = 4;
            worksheet.Column("B").Width = 18;
            worksheet.Column("C").Width = 28;
            worksheet.Column("D").Width = 20;
            worksheet.Column("E").Width = 20;
            worksheet.Column("F").Width = 16;
            worksheet.Column("G").Width = 14;
            worksheet.Column("H").Width = 12;
            worksheet.Column("I").Width = 27;
            worksheet.Column("J").Width = 25;
            worksheet.Column("K").Width = 25;
            worksheet.Column("L").Width = 25;
            worksheet.Column("M").Width = 20;
            worksheet.Column("N").Width = 23;
            worksheet.Column("O").Width = 17;
            worksheet.Column("P").Width = 20;
            worksheet.Column("Q").Width = 11;
            worksheet.Column("R").Width = 20;
            worksheet.Column("S").Width = 16;
            worksheet.Column("T").Width = 23;
            worksheet.Column("U").Width = 20;


        }
        #endregion

        /// <summary>
        /// Thiết ngoại lệ exception sẽ vào đây
        /// </summary>
        /// <param name="worksheet"></param>
        /// Created: HoaiPT(07/02/2022)
        private IActionResult AllException(Exception ex, Object? enity)
        {
            if (typeof(MISAValidateException) == ex.GetType())
            {
                var respo = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = enity,
                };
                return StatusCode(400, respo);
            }
            else
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Resourcs.ResourceVN.ErrorException
                };

                return StatusCode(500, response);
            }

        }
    }
}