using System.Drawing;

namespace TrafficLightLib
{
    public class Light
    {
        public Color Color { get;}
        bool _stateOn;

        public Light(Color color)
        {
            Color = color;
            _stateOn = false;
        }

        public void On()
        {
            _stateOn = true;
        }
        public void Off()
        {
            _stateOn = false;
        }

        public bool GetState()
        {
            return _stateOn ? true : false;
        }
    }
}