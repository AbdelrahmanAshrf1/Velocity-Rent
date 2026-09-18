using VelocityRent.Entities.Enums;

namespace DTO.User
{
    public class UpdateUserDto
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public enUserRole UserRole { get; set; }

        public UpdateUserDto(int id) => Id = id;
    }
}
