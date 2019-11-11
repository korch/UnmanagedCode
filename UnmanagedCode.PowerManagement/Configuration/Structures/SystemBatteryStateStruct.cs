using System;
using System.Collections.Generic;
using System.Text;

namespace UnmanagedCode.PowerManagement.Configuration.Structures
{
    public struct SystemBatteryState
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public bool Spare1;
        public byte Tag;
        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;
        public uint DefaultAlter1;
        public uint DefaultAlert2;
    }
}
