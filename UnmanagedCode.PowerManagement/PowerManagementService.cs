using System;
using System.Runtime.InteropServices;
using UnmanagedCode.PowerManagement.Configuration;
using UnmanagedCode.PowerManagement.Configuration.Structures;

namespace UnmanagedCode.PowerManagement
{
    public class PowerManagementService
    {
        public SystemPowerInformation GetSystemPowerInformation()
        {
            SystemPowerInformation info;

                PowerManagementConfiguration.CallNtPowerInformation(
                InformationLevelConstants.SYSTEM_POWER_INFORMATION,
                IntPtr.Zero,
                0,
                out info,
                Marshal.SizeOf(typeof(SystemPowerInformation)));

            return info;
        }

        public SystemBatteryState GetSystemBatteryState()
        {
            SystemBatteryState info;

            PowerManagementConfiguration.CallNtPowerInformation(
            InformationLevelConstants.SYSTEM_BATTERY_STATE,
            IntPtr.Zero,
            0,
            out info,
            Marshal.SizeOf(typeof(SystemBatteryState)));

            return info;
        }

        public int GetSleepOrWakeTime(int informationLevel)
        {
            long time = 0;

            PowerManagementConfiguration.CallNtPowerInformation(
            informationLevel,
            IntPtr.Zero,
            0,
            out time,
            (uint)Marshal.SizeOf(typeof(long)));

            var epochTime = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epochTime.AddTicks(time / 100).Second;
        }
    }
}
