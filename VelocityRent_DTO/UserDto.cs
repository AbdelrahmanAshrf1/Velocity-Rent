using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public enum UserRole  { Employee = 1, Manager = 2,Admin = 3 }
    public class UserDto
    {
        public PersonDto Person { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
    }
}
