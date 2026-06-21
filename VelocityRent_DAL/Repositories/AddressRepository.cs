using System;
using System.Data;
using System.Data.SqlClient;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL
{
    public  class AddressRepository : IAddressRepository
    {
        public  int Add(Address address)
        {
            int id = -1;
            try
            {
                string query = @"INSERT INTO Addresses (City, State, ZipCode, Country, Latitude, Longitude, IsActive)
                       VALUES (@City, @State, @ZipCode, @Country, @Latitude, @Longitude, @IsActive);
                       SELECT SCOPE_IDENTITY();";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                    command.Parameters.Add("@State", SqlDbType.NVarChar).Value = address.State;
                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode;
                    command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;

                    var latitudeParam = command.Parameters.Add("@Latitude", SqlDbType.Decimal);
                    latitudeParam.Precision = 9;
                    latitudeParam.Scale = 6;
                    latitudeParam.Value = address.Latitude;

                    var longitudeParam = command.Parameters.Add("@Longitude", SqlDbType.Decimal);
                    longitudeParam.Precision = 9;
                    longitudeParam.Scale = 6;
                    longitudeParam.Value = address.Longitude;

                    connection.Open();
                    object result = command.ExecuteScalar();
                    id = Convert.ToInt32(result);
                }
            }
            catch(Exception ex) 
            {
                Logger.Error(ex.ToString());
                return -1;
            }

            return id;
        }
        public  bool Update(Address address)
        {
            int rowsAffected = 0;
            try
            {
                string qurry = @"UPDATE Addresses
                       SET City = @City , State = @State, ZipCode = @ZipCode, Country = @Country, Latitude = @Latitude, Longitude = @Longitude, IsActive = @IsActive
                       WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(qurry, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = address.ID;
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                    command.Parameters.Add("@State", SqlDbType.NVarChar).Value = address.State;
                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode;
                    command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;

                    var latitudeParam = command.Parameters.Add("@Latitude", SqlDbType.Decimal);
                    latitudeParam.Precision = 9;
                    latitudeParam.Scale = 6;
                    latitudeParam.Value = address.Latitude;

                    var longitudeParam = command.Parameters.Add("@Longitude", SqlDbType.Decimal);
                    longitudeParam.Precision = 9;
                    longitudeParam.Scale = 6;
                    longitudeParam.Value = address.Longitude;

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }

            return rowsAffected > 0;
        }
        public bool Delete(int id)
        {
            int rowsAffected = 0;
            try
            {
                string qurry = @"DELETE FROM Addresses WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(qurry, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;


                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
                return false;
            }

            return rowsAffected > 0;
        }
        public Address GetByID(int id)
        {
            Address address = null;
            try
            {
                string qurry = @"SELECT * FROM Addresses WHERE AddressID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(qurry, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = id;


                    connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if(!reader.Read()) return null;
                       
                         address = new Address
                         (
                             reader.GetInt32(0),
                             reader.GetString(1),
                             reader.GetString(2),
                             reader.GetString(3),
                             reader.GetString(4),
                             reader.GetDecimal(5),
                             reader.GetDecimal(6),
                             reader.GetBoolean(7)
                         );
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }

            return address;
        }
    }
}
