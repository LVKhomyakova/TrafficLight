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
        public LightAction GetAction() => _action;
        public Color GetColor() => _color;
        public int GetActionTime() => _actionTime;
    }
}