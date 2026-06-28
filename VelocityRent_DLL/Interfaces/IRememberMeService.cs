namespace VelocityRent_DLL.Interfaces
{
    public interface IRememberMeService
    {
        void Save(string username);
        string Load();
        void Clear();
    }
}
