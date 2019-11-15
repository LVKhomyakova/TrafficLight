using System.Drawing;

namespace TrafficLightLib
{
    public enum LightAction
    {
        On,
        Off
    }
    public class Command
    {
        LightAction _action;
        Color _color;
        int _actionTime;
        public Command(LightAction action, Color color, int actionTime)
        {
            _action = action;
            _color = color;
            _actionTime = actionTime;
        }
        /// <summary>
        /// Узнать команду: включить или выключить лампу
        /// </summary>
        /// <returns></returns>
        public LightAction GetAction() => _action;
        /// <summary>
        /// Узнать для какого цвета лампы выполнить команду
        /// </summary>
        /// <returns></returns>
        public Color GetColor() => _color;
        /// <summary>
        /// Узнать длительность выплнения команды
        /// </summary>
        /// <returns></returns>
        public int GetActionTime() => _actionTime;
    }
}