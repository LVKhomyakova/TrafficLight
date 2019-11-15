using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public interface IController
    {
        Dictionary<string, List<Command>> Modes { get; }
        void AddCommand(string name, Command command);
        void DeleteCommand(string name, int index);
        void AddMode(string name, List<Command> commands);
        void DeleteMode(string name);
    }
}
