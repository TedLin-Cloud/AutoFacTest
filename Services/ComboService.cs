using System.Security.Cryptography;
using System.Text;

namespace AutofacTest.Services
{
    public class ComboService: ILogService, IEncryptService
    {
        private string _id;
        public ComboService() { _id = DateTime.Now.ToString("yyMMddHHmmss"); }
        public string Encrypt(string key) => Convert.ToBase64String(Encoding.UTF8.GetBytes(key));

        public void Log(string message) => Console.WriteLine(message);
        public string ID => _id;
    }
}
