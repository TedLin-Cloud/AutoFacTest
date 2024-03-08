namespace AutofacTest.Services
{
    public interface ILogService
    {
        void Log(string message);
        string ID { get; }
    }
    //public class LogService : ILogService
    //{
    //    private readonly IEncryptService _encryptService;
    //    private readonly ILogger<LogService> _logger;
    //    private string _id;

    //    public LogService(IEncryptService encryptService, ILogger<LogService> logger)
    //    {
    //        _logger = logger;
    //        _encryptService = encryptService;
    //        _id = DateTime.Now.ToString("yyMMddHHmmss");
    //    }

    //    public void Log(string message) => _logger.LogInformation(_encryptService.Encrypt(message));

    //    public string ID => _id;
    //}
}
