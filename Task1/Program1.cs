using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            Console.Write("Введіть номер тижня: ");
            var day = Console.ReadLine();
            switch (day)
            {
                case "1":
                    Console.WriteLine("Понеділок");
                    break;
                case "2":
                    Console.WriteLine("Вівторок");
                    break;
                case "3":
                    Console.WriteLine("Середа");
                    break;
                case "4":
                    Console.WriteLine("Четвер");
                    break;
                case "5":
                    Console.WriteLine("П'ятница");
                    break;
                case "6":
                    Console.WriteLine("Субота");
                    break;
                case "7":
                    Console.WriteLine("Неділя");
                    break;
                default:
                    Console.WriteLine("Тиждень завершився");
                    break;
            }
            Console.ReadKey();
        }
    }
}
