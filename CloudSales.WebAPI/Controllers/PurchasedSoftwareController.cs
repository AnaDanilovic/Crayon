using AutoMapper;
using CCPClient;
using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Model;
using CloudSales.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CloudSales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedSoftwareController : ControllerBase
    {
        private readonly IPurchasedSoftwareRepository _purchasedSoftwareRepository;
        private readonly ICCPApiClient _ccpApiClient;
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public PurchasedSoftwareController (IPurchasedSoftwareRepository purchasedSoftwareRepository,
                                            ILogRepository logRepository,
                                            ICCPApiClient ccpApiClient,
                                            IMapper mapper)
        {
            _purchasedSoftwareRepository = purchasedSoftwareRepository;
            _logRepository = logRepository;
            _ccpApiClient = ccpApiClient;
            _mapper = mapper;
        }

        [HttpGet("GetSoftwareAccountList")]
        public async Task<ActionResult<IEnumerable<PurchasedSoftware>>> Get(long accountId)
        {
            if (accountId == 0)
            {
                return StatusCode(400, "Please provide valid accountId.");

            }
            try
            {
                var purchasedSoftwareDtos = await _purchasedSoftwareRepository.GetPurchasedSoftwareByAccountId(accountId);
                var purchasedSoftware = purchasedSoftwareDtos.Select(x => _mapper.Map<PurchasedSoftware>(x)).ToList();
                return purchasedSoftware;
            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

        }

        [HttpPost("CancelSoftwareAccount")]
        public async Task<ActionResult<string>> Post(long accountId, long softwareId)
        {
            if (softwareId == 0  || accountId == 0)
            {
                return StatusCode(400, "Please provide valid softwareId and accountId.");

            }
            try
            {
                await _purchasedSoftwareRepository.RemovePurchasedSoftwareFromAccount(softwareId, accountId);
                return StatusCode(200, "Software removed successfuly");

            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

        }

        [HttpPost("OrderSoftware")]
        public async Task<ActionResult<string>> PostOrder(long accountId, long softwareId, int quantity)
        {
            if (softwareId == 0 || accountId == 0 || quantity == 0)
            {
                return StatusCode(400, "Please provide valid softwareId and accountId and quantity");

            }
            try
            {
                var ccpSoftwareList = await _ccpApiClient.GetServicesAsync();
                var ccpSoftware = ccpSoftwareList.Where(x => x.SoftwareId == softwareId).FirstOrDefault();
                await _purchasedSoftwareRepository.InsertPurchasedSoftware(ccpSoftware.SoftwareId, ccpSoftware.SoftwareName, accountId, quantity, "ana.danilovic@email.com");

                return StatusCode(200, "Order successeded");
            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("UpdateLicenceQuantity")]
        public async Task<ActionResult<string>> Post(long accountId, long softwareId, int quantity)
        {
            if (softwareId == 0 || accountId == 0 || quantity == 0)
            {
                return StatusCode(400, "Please provide valid softwareId and accountId and quantity");

            }
            try
            {
                await _purchasedSoftwareRepository.UpdateLicenceQuantity(accountId, softwareId, quantity);
                return StatusCode(200, "Licence quanity updated successfully");

            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpPut("ExtendLicence")]
        public async Task<ActionResult<string>> Put(long accountId, long softwareId, DateTime validTo)
        {
            if (softwareId == 0 || accountId == 0)
            {
                return StatusCode(400, "Please provide valid softwareId and accountId.");

            }
            try
            {
                await _purchasedSoftwareRepository.UpdateLicenceValidTo(softwareId, accountId, validTo);

                return StatusCode(200, "Licence updated successfully");
            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }

        }

    }
}
