namespace hwlab99 { 
using System;

public class Thermometer
{
    public event Action<int> TemperatureTooHigh;

    public void Measure(int value)
    {
        Console.WriteLine($"Измеренная температура: {value}°C");

        if (value > 100)
        {
            TemperatureTooHigh?.Invoke(value);
        }
    }
}

class Program
{
    static void Main()
    {
        Thermometer thermometer = new Thermometer();

        thermometer.TemperatureTooHigh += (temp) =>
        {
            Console.WriteLine($"ПРЕДУПРЕЖДЕНИЕ: Температура {temp}°C превышает допустимый предел!");
        };

        thermometer.Measure(25);
        thermometer.Measure(85);
        thermometer.Measure(105);
        thermometer.Measure(120);
    }
}
}
