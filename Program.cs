using OOP;
using System;

Computer computer = new Computer();
//computer.isOn(); //this is a variable... have to print it as Console.Write
//Console.WriteLine("status: " + computer.isOn);

Microwave microwave = new Microwave();
//microwave.TurnOn();
//Console.WriteLine(microwave.isOn);

List<string> flavors = new List<string> { "Rose", "Lilac", "Camomile", "Jasmin" };
HotTub tub = new HotTub(flavors);

//--------------------------------------------------------------------------------------------
Fridge fridge = new Fridge();
/*Console.WriteLine("Fridge current temp : " + fridge.CurrentTemperature);
fridge.GetCurrentTemperature();*/
//--------------------------------------------------------------------------------------------
AirConditioner air = new AirConditioner();

Microwave microwave1 = microwave;

Microwave microwave11 = microwave1;

HotTub tub1 = tub;

//air.TurnOn();
/*Console.WriteLine("air is turn on : " + air.isOn);*/

/*air.SetTemperature(15);
while (air.CurrentTemperature > air.TargetTemperature)
{
    air.GetCurrentTemperature();
}

while (fridge.CurrentTemperature > fridge.TargetTemperature)
{
    fridge.GetCurrentTemperature();
}*/


List<ISwitchController> smartphone = { (ISwitchController)computer, AirConditioner};

Console.WriteLine("go to home");
foreach (var switchControl in smartphone)
{
    switchControl.TurnOn();
}
Console.WriteLine("status");
foreach (var switchControl in smartphone)
{
    Console.WriteLine(switchControl.isOn);
}

List<ITemperatureControl> SmartTemperatureControl = new List<ITemperatureControl>();

fridge.SetTemperature(9);
air.SetTemperature(15);
SmartTemperatureControl.Add(fridge);
SmartTemperatureControl.Add(air);

foreach (var device in SmartTemperatureControl)
{
    while (device.CurrentTemperature > device.TargetTemperature)
    {
        air.GetCurrentTemperature();
    }
}
void FoodMenu()
{
    //Food food = new Food(); ------cannot "new" the food because it is abstract

    List<string> toppings = new List<string> { "pine", "cheese", "pepper", "999" };
    food pizza = new Pizza("Hawaiian", "Very good sir", 250, "XL", toppings);
    food burger = new Burger("51 bur", "Fabulous", 89, true);
    //similar with Pizza @@ = new Pizza (@@@); right????
    //so if we want to collect as many as input orders, you can use front as food, after as "Specific food name"
    List<food> Order = new List<food>();
    Order.Add(pizza);
    Order.Add(burger);

    foreach (food yesfood in Order)
    {
        yesfood.DisplayInfo();
        yesfood.Eat();
        yesfood.Prepare();
    }
    //burger.Pay(); ---- you can create another method for your own specific food, you just have to define the burger seperately : Burger burger = new Burger (@@@ ,"Pay");

    /* pizza.Eat();
    pizza.Prepare();
    pizza.DisplayInfo(); */

}
