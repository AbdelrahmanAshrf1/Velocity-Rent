using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityRent_Utilities
{
    public static class RegistryHelper
    {
        private const string BasePath = @"Software\VelocityRent";

        // Save a value in the registry (auto creates subkey if missing)
        public static void SetValue<T>(string subKey, string valueName, T value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey($"{BasePath}\\{subKey}"))
                {
                    key.SetValue(valueName, value);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error setting registry value : {ex.Message}");
            }
        }
        public static T GetValue<T>(string subKey, string valueName, T defaultValue = default)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey($"{BasePath}\\{subKey}"))
                {
                    if (key == null) return defaultValue;
                    object value = key.GetValue(valueName, defaultValue);
                    if (value is T typedValue) return typedValue;
                    return (T)value;
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error Getting registry value : {ex.Message}");
                return defaultValue;
            }
        }
        public static void DeleteValue(string subKey,string valueName)
        {
            try
            {
                using(RegistryKey key = Registry.CurrentUser.OpenSubKey($"{BasePath}\\{subKey}"))
                {
                    key?.DeleteValue(valueName, false);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error Deleting registry value : {ex.Message}");
            }
        }
        public static void DeleteSubKey(string subKey)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree($"{BasePath}\\{subKey}", false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Deleting registry key: {ex.Message}");
            }
        }
        public static bool IsKeyExists(string subKey)
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey($"{BasePath}\\{subKey}"))
            {
                return key != null;
            }
        }
        public static bool IsValueExists(string subKey,string valueName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey($"{BasePath}\\{subKey}"))
            {
                return key?.GetValue(valueName) != null;
            }
        }
    }
}