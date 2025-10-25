using Newtonsoft.Json;
using System;
using System.Xml;

public class SmartLight
{
    public bool IsOn { get; private set; }
    public int Brightness { get; private set; } = 100;

    public event Action<bool> OnStateChanged;

    public void Toggle()
    {
        IsOn = !IsOn;
        OnStateChanged?.Invoke(IsOn);
    }

    public void SetBrightness(int brightness)
    {
        Brightness = Math.Clamp(brightness, 0, 100);
    }

    public string ToJson()
    {
        var state = new { IsOn, Brightness };
        return JsonConvert.SerializeObject(state, Formatting.Indented);
    }

    public static SmartLight FromJson(string json)
    {
        var state = JsonConvert.DeserializeObject<SmartLightState>(json);
        return new SmartLight { IsOn = state.IsOn, Brightness = state.Brightness };
    }

    private class SmartLightState
    {
        public bool IsOn { get; set; }
        public int Brightness { get; set; }
    }
}

class Program
{
    static void Main()
    {
        SmartLight light = new SmartLight();

        light.OnStateChanged += (isOn) =>
        {
            Console.WriteLine(isOn ? "Свет включён" : " Свет выключен");
        };

        Console.WriteLine(" Управление умной лампой ");

        light.Toggle();
        light.SetBrightness(75);

        Console.WriteLine("\nСостояние лампы в JSON:");
        string json = light.ToJson();
        Console.WriteLine(json);

        Console.WriteLine("\nДесериализация из JSON:");
        SmartLight restoredLight = SmartLight.FromJson(json);
        Console.WriteLine($"Восстановлено: IsOn={restoredLight.IsOn}, Brightness={restoredLight.Brightness}");

        light.Toggle();
    }
}