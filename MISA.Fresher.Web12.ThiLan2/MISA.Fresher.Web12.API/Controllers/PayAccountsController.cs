using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PayAccountsController : MISABaseController<PayAccount>
    {
        public PayAccountsController(IBaseService<PayAccount> baseService, IBaseRepository<PayAccount> baseRepository) : base(baseRepository, baseService)
        {

        }
    }
}
