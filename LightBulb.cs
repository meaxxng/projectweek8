using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class LightBulb : ISwitchControl
    {
        private bool _isOn = false;
        public bool isOn
        {
            get { return _isOn; }
            set { _isOn = value; }
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Light bulb turned OFF. It's dark.");
        }

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Light bulb turned ON! It's bright.");
        }
    }
}

