using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace CloudSales.DataLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private CloudSalesContext _context;
        public AccountRepository(CloudSalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsByUserId(long userId)
        {
            return await _context.Accounts.Where(x => x.UserId == userId).ToListAsync();

        }
    }
}
