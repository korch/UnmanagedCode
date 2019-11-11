using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnmanagedCode.PowerManagement.Configuration;
using UnmanagedCode.PowerManagement.Configuration.Structures;

namespace UnmanagedCode.PowerManagement
{

    public class PowerManagementService
    {
        /// <summary>
        /// Returns system power information data or null if data wasn't found
        /// </summary>
        /// <returns></returns>
        public SystemPowerInformation GetSystemPowerInformation()
        {
            SystemPowerInformation info;

            var action = PowerManagementConfiguration.CallNtPowerInformation(
             InformationLevelConstants.SYSTEM_POWER_INFORMATION,
             IntPtr.Zero,
             0,
             out info,
             Marshal.SizeOf(typeof(SystemPowerInformation)));

            return action == InformationLevelConstants.STATUS_SUCCESS ? info : throw new Win32Exception("oi oi oi !!!! bedaaaaaa ! ");
        }

        /// <summary>
        /// Returns system battery state information or null if data wasn't found
        /// </summary>
        /// <returns></returns>
        public SystemBatteryState GetSystemBatteryState()
        {
            SystemBatteryState info;

            var action = PowerManagementConfiguration.CallNtPowerInformation(
            InformationLevelConstants.SYSTEM_BATTERY_STATE,
            IntPtr.Zero,
            0,
            out info,
            Marshal.SizeOf(typeof(SystemBatteryState)));

            return action == InformationLevelConstants.STATUS_SUCCESS ? info : throw new Win32Exception("oi oi oi !!!! bedaaaaaa ! ");
        }

        /// <summary>
        /// Return wake time (in seconds) 
        /// </summary>
        /// <returns></returns>
        public int GetWakeTime()
        {
            return GetSleepOrWakeTime(InformationLevelConstants.LAST_WAKE_TIME);
        }

        /// <summary>
        /// Return sleep time (in seconds) 
        /// </summary>
        /// <returns></returns>
        public int GetSleepTime()
        {
            return GetSleepOrWakeTime(InformationLevelConstants.LAST_SLEEP_TIME);
        }


        public bool DeleteFile()
        {
            return  HibernateFileAction(HibernateFileActions.Delete);
        }

        public bool ReserveFile()
        {
            return HibernateFileAction(HibernateFileActions.Reserve);
        }

        /// <summary>
        /// Suspends the system by shutting power down.
        /// </summary>
        /// <param name="hibernate">If this parameter is TRUE, the system hibernates. If the parameter is FALSE, the system is suspended.</param>
        /// <param name="forceCritical">don't take an attantion on this parameter. He does nothing.</param>
        /// <param name="disableWakeEvent">If this parameter is TRUE, the system disables all wake events. If the parameter is FALSE, any system wake events remain enabled.</param>
        public void SuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent)
        {
            uint result = PowerManagementConfiguration.SetSuspendState(hibernate, forceCritical, disableWakeEvent);

            if (result == 0)
                throw new Win32Exception();
        }

        private bool HibernateFileAction(HibernateFileActions fileActions)
        {
            var intSize = Marshal.SizeOf<bool>();
            IntPtr intPtr = Marshal.AllocCoTaskMem(intSize);
            Marshal.WriteByte(intPtr, (byte)fileActions);

            var retval = PowerManagementConfiguration.CallNtPowerInformation(
                InformationLevelConstants.SYSTEM_RESERVE_HIBER_FILE,
                fileActions == HibernateFileActions.Reserve,
                Marshal.SizeOf<bool>(),
                IntPtr.Zero,
                0);

            return retval == InformationLevelConstants.STATUS_SUCCESS;
        }

        private int GetSleepOrWakeTime(int informationLevel)
        {
            long time = 0;

            var action = PowerManagementConfiguration.CallNtPowerInformation(
            informationLevel,
            IntPtr.Zero,
            0,
            out time,
            (uint)Marshal.SizeOf(typeof(long)));

            var epochTime = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return action == InformationLevelConstants.STATUS_SUCCESS ? epochTime.AddTicks(time / 100).Second : throw new Win32Exception("oi oi oi !!!! bedaaaaaa ! ");
        }
    } 
}
