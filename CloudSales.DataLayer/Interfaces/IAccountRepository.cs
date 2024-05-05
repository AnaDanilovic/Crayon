using CloudSales.Model.Dto;

namespace CloudSales.DataLayer.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountDto>> GetAccountsByUserId(long userId);
    }
}
