using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UnmanagedCode.PowerManagement.ComComponent.Configuration.Models
{
    [ComVisible(true)]
    public class SystemPowerInformationModel
    { 
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;

        public override string ToString()
        {
            return
                $"System power information model: MaxIdlenessAllowed: {MaxIdlenessAllowed} | Idleness: {Idleness} | TimeRemaining: {TimeRemaining} | CoolingMode: {CoolingMode}";
        }
    }
}
