using System;
using VelocityRent.Entities.Enums;

namespace VelocityRent.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public int PersonID { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }
        public enUserRole UserRole { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public DateTime CreateDate { get; private set; }

        // Constructor for NEW Users
        public User(
            int personId,
            string username,
            string passwordHash,
            enUserRole userRole
            )
        { 
            this.PersonID = personId;
            this.Username = username;
            this.PasswordHash = passwordHash;
            this.UserRole = userRole;

            this.IsActive = true;
            this.LastLogin = null;
            this.CreateDate = DateTime.Now;
        }

        // Constructor for EXISTING Users
        public User(
            int id,
            int personId,
            string username,
            string passwordHash,
            enUserRole userRole,
            DateTime? lastLogin,
            DateTime createDate,
            bool isActive)
            : this(
                  personId,
                  username,
                  passwordHash,
                  userRole)
        {
            this.ID = id;
            this.IsActive = isActive;
            this.LastLogin = lastLogin;
            this.CreateDate = createDate;
        }

        public void ChangeUsername(string username) => this.Username = username;
        public void ChangeRole(enUserRole userRole) => this.UserRole = userRole;
        public void SetActive(bool isActive) => this.IsActive = isActive;
       
    }
}
