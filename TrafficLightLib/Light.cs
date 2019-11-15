using System.Drawing;

namespace TrafficLightLib
{
    public class Light
    {
        bool _stateOn;

        public Light(Color color)
        {
            Color = color;
            _stateOn = false;
        }

        public Color Color { get;}
        /// <summary>
        /// Включить лампу
        /// </summary>
        public void On()
        {
            _stateOn = true;
        }
        /// <summary>
        /// Выключить лампу
        /// </summary>
        public void Off()
        {
            _stateOn = false;
        }
        /// <summary>
        /// Узнать состояние лампы (включена или выключена)
        /// </summary>
        /// <returns></returns>
        public bool GetState()
        {
            return _stateOn ? true : false;
        }
    }
}