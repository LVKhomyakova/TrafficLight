using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrafficLightLib
{
    public interface IBattery
    {
        double GetPower();
        void UsePower();
        void FillBattery();
    }
}
