
using System;

namespace DTO.Person
{
    public class PersonDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalID { get; set; }
        public string ProfileImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AddressID { get; set; }
        public bool Active { get; set; }
    }
}
