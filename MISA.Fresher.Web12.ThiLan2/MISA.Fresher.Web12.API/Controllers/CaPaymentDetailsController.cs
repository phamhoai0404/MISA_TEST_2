using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CaPaymentDetailsController : MISABaseController<CaPaymentDetail>
    {
        public CaPaymentDetailsController(IBaseService<CaPaymentDetail> baseService, IBaseRepository<CaPaymentDetail> baseRepository) : base(baseRepository, baseService)
        {

        }
        [HttpPost("CodeNe")]
        public IActionResult Xinhgai(string hoa, int uu, FilterAccountObject xinhXinh)
        {
            return Ok();
           
        }
    }
}
