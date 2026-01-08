using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using VelocityRent_Utilities;

namespace Velocity_Rent_DAL
{
    public static class SystemSettingDAL
    {
        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["VelocityRentDB"].ConnectionString;
        public static SqlConnection GetConnection() => new SqlConnection(_ConnectionString);
        public static string GetSettingValue(string settingName)
        {
            string value = null;
            string query = @"SELECT SettingValue FROM SystemSettings WHERE SettingName = @SettingName;";

            try
            {
                using (SqlConnection connection = GetConnection())
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
                Logger.ErrorLog($"[GetSettingValue] {ex}");
            }

            return value;
        }
        public static bool UpdateSettingValue(string settingName, string newValue)
        {
            string query = @"UPDATE SystemSettings SET SettingValue = @Value WHERE SettingName = @SettingName;";

            try
            {
                using (SqlConnection connection = GetConnection())
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
                Logger.ErrorLog($"[UpdateSettingValue] {ex}");
                return false;
            }
        }
        public static bool IsWizardSetupCompleted()
        {
            try
            {
                string value = GetSettingValue("SetupCompleted");

                if(string.IsNullOrEmpty(value)) return false;
                return (value.ToLower() == "yes");
            }
            catch(Exception ex) 
            {
                Logger.ErrorLog($"[IsWizardSetupCompleted] {ex}");
                return false;
            }
        }
        public static void MarkWizardSetupAsCompleted()
        {
            UpdateSettingValue("SetupCompleted", "yes");
        }
    }
}
