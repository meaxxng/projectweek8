using System;
using System.Collections.Generic;

// ==================== Interfaces ====================

// เปิด/ปิดอุปกรณ์
interface ISwitchController
{
    bool isOn { get; }
    void TurnOn();
    void TurnOff();
}

// อุปกรณ์ควบคุมอุณหภูมิ
interface ITemperatureControl
{
    int CurrentTemperature { get; }
    int TargetTemperature { get; }
    void SetTemperature(int target);
    void GetCurrentTemperature();
}

// ไดร์เป่าผม: ปรับความร้อน
interface IHeatControl
{
    int HeatLevel { get; set; }
    void SetHeatLevel(int level);
}

// ไดร์เป่าผม: ปรับแรงลม
interface IFanControl
{
    int FanSpeed { get; set; }
    void SetFanSpeed(int speed);
}

// ==================== Base Devices ====================

class Computer : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public void TurnOn() => isOn = true;
    public void TurnOff() => isOn = false;
}

class Microwave : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public void TurnOn() => isOn = true;
    public void TurnOff() => isOn = false;
}

class HotTub : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public List<string> Flavors { get; private set; }
    public HotTub(List<string> flavors) { Flavors = flavors; }
    public void TurnOn() => isOn = true;
    public void TurnOff() => isOn = false;
}

class Fridge : ITemperatureControl
{
    public int CurrentTemperature { get; private set; } = 25;
    public int TargetTemperature { get; private set; } = 5;

    public void SetTemperature(int target) => TargetTemperature = target;

    public void GetCurrentTemperature()
    {
        if (CurrentTemperature > TargetTemperature) CurrentTemperature--;
        Console.WriteLine("Fridge temp: " + CurrentTemperature);
    }
}

class AirConditioner : ISwitchController, ITemperatureControl
{
    public bool isOn { get; private set; } = false;
    public int CurrentTemperature { get; private set; } = 30;
    public int TargetTemperature { get; private set; } = 22;

    public void TurnOn() => isOn = true;
    public void TurnOff() => isOn = false;
    public void SetTemperature(int target) => TargetTemperature = target;

    public void GetCurrentTemperature()
    {
        if (CurrentTemperature > TargetTemperature) CurrentTemperature--;
        Console.WriteLine("AirConditioner temp: " + CurrentTemperature);
    }
}

// ==================== HairDryer ====================

class HairDryer : ISwitchController, IHeatControl, IFanControl
{
    private bool _isOn = false;
    private int _heatLevel = 1; // 1-5
    private int _fanSpeed = 1;  // 1-3

    public bool isOn => _isOn;
    public int HeatLevel { get => _heatLevel; set => SetHeatLevel(value); }
    public int FanSpeed { get => _fanSpeed; set => SetFanSpeed(value); }

    public void TurnOn() { _isOn = true; Console.WriteLine("HairDryer is ON"); }
    public void TurnOff() { _isOn = false; Console.WriteLine("HairDryer is OFF"); }

    public void SetHeatLevel(int level)
    {
        if (_isOn)
        {
            _heatLevel = Math.Max(1, Math.Min(level, 5));
            Console.WriteLine("HairDryer heat level: " + _heatLevel);
        }
        else Console.WriteLine("HairDryer is OFF, cannot adjust heat");
    }

    public void SetFanSpeed(int speed)
    {
        if (_isOn)
        {
            _fanSpeed = Math.Max(1, Math.Min(speed, 3));
            Console.WriteLine("HairDryer fan speed: " + _fanSpeed);
        }
        else Console.WriteLine("HairDryer is OFF, cannot adjust fan");
    }
}

// ==================== Food ====================

abstract class Food
{
    public string Name { get; set; } = "";        // กำหนด default เป็น empty string
    public string Description { get; set; } = ""; // กำหนด default เป็น empty string
    public abstract void Eat();
    public abstract void Prepare();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Food: {Name}, Description: {Description}");
    }
}

class Pizza : Food
{
    public int Calories { get; set; }
    public string Size { get; set; }
    public List<string> Toppings { get; set; }

    public Pizza(string name, string desc, int cal, string size, List<string> toppings)
    {
        Name = name; Description = desc; Calories = cal; Size = size; Toppings = toppings;
    }

    public override void Eat() => Console.WriteLine($"Eating pizza {Name}...");
    public override void Prepare() => Console.WriteLine($"Preparing pizza {Name} with toppings: {string.Join(", ", Toppings)}");
}

class Burger : Food
{
    public int Price { get; set; }
    public bool HasCheese { get; set; }

    public Burger(string name, string desc, int price, bool hasCheese)
    {
        Name = name; Description = desc; Price = price; HasCheese = hasCheese;
    }

    public override void Eat() => Console.WriteLine($"Eating burger {Name}...");
    public override void Prepare() => Console.WriteLine($"Preparing burger {Name}, Cheese: {HasCheese}");
}

// ==================== Main Program ====================

class Program
{
    static void Main()
    {
        // สร้างอุปกรณ์
        Computer computer = new Computer();
        Microwave microwave = new Microwave();
        List<string> flavors = new List<string> { "Rose", "Lilac", "Camomile", "Jasmin" };
        HotTub tub = new HotTub(flavors);
        Fridge fridge = new Fridge();
        AirConditioner air = new AirConditioner();
        HairDryer dryer = new HairDryer();

        // เปิด/ปิดอุปกรณ์ทั้งหมด
        List<ISwitchController> devices = new List<ISwitchController> { computer, air, microwave, tub, dryer };
        Console.WriteLine("Turning on all devices:");
        foreach (var d in devices) d.TurnOn();

        Console.WriteLine("Device status:");
        foreach (var d in devices) Console.WriteLine($"{d.GetType().Name} isOn: {d.isOn}");

        // ควบคุมอุณหภูมิ
        List<ITemperatureControl> tempDevices = new List<ITemperatureControl> { fridge, air };
        fridge.SetTemperature(9);
        air.SetTemperature(15);

        foreach (var d in tempDevices)
            while (d.CurrentTemperature > d.TargetTemperature)
                d.GetCurrentTemperature();

        // ปรับ HairDryer
        dryer.SetHeatLevel(4);
        dryer.SetFanSpeed(2);

        // เมนูอาหาร
        FoodMenu();
    }

    static void FoodMenu()
    {
        List<string> toppings = new List<string> { "pine", "cheese", "pepper", "999" };
        Food pizza = new Pizza("Hawaiian", "Very good sir", 250, "XL", toppings);
        Food burger = new Burger("51 bur", "Fabulous", 89, true);

        List<Food> order = new List<Food> { pizza, burger };

        foreach (Food f in order)
        {
            f.DisplayInfo();
            f.Prepare();
            f.Eat();
        }
    }
}
