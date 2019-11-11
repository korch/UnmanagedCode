using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnmanagedCode.PowerManagement.Configuration.Structures;

namespace UnmanagedCode.PowerManagement.Configuration
{
    internal class PowerManagementConfiguration
    {
        //for system power information
        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int InformationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SystemPowerInformation spi,
            int nOutputBufferSize
            );

        // for system battery information
        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
           int InformationLevel,
           IntPtr lpInputBuffer,
           int nInputBufferSize,
           out SystemBatteryState sbs,
           int nOutputBufferSize
           );

        // for last sleep and wake time information
        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
           int InformationLevel,
           IntPtr lpInputBuffer,
           int nInputBufferSize,
           out long time,
           uint nOutputBufferSize
           );
    }
}
