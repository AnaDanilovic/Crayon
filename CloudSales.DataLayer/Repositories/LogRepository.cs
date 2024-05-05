using CloudSales.DataLayer.Interfaces;
using CloudSales.Model.Dto;

namespace CloudSales.DataLayer.Repositories
{
    public class LogRepository : ILogRepository
    {
        private CloudSalesContext _context;
        public LogRepository(CloudSalesContext context)
        {
            _context = context;
        }
        public async Task Log(string message, string stackTrace)
        {
            var logMessage = new LogDto
            {
                Message = message,
                StackTrace = stackTrace,
                DateCreated = DateTime.UtcNow
            };
            
             _context.Logs.Add(logMessage);
             await _context.SaveChangesAsync();
        }
    }
}
