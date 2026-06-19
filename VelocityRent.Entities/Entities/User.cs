using System;

namespace VelocityRent.Entities.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public int PersonID { get; private set; }
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public enum enUserRole  { Manager = 1, Admin = 2, Employee = 3 }
        public enUserRole UserRole { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime LastLogin { get; private set; }
        public DateTime CreateDate { get; private set; }

        public User(
            int id,
            int personId,
            string username,
            string passwordHash,
            enUserRole userRole,
            bool isActive,
            DateTime lastLogin,
            DateTime createDate
            )
        { 
            this.ID = id;
            this.PersonID = personId;
            this.Username = username;
            this.PasswordHash = passwordHash;
            this.UserRole = userRole;
            this.IsActive = isActive;
            this.LastLogin = lastLogin;
            this.CreateDate = createDate;
        }

        public void ChangeUsername(string newUsername) => this.Username = newUsername;
        public void ChangePassword(string newPasswordHash) => this.PasswordHash = newPasswordHash;
        public void ChangeRole(enUserRole newRole) => this.UserRole = newRole;
        public void UpdateLastLogin() => this.LastLogin = DateTime.Now;
        public void Deactivate() => this.IsActive = false;

    }
}
