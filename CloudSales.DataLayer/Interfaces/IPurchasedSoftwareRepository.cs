using CloudSales.Model.Dto;

namespace CloudSales.DataLayer.Interfaces
{
    public interface IPurchasedSoftwareRepository
    {
        Task<IEnumerable<PurchasedSoftwareDto>> GetPurchasedSoftwareByAccountId(long accountId);

        Task InsertPurchasedSoftware(long softwareId, string softwareName, long accountId, int licenceQuantity, string email);
        Task RemovePurchasedSoftwareFromAccount(long softwareId, long accountId);

        Task UpdateLicenceQuantity(long softwareId, long accountId, int licenceCount);

        Task UpdateLicenceValidTo(long softwareId, long accountId, DateTime validTo);
    }
}
