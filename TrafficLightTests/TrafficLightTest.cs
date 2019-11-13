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
    public class TrafficLightTest
    {
        TrafficLight _trafficLight;
        Mock<IBattery> mock;

        [OneTimeSetUp]
        public void Init()
        {
            mock = new Mock<IBattery>();
            mock.Setup(b => b.GetPower()).Returns(100);
            IBattery battery = mock.Object;
            _trafficLight = new TrafficLight(battery); ;
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        public void Test_RunTrafficLight(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object);

            _trafficLight.RunTrafficLight();
            _trafficLight.GetStatusOn().Should().Be(expected);
        }

        [TestCase(false)]
        public void Test_StopTrafficLight(bool expected)
        {
            _trafficLight = new TrafficLight(mock.Object);
            _trafficLight.StopTrafficLight();
            _trafficLight.GetStatusOn().Should().Be(expected);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        public void Test_GetStatusOn(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object);
            _trafficLight.GetStatusOn().Should().Be(expected);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        public void Test_LightOn(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object);

            _trafficLight.LightOn(Color.Red);
            _trafficLight.Lights.Where(l => l.Color == Color.Red).First().GetState().Should().Be(expected);
        }
        [TestCase(100, false)]
        [TestCase(0, false)]
        public void Test_LightOff(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object);

            _trafficLight.LightOff(Color.Red);
            _trafficLight.Lights.Where(l => l.Color == Color.Red).First().GetState().Should().Be(expected);
        }
    }
}
