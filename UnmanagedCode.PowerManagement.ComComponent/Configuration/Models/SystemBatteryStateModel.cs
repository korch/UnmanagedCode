using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UnmanagedCode.PowerManagement.ComComponent.Configuration.Models
{
    [ComVisible(true)]
    public class SystemBatteryStateModel
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

        public override string ToString()
        {  
            return $@"SystemBatteryStateModel: AcOnLine: {AcOnLine} | BatteryPresent: {BatteryPresent} | Charging: {Charging} Discharging: {Discharging} | Spare1:{Spare1} |  Tag:{Tag} |  
                   MaxCapacity: {MaxCapacity} | RemainingCapacity:{RemainingCapacity} | Rate:{Rate} | EstimatedTime:{EstimatedTime} | DefaultAlter1: {DefaultAlter1} | DefaultAlter2:{DefaultAlert2}";
        }
    }
}
