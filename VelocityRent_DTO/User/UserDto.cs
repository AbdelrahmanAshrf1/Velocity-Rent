
namespace DTO
{
    public enum UserRole  { Employee = 1, Manager = 2,Admin = 3 }
    public class UserDto
    {
        public AddPersonDto Person { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
    }
}
