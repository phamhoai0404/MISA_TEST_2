using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;
using System.Globalization;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CaPaymentsController : MISABaseController<CaPayment>
    {
        #region Fields
        ICaPaymentRepository _caPaymentRepository;
        ICaPaymentService _caPaymentService;
        #endregion

        #region Contructor
        public CaPaymentsController(ICaPaymentRepository caPaymentRepository, ICaPaymentService caPaymentService) : base(caPaymentRepository , caPaymentService)
        {
            this._caPaymentRepository = caPaymentRepository;
            this._caPaymentService = caPaymentService;
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
                var res = _caPaymentService.getCodeNewService();
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return this.AllException(ex, null);
            }

        }

        /// <summary>
        /// Thực hiện lấy dữ liệu phân trang theo bộ lọc và từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText">Từ khóa tìm kiếm</param>
        /// <param name="pageIndex">Trang đang đứng</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="objectSearch">Bộ lọc tìm kiếm của CaPayment</param>
        /// <returns></returns>
        /// Created: HoaiPT(19/03/2022)
        [HttpPost("GetPageV2")]
        public IActionResult GetPagingV2(string? searchText, int pageIndex, int pageSize, FilterCaPayment? objectSearch)
        {
            try
            {
                var res = _caPaymentService.GetPagingServiceV2(searchText,pageSize,pageIndex, objectSearch);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return this.AllException(ex, null);
            }

        }


        /// <summary>
        /// Thực hiện xóa nhiều CaPayment đồng thời xóa cả CaPaymentDetail với listId của CaPayment truyền vào
        /// </summary>
        /// <param name="listId">List Id của CaPayment</param>
        /// <returns></returns>
        /// Created: HoaiPT(21/03/2022)
        [HttpPost("DeleteMany")]
        public IActionResult DeleteMany(List<string> listId)
        {
            try
            {
                var res = _caPaymentService.DeleteManyService(listId);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return this.AllException(ex, null);
            }

        }


        /// <summary>
        /// Thực hiện xuất ra file excel danh sách phiếu chi
        /// </summary>
        /// <returns></returns>
        /// Created: HoaiPT(14/02/2022)
        [HttpGet("Excel")]
        public IActionResult exportExcel()
        {
            //Thực hiện tạo ra file excel mới và sau khi làm xong  đóng lại luôn
            using (var workbook = new XLWorkbook())
            {
                //Tạo ra sheet mới trong file excel có tên là NHÀ CUNG CẤP
                var worksheet = workbook.Worksheets.Add(Core.Resourcs.EntitiesVN.CaPaymentVN.TitleExcelExport);

                //Thực hiện style cho title
                var title = worksheet.Range("A1:H1");
                title.Value = Core.Resourcs.EntitiesVN.CaPaymentVN.TitleExcelExport;
                title.Merge();
                this.StyleTitle(title, 16, "Arial");

                //Cách ra một cell và gộp các cell ấy lại
                var distance = worksheet.Range("A2:H2");
                distance.Merge();

                //Thực hiện style cho title của table
                var titleTable = worksheet.Range("A3:H3");
                titleTable.Style.Fill.BackgroundColor = XLColor.Gray;//Thiết lập màu cho background
                this.StyleBorder(titleTable);//Thiết lập các border cho cell của title
                this.StyleTitle(titleTable, 10, "Arial");
                this.SetValueTitle(worksheet, 3);

                //Thực hiện lấy dữ liệu từ database gồm các list Emloyee
                var listAccount = _caPaymentRepository.GetDataExport();
                int index = 4;//dòng đầu tiên của dữ liệu
                int number = 1;//Dùng đếm số thứ tự của các dòng
                foreach (var account in listAccount)
                {
                    worksheet.Cell(index, 1).Value = number++;
                    worksheet.Cell(index, 2).Value = account.PostedDate;
                    worksheet.Cell(index, 3).Value = account.CaPaymentDate;
                    worksheet.Cell(index, 4).Value = account.CaPaymentNo;
                    worksheet.Cell(index, 5).Value = account.Resion;
                    string k = account.TotalAmount.ToString("N", CultureInfo.InvariantCulture);
                    worksheet.Cell(index, 6).Value =k;
                    worksheet.Cell(index, 7).Value = account.AccountObjectCode;
                    worksheet.Cell(index, 8).Value = account.AccountObjectName;
                   
                   

                    index++;//Sau khi nhập dữ liệu của một Employee thì tiếp tục nhập  dòng kế tiếp
                }
                var rangeData = worksheet.Range($"A4:H{index - 1}");//Tất cả dữ 
                this.StyleBorder(rangeData);//Thiết lập các border cho cell của data 
                rangeData.Style.Font.SetFontName("Times New Roman");//Thiết lập font chữ cho từng cell của data là dạng Times New Roman


                //Căn giữa cho dòng excel
                var rangePostedDate = worksheet.Range($"B4:B{index - 1}");
                rangePostedDate.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                var rangeCaPaymentDate = worksheet.Range($"C4:C{index - 1}");
                rangeCaPaymentDate.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                var rangeTotalNumber = worksheet.Range($"F4:F{index - 1}");
                rangeTotalNumber.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


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
            worksheet.Cell(first, 2).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.PostedDate;
            worksheet.Cell(first, 3).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.CaPaymentDate;
            worksheet.Cell(first, 4).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.CaPaymentNo;
            worksheet.Cell(first, 5).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.Resion;
            worksheet.Cell(first, 6).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.TotalAmount;
            worksheet.Cell(first, 7).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.AccountObjectCode;
            worksheet.Cell(first, 8).Value = Core.Resourcs.EntitiesVN.CaPaymentVN.AccountObjectName;


        }

        /// <summary>
        /// Thiết lập độ rộng của từng cột cell A, B, C
        /// </summary>
        /// <param name="worksheet"></param>
        /// Created: HoaiPT(14/02/2022)
        private void SetColumnWidth(IXLWorksheet worksheet)
        {
            worksheet.Column("A").Width = 4;
            worksheet.Column("B").Width = 16;
            worksheet.Column("C").Width = 16;
            worksheet.Column("D").Width = 15;
            worksheet.Column("E").Width = 15;
            worksheet.Column("F").Width = 13;
            worksheet.Column("G").Width = 16;
            worksheet.Column("H").Width = 20;


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
