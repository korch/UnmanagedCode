using System;
using System.Collections.Generic;
using System.Text;

namespace UnmanagedCode.PowerManagement.Configuration
{
    /// <summary>
    /// Information level params to getting specific data from CallNtPowerInformation method
    /// </summary>
    public class InformationLevelConstants
    {
        public const int SYSTEM_BATTERY_STATE = 5;
        public const int SYSTEM_RESERVE_HIBER_FILE = 10;
        public const int SYSTEM_POWER_INFORMATION = 12;
        public const int LAST_WAKE_TIME = 14;
        public const int LAST_SLEEP_TIME = 15;

        public const uint STATUS_SUCCESS = 0;
    }
}
