using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent.Entities.Enums;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL.Repositories
{
    public class UserRepository : IUserRepositroy
    {
        public int Add(User user)
        {
            int id = -1;
            try
            {
                string query = @"
        INSERT INTO Users 
        (PersonID, Username, PasswordHash, UserRole, LastLogin, CreatedDate, IsActive)
        VALUES
        (@PersonID, @Username, @PasswordHash, @UserRole, @LastLogin, @CreatedDate, @IsActive);
        SELECT SCOPE_IDENTITY();";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@PersonID", SqlDbType.Int).Value = user.PersonID;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                    command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = user.PasswordHash;
                    command.Parameters.Add("@UserRole", SqlDbType.NVarChar).Value = user.UserRole.ToString();
                    command.Parameters.Add("@LastLogin", SqlDbType.DateTime).Value = (object)user.LastLogin ?? DBNull.Value;
                    command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = user.CreateDate;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;

                    connection.Open();
                    object result = command.ExecuteScalar();
                    id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return -1;
            }

            return id;
        }
        public User GetByID(int id)
        {
            try
            {
                string query = @"SELECT
                                    UserID,
                                    PersonID,
                                    Username,
                                    PasswordHash,
                                    UserRole,
                                    LastLogin,
                                    CreatedDate,
                                    IsActive
                                FROM Users
                                WHERE UserID = @ID;";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;
                        return MapUser(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return null;
            }
        }
        public User GetByUsername(string username)
        {
            try
            {
                string query = @"SELECT
                                    UserID,
                                    PersonID,
                                    Username,
                                    PasswordHash,
                                    UserRole,
                                    LastLogin,
                                    CreatedDate,
                                    IsActive
                                FROM Users
                                WHERE Username = @Username;";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;
                        return MapUser(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return null;
            }
        }
        public bool Exists(int id)
        {
            try
            {
                string query = @"
                                SELECT CASE
                                    WHEN EXISTS (
                                        SELECT 1
                                        FROM Users
                                        WHERE UserID = @ID)
                                    THEN 1
                                    ELSE 0
                                END";
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Update(User user)
        {
            try
            {
                string query = @"
                                 UPDATE Users
                                        SET Username = @Username,
                                            UserRole = @UserRole,
                                            IsActive = @IsActive
                                        WHERE UserID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                    command.Parameters.Add("@UserRole", SqlDbType.NVarChar).Value = user.UserRole.ToString();
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = user.ID;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
        public bool Delete(int id)
        {
            string query = @"DELETE FROM Users WHERE UserID = @ID;";

            try
            {
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
        public List<User> GetAll()
        {
            List<User> list = new List<User>();

            string query = @"SELECT * FROM Users;";

            try
            {
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            list.Add(MapUser(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return null;
            }

            return list;
        }
        private User MapUser(SqlDataReader reader)
        {
            DateTime? lastLogin = reader.IsDBNull(5)
                    ? null
                    : (DateTime?)reader.GetDateTime(5);

            return new User
            (
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetString(3),
                (enUserRole)Enum.Parse(typeof(enUserRole), reader.GetString(4)),
                lastLogin,
                reader.GetDateTime(6),
                reader.GetBoolean(7)
            );
        }
        public bool ChangePassword(int id,string password)
        {
            try
            {
                string query = @"
                                 UPDATE Users
                                        SET PasswordHash = @Password
                                        WHERE UserID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
        public bool UpdateLastLogin(int id)
        {
            try
            {
                string query = @"
                                 UPDATE Users
                                        SET LastLogin = @CurrentDateTime
                                        WHERE UserID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@CurrentDateTime", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
        public bool SetActive(int id,bool isActive)
        {
            try
            {
                string query = @"
                                 UPDATE Users
                                        SET IsActive = @IsActive
                                        WHERE UserID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }
        }
    }
}
