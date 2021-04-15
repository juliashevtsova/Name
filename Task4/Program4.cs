using System;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            double x1, x2, y1, y2, distance;

            Console.Write("Введите координаты x1: ");
            x1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите координаты x2: ");
            x2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите координаты y1: ");
            y1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите координаты y2: ");
            y2 = Convert.ToDouble(Console.ReadLine());

            distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Расстояние между двумя точками = {distance}");
            Console.ReadKey();
        }
    }
}