using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL.Repositories
{
    public class PersonRepository : IPersonRepositroy
    {
        public int Add(Person person,SqlConnection connection, SqlTransaction transaction)
        {
            int id = -1;
            try
            {
                string query = @"
        INSERT INTO People 
        (FirstName, LastName, Email, Phone, DateOfBirth, NationalID, AddressID, ProfileImage)
        VALUES
        (@FirstName, @LastName, @Email, @Phone, @DateOfBirth, @NationalID, @AddressID, @ProfileImage);
        SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection,transaction))
                {
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = person.DateOfBirth;
                    command.Parameters.Add("@NationalID", SqlDbType.NVarChar).Value = person.NationalID;
                    command.Parameters.Add("@AddressID", SqlDbType.Int).Value = person.AddressID;
                    command.Parameters.Add("@ProfileImage", SqlDbType.NVarChar).Value = person.ProfileImage;

                    object result = command.ExecuteScalar();
                    id = Convert.ToInt32(result);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }

            return id;
        }
        public Person GetByID(int id)
        {
            try
            {
                string query = @"SELECT 
                                    PersonID,
                                    FirstName,
                                    LastName,
                                    Email,
                                    Phone,
                                    DateOfBirth,
                                    NationalID,
                                    AddressID,
                                    ProfileImage,
                                    CreatedDate,
                                    IsActive
                                FROM People 
                                WHERE PersonID = @ID;";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;
                        return Map(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
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
                                        FROM People
                                        WHERE PersonID = @ID)
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
                Logger.Error(ex.Message);
                throw;
            }
        }
        public bool Update(Person person, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                string query = @"
                                 UPDATE People
                                 SET FirstName=@FirstName,
                                     LastName=@LastName,
                                     Email=@Email,
                                     Phone=@Phone,
                                     DateOfBirth=@DateOfBirth,
                                     ProfileImage=@ProfileImage
                                 WHERE PersonID=@ID";

                using (SqlCommand command = new SqlCommand(query, connection,transaction))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = person.ID;

                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = person.DateOfBirth;
                    command.Parameters.Add("@ProfileImage", SqlDbType.NVarChar).Value = person.ProfileImage;
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }
        public bool Delete(int id)
        {
            string query = @"DELETE FROM People WHERE PersonID = @ID;";

            try
            { 
                using(SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Add("@ID",SqlDbType.Int).Value = id;

                    connection.Open(); 

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }
        public List<Person> GetAll()
        {
            List<Person> list = new List<Person>();

            string query = @"SELECT  
                                PersonID,
                                FirstName,
                                LastName,
                                Email,
                                Phone,
                                DateOfBirth,
                                NationalID,
                                AddressID,
                                ProfileImage,
                                CreatedDate,
                                IsActive
                            FROM People;";

            try
            {
                using(SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                            list.Add(Map(reader));
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }

            return list;
        }
        public bool ChangeStatus(int id, bool status)
        {
            int rowsAffected = 0;
            try
            {
                string qurry = @"UPDATE People SET IsActive = @IsActive WHERE PersonID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(qurry, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = status;

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }

            return rowsAffected > 0;
        }
        private static Person Map(SqlDataReader reader)
        {
            return new Person(
                reader.GetInt32(reader.GetOrdinal("PersonID")),
                reader.GetString(reader.GetOrdinal("FirstName")),
                reader.GetString(reader.GetOrdinal("LastName")),
                reader.GetString(reader.GetOrdinal("Email")),
                reader.GetString(reader.GetOrdinal("Phone")),
                reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                reader.GetString(reader.GetOrdinal("NationalID")),
                reader.GetInt32(reader.GetOrdinal("AddressID")),
                reader.IsDBNull(reader.GetOrdinal("ProfileImage"))
                ? null
                : reader.GetString(reader.GetOrdinal("ProfileImage")),
                reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                reader.GetBoolean(reader.GetOrdinal("IsActive"))
            );
        }
    }
}
