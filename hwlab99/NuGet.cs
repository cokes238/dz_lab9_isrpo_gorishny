using System;
using HtmlAgilityPack;
using System.Threading.Tasks;

class Program
{
    static async Task ScrapeWebsite()
    {
        Console.Write("Введите URL сайта: ");
        string? url = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(url))
        {
            Console.WriteLine("URL не может быть пустым.");
            return;
        }

        try
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var titleNode = doc.DocumentNode.SelectSingleNode("//title");

            if (titleNode != null)
            {
                Console.WriteLine($"Заголовок страницы: {titleNode.InnerText.Trim()}");
            }
            else
            {
                Console.WriteLine("Заголовок страницы не найден");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static async Task Main()
    {


        Console.WriteLine("\n=== ЗАДАНИЕ 2: Web Scraping ===");
        await ScrapeWebsite();

    }
}