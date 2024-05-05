namespace CloudSales.DataLayer.Interfaces
{
    public interface ILogRepository
    {
        Task Log(string message, string stackTrace);
    }
}
