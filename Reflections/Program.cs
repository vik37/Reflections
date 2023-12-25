// See https://aka.ms/new-console-template for more information

using Reflections;
using System.Xml.Schema;

new CSVGenerator<Book>(BookData.Books(),"books").Generator();
new CSVGenerator<Weather>(WeatherData.Weathers(), "weather").Generator();

Console.WriteLine("CSV File was Created Successfully");
Console.ReadLine();
