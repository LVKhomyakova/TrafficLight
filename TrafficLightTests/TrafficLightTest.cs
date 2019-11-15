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
using System.Threading;

namespace TrafficLightTests
{
    [TestFixture]
    public class TrafficLightTest
    {

        TrafficLight _trafficLight;
        Mock<IBattery> mock;
        Mock<IController> mockController;
        IBattery battery;
        IController controller;

        [OneTimeSetUp]
        public void Init()
        {
            //mock for IBattery
            mock = new Mock<IBattery>();
            mock.Setup(b => b.GetPower()).Returns(100);
            battery = mock.Object;

            //mock for IController
            mockController = new Mock<IController>();
            mockController.SetupGet(c => c.Modes).Returns(
            new Dictionary<string, List<Command>>()
            {
                {"Red", new List<Command>()
                        {
                            { new Command(LightAction.On, Color.Red, 1 ) }
                        }
                }
            });
            controller = mockController.Object;
        }
        [TestCase(false)]
        public void Test_StopTrafficLight(bool expected)
        {
            _trafficLight = new TrafficLight(mock.Object, controller);
            _trafficLight.StopTrafficLight();
            _trafficLight.GetStatusOn().Should().Be(expected);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        public void Test_GetStatusOn(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object,controller);

            _trafficLight.GetStatusOn().Should().Be(expected);
        }

        [TestCase(100, true)]
        [TestCase(0, false)]
        public void Test_LightOn(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object, controller);

            _trafficLight.LightOn(Color.Red);
            _trafficLight.Lights.Where(l => l.Color == Color.Red).First().GetState().Should().Be(expected);
        }
        [TestCase(100, false)]
        [TestCase(0, false)]
        public void Test_LightOff(double power, bool expected)
        {
            mock.Setup(b => b.GetPower()).Returns(power);
            _trafficLight = new TrafficLight(mock.Object, controller);

            _trafficLight.LightOff(Color.Red);
            _trafficLight.Lights.Where(l => l.Color == Color.Red).First().GetState().Should().Be(expected);
        }

        [Test]
        public void Test_RunTrafficLight()
        {
            mock.Setup(b => b.GetPower()).Returns(100);
            _trafficLight = new TrafficLight(mock.Object, controller);

            Thread myThread = new Thread(new ThreadStart(() =>
                { _trafficLight.RunTrafficLight("Red"); }));
            myThread.Start();

            Thread.Sleep(50);
            _trafficLight.Lights
                .First(l => l.Color == Color.Red)
                .GetState()
                .Should().BeTrue();
        }
    }
}
