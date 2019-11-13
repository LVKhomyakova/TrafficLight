using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public class Battery : IBattery
    {
        bool _constPower;
        double _capacity = double.NaN;
        double _currentPower = double.NaN;
        public Battery()
        {
            _constPower = true;
        }
        public Battery(double power)
        {
            if (power>=0)
            {
                _constPower = false;
                _capacity = power;
                _currentPower = power;
            }
            else
                throw new ArgumentException("Заряд батареи должен может быть 0 и более.");
        }

        public double GetPower() => _currentPower;

        public void UsePower()
        {
            if(!_constPower)
                while (_currentPower > 0)
                    _currentPower -= 1;
        }

        public void FillBattery()
        {
            _currentPower = _capacity;
        }
    }
}
