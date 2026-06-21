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
        public string ProfileImage { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool IsActive { get; private set; }

        // Constructor for NEW person
        public Person(
            string firstName,
            string lastName,
            string email,
            string phone,
            DateTime dateOfBirth,
            string nationalID,
            int addressID,
            string profileImage)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            NationalID = nationalID;
            AddressID = addressID;
            ProfileImage = profileImage;

            CreateDate = DateTime.Now;
            IsActive = true;
        }

        // Constructor for EXISTING person loaded from DB
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
            DateTime createdDate,
            bool isActive)
            : this(
                firstName,
                lastName,
                email,
                phone,
                dateOfBirth,
                nationalID,
                addressID,
                profileImage)
        {
            ID = id;
            CreateDate = createdDate;
            IsActive = isActive;
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

        public void Deactivate()
        {
            if (!IsActive) return;
            IsActive = false;
        }

    }
}
