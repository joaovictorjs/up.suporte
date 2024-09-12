using System.Security;

namespace up.suporte.Stores
{
    public interface IPasswordStore : IDisposable
    {
        public SecureString Password
        {
            get;
        }
    }
}
