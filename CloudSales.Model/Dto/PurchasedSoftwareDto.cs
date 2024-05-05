using System.ComponentModel.DataAnnotations;

namespace CloudSales.Model.Dto
{
    public class PurchasedSoftwareDto
    {
        [Key]
        public long PurchasedSoftwareId { get; set; }
        public long SoftwareId { get; set; }
        public string SoftwareName { get; set; }
        public int Quantity { get; set; }
        public bool State { get; set; }
        public DateTime ValidToDate { get; set; }
        public long AccountId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }    }
}
