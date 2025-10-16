using System;

namespace OOP
{
    class HairDryer : ISwitchControl
    {
        private bool _isOn = false;
        private int _heatLevel = 1;    // 1-5
        private int _fanSpeed = 1;     // 1-3

        private readonly int MinHeat = 1;
        private readonly int MaxHeat = 5;
        private readonly int MinFan = 1;
        private readonly int MaxFan = 3;

        private HomeController _controller;

        public HairDryer(HomeController controller)
        {
            _controller = controller;
        }

        public bool isOn
        {
            get => _isOn;
            set => _isOn = value;
        }

        public void TurnOn()
        {
            _isOn = true;
            _controller.UpdateStatus("HairDryer", _isOn);
            _controller.UpdateHairDryer("HairDryer", _heatLevel, _fanSpeed);
        }

        public void TurnOff()
        {
            _isOn = false;
            _controller.UpdateStatus("HairDryer", _isOn);
        }

        // ปรับความร้อน
        public void SetHeatLevel(int level)
        {
            if (!_isOn)
            {
                Console.WriteLine("HairDryer is OFF, cannot adjust heat");
                return;
            }

            _heatLevel = Math.Max(MinHeat, Math.Min(level, MaxHeat));
            _controller.UpdateHairDryer("HairDryer", _heatLevel, _fanSpeed);
        }

        // ปรับความแรงลม
        public void SetFanSpeed(int speed)
        {
            if (!_isOn)
            {
                Console.WriteLine("HairDryer is OFF, cannot adjust fan speed");
                return;
            }

            _fanSpeed = Math.Max(MinFan, Math.Min(speed, MaxFan));
            _controller.UpdateHairDryer("HairDryer", _heatLevel, _fanSpeed);
        }
    }
}