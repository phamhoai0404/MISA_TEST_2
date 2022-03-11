using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Fresher.Web12.Core.Exceptions;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.Interfaces.Services;

namespace MISA.Fresher.Web12.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ControlCaPaymentController : ControllerBase
    {
        #region Fields
        IControlCaPaymentRepository _controlCaPaymentRepository;
        IControlCaPaymentService _controlCaPaymentService;
        #endregion

        #region Contructor
        public ControlCaPaymentController(IControlCaPaymentRepository controlCaPaymentRepository, IControlCaPaymentService controlCaPaymentService) 
        {
            this._controlCaPaymentRepository = controlCaPaymentRepository; 
            this._controlCaPaymentService = controlCaPaymentService;
        }
        #endregion


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var entites = _controlCaPaymentRepository.GetByCaPaymentId(id);
                return Ok(entites);
            }
            catch (Exception ex)
            {
                return this.AllException(ex, null);
            }


        }

        #region Methods Exception

        /// <summary>
        /// Khi có lỗi sẽ nhảy vào exception này
        /// </summary>
        /// <param name="ex">Error</param>
        /// <returns></returns>
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
        #endregion
    }
}
