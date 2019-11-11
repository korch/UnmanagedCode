using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnmanagedCode.PowerManagement;
using UnmanagedCode.PowerManagement.Configuration;

namespace Tests
{
    [TestFixture]
    public class PowerManagementServiceTests
    {
        private PowerManagementService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PowerManagementService();
        }

        [Test]
        public void GetSystemPowerInformationTest()
        {
            var info = _service.GetSystemPowerInformation();

            Assert.IsNotNull(info);
            Assert.IsTrue(info.Idleness > 0);
            Assert.IsTrue(info.TimeRemaining > 0);
        }

        [Test]
        public void GetSystemBatteryStateTest()
        {
            var info = _service.GetSystemBatteryState();

            // false, because it tests on PC (not on Notebook)
            Assert.IsNotNull(info);
            Assert.IsFalse(info.BatteryPresent);
         
        }


        [Test]
        public void GetWakeTimeTest()
        {
            var wakeTime = _service.GetWakeTime();

            // false, because it tests on PC (not on Notebook)
            Assert.IsTrue(wakeTime > 0);
        }


        [Test]
        public void GetSleepTimeTest()
        {
            var sleepTime = _service.GetSleepTime();

            // false, because it tests on PC (not on Notebook)
            Assert.IsTrue(sleepTime > 0);
        }

   
        [Test]
        public void ReserveFileTest()
        {
            var result = _service.ReserveFile();

           Assert.IsTrue(result);
        }

        [Test]
        public void DeleteFileTest()
        {
            var result = _service.DeleteFile();

            Assert.IsTrue(result);
        }
    }
}