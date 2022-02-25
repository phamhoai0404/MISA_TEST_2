using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountObjectsController :  MISABaseController<AccountObject>
    {
        public AccountObjectsController(IBaseService<AccountObject> baseService, IBaseRepository<AccountObject> baseRepository) : base(baseRepository, baseService)
    {

    }
}
}