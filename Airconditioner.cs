using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class AirConditioner : ISwitchControl, ITemperatureControl
    {
        bool _isOn = false;
        private int _targetTemp = 25;
        private int _currentTemp = 30;

        public bool isOn { get => _isOn; set => _isOn = value; }

        public int TargetTemperature { get => _targetTemp; set => _targetTemp = value; }

        public int CurrentTemperture => _currentTemp;

        public readonly int _MinTemperture = 18;
        public readonly int _MaxTemperture = 30; // เป็นค่าคงที่เหมือนกัน แต่ทำงานในระดับ RunTime ค่าที่ต้องการคำนวณก่อน

        public int MinTemperature => _MinTemperture;

        public int MaxTemperature => _MaxTemperture;

        public int GetCurrentTemperature()
        {
            if (isOn)
            {
                if (_currentTemp > _targetTemp)
                    _currentTemp--;
                else if (_currentTemp < _targetTemp)
                    _currentTemp++;
            }
            return _currentTemp;
        }

        public void SetTemperature(int degress)
        {
            if (isOn)
            {
                _targetTemp = Math.Max(MinTemperature, Math.Min(degress, MaxTemperature));
                Console.WriteLine("Target temperature set to : " + _targetTemp + "C");
            }
            else
            {
                Console.WriteLine("is off");
            }
        }
        public void TurnOff()
        {
            ToggleSwitch();
        }

        public void TurnOn()
        {
            ToggleSwitch();
        }

        void ToggleSwitch()
        {
            isOn = !isOn;
            // if (isOn == false)
            // {
            //     Console.WriteLine("is off");
            // }
            // else {
            //     Console.WriteLine("is on");
            // }
            string result = (isOn) ? "is on" : "is off";
            Console.WriteLine(result);
        }
    }
}

