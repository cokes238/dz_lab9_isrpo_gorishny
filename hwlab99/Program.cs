//using MathLibrary;
//using System;

//class Program
//{
//    static void Main()
//    {
//        MathTools math = new MathTools();

//        int sum = math.Add(5, 3);
//        int product = math.Multiply(4, 7);

//        Console.WriteLine($"Сумма: {sum}");
//        Console.WriteLine($"Произведение: {product}");
//    }
//}
//using System;

//public delegate void Logger(string message);

//class Program
//{
//    static void LogToConsole(string message)
//    {
//        Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss}: {message}");
//    }

//    static void Main()
//    {
//        Logger logger = LogToConsole;

//        logger("Программа запущена");
//        logger("Выполняется какая-то операция");
//        logger("Программа завершена");
//    }
//}

using System;

class Program
{
    static void PrintLength(string input)
    {
        if (input == null)
        {
            Console.WriteLine("Строка отсутствует (null)");
        }
        else if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Строка пустая или состоит из пробелов");
        }
        else
        {
            Console.WriteLine($"Длина строки: {input.Length}");
        }
    }

    static void Main()
    {
        PrintLength("Hello World");
        PrintLength(null);
        PrintLength("");
        PrintLength("   ");
    }
}