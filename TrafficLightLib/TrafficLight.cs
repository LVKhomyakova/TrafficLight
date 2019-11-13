using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace TrafficLightLib
{
    public class TrafficLight
    {
        public IBattery Battery { get; set; }
        public List<Light> Lights { get; set; }
        bool _statusOn;
        public TrafficLight(IBattery battery)
        {
            Battery = battery;
            RunTrafficLight();
            _statusOn = Battery.GetPower()==0? false : true;
            Lights = new List<Light>()
            {
                new Light(Color.Red),
                new Light(Color.Yellow),
                new Light(Color.Green)
            };
        }


        public void RunTrafficLight()
        {
            //Thread usePower = new Thread();
        }
        public void StopTrafficLight()
        {
            _statusOn = false;
        }
        public bool GetStatusOn() => _statusOn;
        
        public void LightOn(Color color)
        {
            if (_statusOn)
            {
                Lights.Where(l => l.Color == color).First().On();
            }
            else
                ResetLights();
        }
        public void LightOff(Color color)
        {
            if (_statusOn)
            {
                Lights.Where(l => l.Color == color).First().Off();
            }
            else
                ResetLights();
        }


        double? CheckPower() => Battery.GetPower();
        void ResetLights()
        {
            foreach (var item in Lights)
            {
                item.Off();
            }
        }
    }
}
