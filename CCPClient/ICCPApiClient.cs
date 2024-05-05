using CloudSales.Model.Model;

namespace CCPClient
{
    public interface ICCPApiClient
    {
        Task<List<Software>> GetServicesAsync();
    }
}