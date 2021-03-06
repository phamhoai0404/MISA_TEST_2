using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentTermsController : MISABaseController<PaymentTerm>
    {
        public PaymentTermsController(IBaseService<PaymentTerm> baseService, IBaseRepository<PaymentTerm> baseRepository) : base(baseRepository, baseService)
        {

        }
    }
}
