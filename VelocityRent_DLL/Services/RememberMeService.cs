using VelocityRent_DLL.Interfaces;
using VelocityRent_Utilities;

namespace VelocityRent_DLL.Services
{
    public class RememberMeService : IRememberMeService
    {
        private const string SubKey = "Login";
        private const string UsernameValue = "Username";

        public void Save(string username)
        {
            RegistryHelper.SetValue(SubKey, UsernameValue, username);
        }

        public string Load()
        {
            return RegistryHelper.GetValue(SubKey, UsernameValue, string.Empty);
        }

        public void Clear()
        {
            RegistryHelper.DeleteValue(SubKey, UsernameValue);
        }
    }
}
