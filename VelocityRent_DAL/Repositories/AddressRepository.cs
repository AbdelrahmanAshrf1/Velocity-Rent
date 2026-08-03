using System;
using System.Data;
using System.Data.SqlClient;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL
{
    public class AddressRepository : IAddressRepository
    {
        public int Add(Address address, SqlConnection connection, SqlTransaction transaction)
        {
            int id;
            try
            {
                string query = @"
                    INSERT INTO Addresses (City, State, ZipCode, Country, Latitude, Longitude, IsActive)
                    VALUES (@City, @State, @ZipCode, @Country, @Latitude, @Longitude, @IsActive);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                    command.Parameters.Add("@State", SqlDbType.NVarChar).Value = address.State;
                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode;
                    command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;
                    AddDecimalParam(command, "@Latitude", address.Latitude);
                    AddDecimalParam(command, "@Longitude", address.Longitude);

                    object result = command.ExecuteScalar();
                    id = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }

            return id;
        }

        public bool Update(Address address, SqlConnection connection, SqlTransaction transaction)
        {
            int rowsAffected;
            try
            {
                string query = @"
                    UPDATE Addresses
                    SET City = @City, State = @State, ZipCode = @ZipCode, Country = @Country,
                        Latitude = @Latitude, Longitude = @Longitude, IsActive = @IsActive
                    WHERE AddressID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = address.ID;
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                    command.Parameters.Add("@State", SqlDbType.NVarChar).Value = address.State;
                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode;
                    command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;
                    AddDecimalParam(command, "@Latitude", address.Latitude);
                    AddDecimalParam(command, "@Longitude", address.Longitude);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }

            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            int rowsAffected;
            try
            {
                string query = @"DELETE FROM Addresses WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }

            return rowsAffected > 0;
        }

        public bool ChangeStatus(int id, bool status)
        {
            int rowsAffected;
            try
            {
                string query = @"UPDATE Addresses SET IsActive = @IsActive WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = status;

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }

            return rowsAffected > 0;
        }

        public Address GetByID(int id)
        {
            try
            {
                string query = @"
                    SELECT AddressID, City, State, ZipCode, Country, Latitude, Longitude, IsActive
                    FROM Addresses
                    WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        return new Address
                        (
                            reader.GetInt32(reader.GetOrdinal("AddressID")),
                            reader.GetString(reader.GetOrdinal("City")),
                            reader.GetString(reader.GetOrdinal("State")),
                            reader.GetString(reader.GetOrdinal("ZipCode")),
                            reader.GetString(reader.GetOrdinal("Country")),
                            reader.GetDecimal(reader.GetOrdinal("Latitude")),
                            reader.GetDecimal(reader.GetOrdinal("Longitude")),
                            reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }
        }

        private static void AddDecimalParam(SqlCommand command, string name, decimal value)
        {
            var param = command.Parameters.Add(name, SqlDbType.Decimal);
            param.Precision = 9;
            param.Scale = 6;
            param.Value = value;
        }
    }
}