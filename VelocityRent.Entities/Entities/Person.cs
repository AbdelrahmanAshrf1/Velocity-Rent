using System;

namespace VelocityRent.Entities
{
    public class Person
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string NationalID { get; private set; }
        public int AddressID { get; private set; }
        public Address Address { get; private set; }
        public string ProfileImage { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool IsActive { get; private set; }

        public Person(
            int id,
            string firstName,
            string lastName,
            string email, 
            string phone, 
            DateTime dateOfBirth,
            string nationalID,
            int addressID,
            string profileImage,
            DateTime createDate,
            bool isActive)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = dateOfBirth;
            this.NationalID = nationalID;
            this.AddressID = addressID;
            this.ProfileImage = profileImage;
            this.CreateDate = createDate;
            this.IsActive = isActive;
        }

        public void Update(
            string firstName,
            string lastName,
            string email,
            string phone,
            DateTime dateOfBirth,
            string profileImage)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            ProfileImage = profileImage;
        }

        public void Deactivate() => this.IsActive = false;

    }
}
