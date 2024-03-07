using System.Text;

namespace AutofacTest.Services
{
    public interface IEncryptService
    {
        string Encrypt(string key);
    }
    public class EncryptService : IEncryptService
    {
        public string Encrypt(string key) => Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
    }
}
