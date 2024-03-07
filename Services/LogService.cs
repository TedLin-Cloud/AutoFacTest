namespace AutofacTest.Services
{
    public interface ILogService
    {
        void Log(string message);
    }
    public class LogService : ILogService
    {
        private readonly IEncryptService _encryptService;
        private readonly ILogger<LogService> _logger;

        public LogService(IEncryptService encryptService, ILogger<LogService> logger)
        {
            _logger = logger;
            _encryptService = encryptService;
        }

        public void Log(string message) => _logger.LogInformation(_encryptService.Encrypt(message));
    }
}
