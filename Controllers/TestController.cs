using AutofacTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutofacTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IEncryptService _encryptService;
        private readonly ILogService _logService;

        public TestController(ILogger<TestController> logger, IEncryptService encryptService, ILogService logService)
        {
            _logger = logger;
            _encryptService = encryptService;
            _logService = logService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logService.Log("LOG");
            return Ok(_encryptService.Encrypt("test"));
        }
    }
}
