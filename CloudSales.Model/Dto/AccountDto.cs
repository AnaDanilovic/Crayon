using System.ComponentModel.DataAnnotations;

namespace CloudSales.Model.Dto
{
    public class AccountDto
    {
        [Key]
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long UserId { get; set; }
    }
}
