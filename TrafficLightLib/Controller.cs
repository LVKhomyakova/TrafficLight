using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrafficLightLib
{
    public class Сontroller
    {
        public Dictionary<string, List<Command>> Modes { get; set; }
        public TrafficLight TrafficLight { get; }
        public Сontroller(TrafficLight trafficLight)
        {
            TrafficLight = trafficLight;
            Modes = new Dictionary<string, List<Command>>()
            {
                {"Red", new List<Command>()
                        {
                            {new Command(LightAction.On, Color.Red, 2000 ) },
                            {new Command(LightAction.Off, Color.Red, 0 ) }
                        }
                }
            };
        }

        public void AddCommand(string name, Command command)
        {
            if (!Modes.ContainsKey(name))
                Modes.Add(name,new List<Command>());
            Modes[name].Add(command);
        }
        public void DeleteCommand(string name, int index)
        {
            if (Modes.ContainsKey(name))
                if (index >= Modes[name].Count) throw new IndexOutOfRangeException();
            if (Modes[name].Count > 0)
                Modes[name].RemoveAt(index);
        }

        public void AddMode(string name, List<Command> commands)
        {
            if (!Modes.ContainsKey(name))
                Modes.Add(name, commands);
        }

        public void DeleteMode(string name)
        {
            Modes.Remove(name);
        }

        public void RunTrafficLight(string nameMode)
        {
            foreach (var command in Modes[nameMode])
            {
                var currentLight = TrafficLight.Lights
                    .First(l => l.Color == command.GetColor());
                if (command.GetAction() == LightAction.On)
                    currentLight.On();
                else
                    currentLight.Off();
                int actionTime = command.GetActionTime();
                Thread.Sleep(actionTime);

               // Timer timer = new Timer((obj)=> { });
            }
        }
    }
}
