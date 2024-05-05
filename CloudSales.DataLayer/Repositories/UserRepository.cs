using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Dto;

namespace CloudSales.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CloudSalesContext _context;
        public UserRepository(CloudSalesContext context)
        {
            _context = context;
        }

        
        public async Task<UserDto> GetUser(string userName, string email)
        {
            return await _context.Users.FindAsync(userName, email);           
        }
    }
}
