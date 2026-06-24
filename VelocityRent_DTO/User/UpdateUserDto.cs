using VelocityRent.Entities.Enums;

namespace DTO.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public enUserRole UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}
