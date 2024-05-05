using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace CloudSales.DataLayer.Repositories
{
    public class PurchasedSoftwareRepository : IPurchasedSoftwareRepository
    {
        private CloudSalesContext _context;
        public PurchasedSoftwareRepository(CloudSalesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurchasedSoftwareDto>> GetPurchasedSoftwareByAccountId(long accountId)
        {
            return await _context.PurchasedSoftwares.Where(x => x.AccountId == accountId).ToListAsync();
        }

        public async Task InsertPurchasedSoftware(long softwareId, string softwareName, long accountId, int licenceQuantity, string email)
        {
            var purchasedSoftware = _context.PurchasedSoftwares.Any(x => x.SoftwareName == softwareName
                                                                    && x.AccountId == accountId);
            if (!purchasedSoftware)
            {
                var purchasedSoftwareDto = new PurchasedSoftwareDto
                {
                    SoftwareName = softwareName,
                    SoftwareId= softwareId,
                    AccountId = accountId,
                    Quantity = licenceQuantity,
                    State = true,
                    ValidToDate = DateTime.UtcNow.AddDays(30),
                    DateCreated = DateTime.UtcNow
                    
                };
                _context.PurchasedSoftwares.Add(purchasedSoftwareDto);

                await _context.SaveChangesAsync();
            }
            
        }

        public async Task RemovePurchasedSoftwareFromAccount(long softwareId, long accountId)
        {
            var purchasedSoftwareDto =  _context.PurchasedSoftwares.Where(x => x.SoftwareId == softwareId
                                                                                    && x.AccountId == accountId).FirstOrDefault();
            if (purchasedSoftwareDto != null)
            {
                _context.PurchasedSoftwares.Remove(purchasedSoftwareDto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLicenceQuantity( long accountId, long softwareId, int licenceCount)
        {
            var purchasedSoftwareDto = _context.PurchasedSoftwares.Where(x => x.SoftwareId == softwareId
                                                                        && x.AccountId == accountId).FirstOrDefault();
            if (purchasedSoftwareDto != null)
            {
                purchasedSoftwareDto.Quantity = licenceCount;
                purchasedSoftwareDto.DateUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Licence not found");
            }
        }

        public async Task UpdateLicenceValidTo(long softwareId, long accountId, DateTime validTo)
        {
            var purchasedSoftwareDto = _context.PurchasedSoftwares.Where(x => x.PurchasedSoftwareId == softwareId
                                                                        && x.AccountId == accountId).FirstOrDefault();
            if (purchasedSoftwareDto != null)
            {
                purchasedSoftwareDto.ValidToDate = validTo;
                purchasedSoftwareDto.State = true;
                purchasedSoftwareDto.DateUpdated = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }

            else
            {
                throw new Exception("Licence not found");
            }
        }
    }
}
