using System;
using System.Collections.Generic;

// Interfaces
interface ISwitchController
{
    bool isOn { get; }
    void TurnOn();
    void TurnOff();
}

interface ITemperatureControl
{
    int CurrentTemperature { get; }
    int TargetTemperature { get; }
    void SetTemperature(int target);
    void GetCurrentTemperature(); // Simulate temp change
}

// Base Devices
class Computer : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }
}

class Microwave : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }
}

class HotTub : ISwitchController
{
    public bool isOn { get; private set; } = false;
    public List<string> Flavors { get; private set; }
    public HotTub(List<string> flavors) { Flavors = flavors; }
    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }
}

// Temperature Devices
class Fridge : ITemperatureControl
{
    public int CurrentTemperature { get; private set; } = 25;
    public int TargetTemperature { get; private set; } = 5;
    public void SetTemperature(int target) { TargetTemperature = target; }
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

    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }

    public void SetTemperature(int target) { TargetTemperature = target; }

    public void GetCurrentTemperature()
    {
        if (CurrentTemperature > TargetTemperature) CurrentTemperature--;
        Console.WriteLine("AirConditioner temp: " + CurrentTemperature);
    }
}

// Abstract Food
abstract class Food
{
    public string Name { get; set; }
    public string Description { get; set; }
    public abstract void Eat();
    public abstract void Prepare();
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Food: {Name}, Description: {Description}");
    }
}

// Pizza and Burger
class Pizza : Food
{
    public int Calories { get; set; }
    public string Size { get; set; }
    public List<string> Toppings { get; set; }

    public Pizza(string name, string description, int calories, string size, List<string> toppings)
    {
        Name = name; Description = description; Calories = calories; Size = size; Toppings = toppings;
    }

    public override void Eat() => Console.WriteLine($"Eating pizza {Name}...");
    public override void Prepare() => Console.WriteLine($"Preparing pizza {Name} with toppings: {string.Join(", ", Toppings)}");
}

class Burger : Food
{
    public int Price { get; set; }
    public bool HasCheese { get; set; }

    public Burger(string name, string description, int price, bool hasCheese)
    {
        Name = name; Description = description; Price = price; HasCheese = hasCheese;
    }

    public override void Eat() => Console.WriteLine($"Eating burger {Name}...");
    public override void Prepare() => Console.WriteLine($"Preparing burger {Name}, Cheese: {HasCheese}");
}

// Main Program
class Program
{
    static void Main()
    {
        Computer computer = new Computer();
        Microwave microwave = new Microwave();
        List<string> flavors = new List<string> { "Rose", "Lilac", "Camomile", "Jasmin" };
        HotTub tub = new HotTub(flavors);

        Fridge fridge = new Fridge();
        AirConditioner air = new AirConditioner();

        // SwitchController List
        List<ISwitchController> smartphone = new List<ISwitchController> { computer, air, microwave, tub };

        Console.WriteLine("Go to home and turn on devices:");
        foreach (var switchControl in smartphone)
        {
            switchControl.TurnOn();
        }

        Console.WriteLine("Device status:");
        foreach (var switchControl in smartphone)
        {
            Console.WriteLine($"{switchControl.GetType().Name} isOn: {switchControl.isOn}");
        }

        // Temperature control
        List<ITemperatureControl> SmartTemperatureControl = new List<ITemperatureControl> { fridge, air };
        fridge.SetTemperature(9);
        air.SetTemperature(15);

        foreach (var device in SmartTemperatureControl)
        {
            while (device.CurrentTemperature > device.TargetTemperature)
            {
                device.GetCurrentTemperature();
            }
        }

        // Food Menu
        FoodMenu();
    }

    static void FoodMenu()
    {
        List<string> toppings = new List<string> { "pine", "cheese", "pepper", "999" };
        Food pizza = new Pizza("Hawaiian", "Very good sir", 250, "XL", toppings);
        Food burger = new Burger("51 bur", "Fabulous", 89, true);

        List<Food> Order = new List<Food> { pizza, burger };

        foreach (Food item in Order)
        {
            item.DisplayInfo();
            item.Prepare();
            item.Eat();
        }
    }
}
