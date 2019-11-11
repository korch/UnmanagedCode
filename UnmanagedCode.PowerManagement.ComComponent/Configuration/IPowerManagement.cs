using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnmanagedCode.PowerManagement.Configuration.Structures;

namespace UnmanagedCode.PowerManagement.ComComponent.Configuration
{
    [ComVisible(true)]
    [ComImport, Guid("993dc77f-bbd4-453a-93eb-409fa51b0f94")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPowerManagementService
    {
        SystemPowerInformation GetSystemPowerInformation();
        SystemBatteryState GetSystemBatteryState();
        int GetWakeTime();
        int GetSleepTime();
        bool DeleteFile();
        bool ReserveFile();
        void SuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
    }
}
