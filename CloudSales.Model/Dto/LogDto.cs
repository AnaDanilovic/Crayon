using System.ComponentModel.DataAnnotations;

namespace CloudSales.Model.Dto
{
    public class LogDto
    {
        [Key]
        public long LogId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
