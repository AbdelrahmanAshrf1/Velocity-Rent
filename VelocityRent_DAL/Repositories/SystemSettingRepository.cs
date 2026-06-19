using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL
{
    public  class SystemSettingRepository : ISystemSettingRepository
    {
        public  string GetSettingValue(string settingName)
        {
            string value = null;
            string query = @"SELECT SettingValue FROM SystemSettings WHERE SettingName = @SettingName;";

            try
            {
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@SettingName",SqlDbType.NVarChar).Value = settingName;
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value) value = result.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"[GetSettingValue] {ex}");
                return null;
            }

            return value;
        }
        public  bool UpdateSettingValue(string settingName, string newValue)
        {
            string query = @"UPDATE SystemSettings SET SettingValue = @Value WHERE SettingName = @SettingName;";

            try
            {
                using (SqlConnection connection = DbConnectionFactory.CreateConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Value", SqlDbType.NVarChar).Value = newValue ?? (object)DBNull.Value;
                    command.Parameters.Add("@SettingName", SqlDbType.NVarChar).Value = settingName;

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"[UpdateSettingValue] {ex}");
                return false;
            }
        }
        public  bool IsWizardSetupCompleted() => string.Equals(GetSettingValue("SetupCompleted"),"yes",StringComparison.OrdinalIgnoreCase);
        public  void MarkWizardSetupAsCompleted() => UpdateSettingValue("SetupCompleted", "yes");
    }
}
