using CCPClient;
using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Model;
using CloudSales.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CloudSales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        private readonly ICCPApiClient _ccpApiClient;

        public SoftwareController (ICCPApiClient ccpApiClient, 
                                   ILogRepository logRepository)
        {
            _ccpApiClient = ccpApiClient;
            _logRepository = logRepository;
        }

        [HttpGet("GetSoftwareList")]
        public async Task<ActionResult<IEnumerable<Software>>> Get()
        {
            try
            {
                return await _ccpApiClient.GetServicesAsync();
            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

        }
    }

}

