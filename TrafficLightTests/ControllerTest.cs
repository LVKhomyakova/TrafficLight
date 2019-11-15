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
    class ControllerTest
    {
        Сontroller controller;

        [OneTimeSetUp]
        public void Init()
        {
            controller = new Сontroller();

            //controller = new Сontroller(new TrafficLight(new Battery(100)));
        }

        [TestCase("Red")]
        public void Test_AddCommand(string name)
        {
            int countBefore = controller.Modes[name].Count;
            Command command = new Command(LightAction.On, Color.Red, 3000);

            controller.AddCommand(name, command);
            controller.Modes[name].Should().NotBeNullOrEmpty();
            controller.Modes[name].Count.Should().Be(++countBefore);
        }

        [TestCase("Red")]
        public void Test_DeleteCommand(string name)
        {
            Command command = new Command(LightAction.On, Color.Red, 3000);
            controller.AddCommand(name, command);
            int countBefore = controller.Modes[name].Count;

            controller.DeleteCommand(name, 0);
            controller.Modes[name].Count.Should().Be(--countBefore);
        }

        [TestCase("Green")]
        public void Test_AddMode(string name)
        {
            int countBefore = controller.Modes.Count;
            List<Command> commands = new List<Command>()
                        {
                            {new Command(LightAction.On, Color.Green, 5000 ) },
                            {new Command(LightAction.Off, Color.Green, 0 ) }
                        };

            controller.AddMode(name, commands);
            controller.Modes.Should().ContainKey(name);
            controller.Modes.Count.Should().Be(++countBefore);
        }

        [TestCase("Green")]
        public void Test_DeleteMode(string name)
        {
            List<Command> commands = new List<Command>()
                        {
                            {new Command(LightAction.On, Color.Green, 5000 ) },
                            {new Command(LightAction.Off, Color.Green, 0 ) }
                        };
            controller.AddMode(name, commands);
            int countBefore = controller.Modes.Count;

            controller.DeleteMode(name);
            controller.Modes.Should().NotContainKey(name);
            controller.Modes.Count.Should().Be(--countBefore);
        }
        /*
        [Test]
        public void Test_RunTrafficLight()
        {
            controller = new Сontroller();
//            controller = new Сontroller(new TrafficLight(new Battery(100)));

            List<Command> commands = new List<Command>()
                        {
                            {new Command(LightAction.On, Color.Red, 500 ) },
                            {new Command(LightAction.On, Color.Yellow, 200 ) },
                            {new Command(LightAction.Off, Color.Red, 0 ) },
                            {new Command(LightAction.Off, Color.Yellow, 0 ) },
                            {new Command(LightAction.On, Color.Green, 0 ) },
                        };            
            controller.AddMode("Standart", commands);

            Thread myThread = new Thread(new ThreadStart(() =>
                { controller.RunTrafficLight("Standart"); } ));
            myThread.Start();

            Thread.Sleep(200);
            controller.TrafficLight.Lights
                .First(l => l.Color == Color.Red)
                .GetState()
                .Should().BeTrue();

            Thread.Sleep(700);
            controller.TrafficLight.Lights
                .First(l => l.Color == Color.Green)
                .GetState()
                .Should().BeTrue();
        }*/
    }
}
