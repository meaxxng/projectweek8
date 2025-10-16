using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Fridge : ITemperatureControl
    {
        private int _targetTemp = 4;
        private int _currentTemp = 25;

        private const int MIN_Fridge_Temp = 1;
        private const int MAX_Fridge_Temp = 7; //constant (ค่าคงที่) ไม่สามารถถูกเปลี่ยนแปลงได้เลยตลอดการใช้งาน

        public int TargetTemperature
        {
            get => _targetTemp;
            set => _targetTemp = value;
        }

        public int CurrentTemperture
        {
            get => _currentTemp;
            set => _currentTemp = value;
        }

        public int MinTemperature => MIN_Fridge_Temp;

        public int MaxTemperature => MAX_Fridge_Temp;

        public int GetCurrentTemperature()
        {
            if (_currentTemp > _targetTemp)
            {
                _currentTemp--;
            }
            else if (_currentTemp < 25)
            {
                _currentTemp++;
            }
            Console.WriteLine("current temperature : " + _currentTemp);
            return _currentTemp;
        }

        public void SetTemperature(int degress)
        {
            _currentTemp = Math.Max(MIN_Fridge_Temp, Math.Min(degress, MAX_Fridge_Temp));
            Console.WriteLine("current temperature : " + _currentTemp);
        }
    }

}
