using System;

namespace DTO
{
    public  class AddPersonDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string NationalID { get; set; }

        public int AddressID { get; set; }

        public string ProfileImage { get; set; }
    }
}
