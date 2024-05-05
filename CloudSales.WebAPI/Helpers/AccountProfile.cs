using AutoMapper;
using CloudSales.Model.Dto;
using CloudSales.Model.Model;

namespace CloudSales.WebAPI.Helpers
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
