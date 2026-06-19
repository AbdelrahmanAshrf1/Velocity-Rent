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
        public int Add(Person person)
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

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = person.DateOfBirth;
                    command.Parameters.Add("@NationalID", SqlDbType.NVarChar).Value = person.NationalID;
                    command.Parameters.Add("@AddressID", SqlDbType.Int).Value = person.AddressID;
                    command.Parameters.Add("@ProfileImage", SqlDbType.NVarChar).Value = person.ProfileImage;

                    connection.Open();
                    object result = command.ExecuteScalar();
                    id = Convert.ToInt32(result);
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return -1;
            }

            return id;
        }
        public Person GetByID(int id)
        {
            try
            {
                string query = @"SELECT * FROM People WHERE PersonID = @ID;";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(!reader.Read()) return null;

                        return new Person
                        (
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDateTime(5),
                            reader.GetString(6),
                            reader.GetInt32(7),
                            reader.GetString(8),
                            reader.GetDateTime(9),
                            reader.GetBoolean(10)
                        );

                    }    
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }
        }
        public bool Update(Person person)
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

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = person.DateOfBirth;
                    command.Parameters.Add("@ProfileImage", SqlDbType.NVarChar).Value = person.ProfileImage;

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
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
                return false;
            }
        }
        public List<Person> GetAll()
        {
            List<Person> list = new List<Person>();

            string query = @"SELECT * FROM People;";

            try
            {
                using(SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Person
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetDateTime(5),
                                reader.GetString(6),
                                reader.GetInt32(7),
                                reader.GetString(8),
                                reader.GetDateTime(9),
                                reader.GetBoolean(10)
                            ));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message);
                return null;
            }

            return list;
        }
    }
}
