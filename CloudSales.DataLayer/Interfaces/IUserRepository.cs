using CloudSales.Model.Dto;

namespace CloudSales.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUser(string userName, string email);
    }
}
