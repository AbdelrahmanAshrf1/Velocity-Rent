
using System;

namespace DTO.Person
{
    public class UpdatePersonDto 
    {
        public int ID { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfileImage { get; set; }
    }
}
