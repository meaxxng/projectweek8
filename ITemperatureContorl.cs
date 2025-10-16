using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal interface ITemperatureContorl
    {
        int TargetTemperature { get; set; }

        int CurrentTemperture { get;}

        int MinTemperature { get;}
        int MaxTemperature { get;}

        void SetTemperature(int degress);

        int GetCurrentTemperture();
    }
}
