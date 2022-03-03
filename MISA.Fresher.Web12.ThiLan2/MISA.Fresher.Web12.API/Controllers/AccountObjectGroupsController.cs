using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountObjectGroupsController : MISABaseController<AccountObjectGroup>
    {
        public AccountObjectGroupsController(IBaseService<AccountObjectGroup> baseService, IBaseRepository<AccountObjectGroup> baseRepository) : base(baseRepository, baseService)
        {

        }
    }
}
