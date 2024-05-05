using AutoMapper;
using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Model;
using Microsoft.AspNetCore.Mvc;

namespace CloudSales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public AccountController (IAccountRepository accountRepository,
                                  ILogRepository logRepository,
                                  IMapper mapper)
        {
            _accountRepository = accountRepository;
            _logRepository = logRepository;
            _mapper = mapper;

        }

        [HttpGet("GetUserAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> Get(long userId)
        {
            if (userId == 0)
            {
                return StatusCode(400, "Please provide valid userId.");

            }
            try
            {
                var accountDtos = await _accountRepository.GetAccountsByUserId(userId);
                var accounts = accountDtos.Select(x => _mapper.Map<Account>(x)).ToList();

                return accounts;
            }
            catch (Exception ex)
            {
                await _logRepository.Log(ex.Message, ex.StackTrace);
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

    }
}
