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
    class LightTests
    {
        Light light;
        [OneTimeSetUp]
        public void Init()
        {
            light = new Light(Color.Red);
        }

        [Test]
        public void Test_On()
        {
            light.On();
            light.GetState().Should().BeTrue();
        }

        [Test]
        public void Test_Off()
        {
            light.Off();
            light.GetState().Should().BeFalse();
        }

        [Test]
        public void Test_GetState()
        {
            light.On();
            light.GetState().Should().BeTrue();
            light.Off();
            light.GetState().Should().BeFalse();

        }


    }
}
