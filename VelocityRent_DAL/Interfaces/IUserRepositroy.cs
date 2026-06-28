using System.Collections.Generic;
using VelocityRent.Entities;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface IUserRepositroy
    {
        int Add(User user);
        bool Exists(int id);
        bool Update(User user);
        bool Delete(int id);
        User GetByID(int id);
        List<User> GetAll();
        bool ChangePassword(int id, string PasswordHash);
        bool UpdateLastLogin(int id);
        bool SetActive(int id, bool isActive);
        User GetByUsername(string username);
    }
}
