using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityRent.Entities;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL
{
    public static class AddressRepository
    {
        public static int InsertAddress(Address address)
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
                    command.Parameters.Add("@Latitude", SqlDbType.Decimal).Value = address.Latitude;
                    command.Parameters.Add("@Longitude", SqlDbType.Decimal).Value = address.Longitude;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;

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
        public static bool UpdateAddress(Address address)
        {
            int rowsAffected = 0;
            try
            {
                string qurry = @"UPDATE Addresses
                       SET City = @City , State = @State, ZipCode = @ZipCode, Country = @Country, Latitude = @Latitude, Longitude = @Longitude, IsActive = @IsActive
                       WHERE ID = @ID";

                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(qurry, connection))
                {
                    command.Parameters.Add("@ID", SqlDbType.Int).Value = address.ID;
                    command.Parameters.Add("@City", SqlDbType.NVarChar).Value = address.City;
                    command.Parameters.Add("@State", SqlDbType.NVarChar).Value = address.State;
                    command.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = address.ZipCode;
                    command.Parameters.Add("@Country", SqlDbType.NVarChar).Value = address.Country;
                    command.Parameters.Add("@Latitude", SqlDbType.Decimal).Value = address.Latitude;
                    command.Parameters.Add("@Longitude", SqlDbType.Decimal).Value = address.Longitude;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = address.IsActive;

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return false;
            }

            return rowsAffected > 0;
        }
    }
}
