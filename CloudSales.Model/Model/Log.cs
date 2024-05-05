namespace CloudSales.Model.Model
{
    public class Log
    {
        public long LogId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
