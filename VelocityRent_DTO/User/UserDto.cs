using System;

namespace DTO.User
{
    public class UserDto
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
