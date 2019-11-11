using System;
using System.Runtime.InteropServices;
using UnmanagedCode.PowerManagement.ComComponent.Configuration;
using UnmanagedCode.PowerManagement.ComComponent.Configuration.Models;
using UnmanagedCode.PowerManagement.Configuration.Structures;

namespace UnmanagedCode.PowerManagement.ComComponent
{
    [ComVisible(true)]
    [Guid("C024E387-26F3-4852-A3AF-7A4E52207FBB")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PMService : IPowerManagementService
    {
        private PowerManagementService _service;
        public PMService()
        {
            _service = new PowerManagementService();
        }

        public SystemPowerInformationModel GetSystemPowerInformation()
        {
            var info = _service.GetSystemPowerInformation();

            return new SystemPowerInformationModel {
                CoolingMode = info.CoolingMode,
                Idleness = info.Idleness,
                MaxIdlenessAllowed = info.MaxIdlenessAllowed,
                TimeRemaining = info.TimeRemaining
            };
        }

        public SystemBatteryStateModel GetSystemBatteryState()
        {
            var info = _service.GetSystemBatteryState();

            return new SystemBatteryStateModel {
                AcOnLine = info.AcOnLine,
                BatteryPresent = info.BatteryPresent,
                Charging = info.Charging,
                DefaultAlert2 = info.DefaultAlert2,
                DefaultAlter1 = info.DefaultAlter1,
                Discharging = info.Discharging,
                EstimatedTime = info.EstimatedTime,
                MaxCapacity = info.MaxCapacity,
                Rate = info.Rate,
                RemainingCapacity = info.RemainingCapacity
            };
        }

        public int GetWakeTime()
        {
            return _service.GetWakeTime();
        }

        public int GetSleepTime()
        {
            return _service.GetSleepTime();
        }

        public bool DeleteFile()
        {
            return _service.DeleteFile();
        }

        public bool ReserveFile()
        {
            return _service.ReserveFile();
        }

        public void SuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent)
        {
           _service.SuspendState(hibernate, forceCritical, disableWakeEvent);
        }
    }
}
