using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrafficLightLib
{
    public class Сontroller : IController
    {
        public Сontroller()
        {
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
        public Dictionary<string, List<Command>> Modes { get;}
        /// <summary>
        /// Добавить команду в определенный режим
        /// </summary>
        /// <param name="name">Название режима</param>
        /// <param name="command">Добавляема команда</param>
        public void AddCommand(string name, Command command)
        {
            if (!Modes.ContainsKey(name))
                Modes.Add(name,new List<Command>());
            Modes[name].Add(command);
        }
        /// <summary>
        /// Удалить команду из режима
        /// </summary>
        /// <param name="name">Название режима</param>
        /// <param name="index">Индекс в списке команд, для удаления</param>
        public void DeleteCommand(string name, int index)
        {
            if (Modes.ContainsKey(name))
                if (index >= Modes[name].Count) throw new IndexOutOfRangeException();
            if (Modes[name].Count > 0)
                Modes[name].RemoveAt(index);
        }
        /// <summary>
        /// Добавить режим
        /// </summary>
        /// <param name="name">Название режима</param>
        /// <param name="commands">Список команд для добавления</param>
        public void AddMode(string name, List<Command> commands)
        {
            if (!Modes.ContainsKey(name))
                Modes.Add(name, commands);
        }
        /// <summary>
        /// Удалить режим, со всеми командами в нем
        /// </summary>
        /// <param name="name">Название режима для удаления</param>
        public void DeleteMode(string name)
        {
            Modes.Remove(name);
        }
    }
}
