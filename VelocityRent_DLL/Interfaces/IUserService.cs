
using DTO;
using DTO.User;
using System.Collections.Generic;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Interfaces
{
    public interface IUserService
    {
        int AddUser(AddUserDto dto);
        bool UpdateUser(UpdateUserDto dto);
        bool Activate(int id);
        bool Deactivate(int id);
        bool ChangePassword(ChangePasswordDto dto);
        bool Exists(int id);
        UserDto GetUserByID(int id);
        List<UserDto> GetAllUsers();
        User Authenticate(string username, string password);
        Result<UserDto> Login(LoginDto dto);
    }
}
