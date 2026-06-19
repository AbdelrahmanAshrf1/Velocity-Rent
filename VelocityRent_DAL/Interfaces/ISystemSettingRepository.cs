using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velocity_Rent_DAL.Interfaces
{
    public interface ISystemSettingRepository
    {
        string GetSettingValue(string settingName);
        bool UpdateSettingValue(string settingName, string newValue);
        bool IsWizardSetupCompleted();
        void MarkWizardSetupAsCompleted();
    }
}
