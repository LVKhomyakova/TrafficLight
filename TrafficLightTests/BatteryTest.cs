using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;
using FluentAssertions;
using Moq;
using TrafficLightLib;


namespace TrafficLightTests
{
    [TestFixture]
    class BatteryTest
    {
        Battery battery;

        [TestCase(100, 100)]
        [TestCase(0, 0)]
        public void Test_GetPower(double power, double expected)
        {
            battery = new Battery(power);
            battery.GetPower().Should().Be(expected);
        }

        [TestCase(100, 100)]
        public void Test_FillBattery(double power, double expected)
        {
            battery = new Battery(power);
            battery.UsePower();
            battery.FillBattery();
            battery.GetPower().Should().Be(expected);
        }

        [TestCase(5, 0)]
        public void Test_UsePower(double power, double expected)
        {
            battery = new Battery(power);
            battery.UsePower();
            battery.GetPower().Should().Be(expected);
        }

    }
}
