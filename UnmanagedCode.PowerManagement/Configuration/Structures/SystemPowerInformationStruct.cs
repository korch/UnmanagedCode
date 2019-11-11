using System;
using System.Collections.Generic;
using System.Text;

namespace UnmanagedCode.PowerManagement.Configuration.Structures
{
    public struct SystemPowerInformation
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;
    }
}
