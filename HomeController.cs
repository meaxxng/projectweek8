using System;

namespace OOP
{
    class HomeController
    {
        public void UpdateStatus(string deviceName, bool isOn)
        {
            Console.WriteLine($"{deviceName} is {(isOn ? "ON" : "OFF")}");
        }

        public void UpdateHairDryer(string deviceName, int heatLevel, int fanSpeed)
        {
            Console.WriteLine($"{deviceName} heat: {heatLevel}, fan speed: {fanSpeed}");
        }
    }
}