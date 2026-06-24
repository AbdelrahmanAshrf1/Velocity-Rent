using DTO;
using DTO.User;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(AddUserDto dto)
        {
            return new User(
                personId: dto.PersonID,
                username: dto.Username,
                passwordHash: dto.Password,
                userRole:dto.UserRole
            );
        }

        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                PersonID = user.PersonID,
                Username = user.Username,
                Role = user.UserRole.ToString(),
                IsActive = user.IsActive,
                LastLogin = user.LastLogin,
                CreateDate = user.CreateDate,
            };
        }
        public static void UpdateEntity(UpdateUserDto dto, User user)
        {
            user.ChangeRole(dto.UserRole);
            user.ChangeUsername(dto.Username);
            user.SetActive(dto.IsActive);
        }
    }
}
