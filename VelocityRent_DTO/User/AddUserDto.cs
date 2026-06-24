using VelocityRent.Entities.Enums;

namespace DTO
{
    public class AddUserDto
    {
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public enUserRole UserRole { get; set; }
    }
}
