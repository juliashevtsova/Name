using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5
{
    class Program
    {
        static string[] nums_1_9 = "ноль один два три четыре пять шесть семь восемь девять".Split();
        static string[] nums_10_19 = "десять одиннадцать двенадцать тринадцать четырнадцать пятнадцать шестнадцать семнадцать восемнадцать девятнадцать".Split();
        static string[] nums_20_90 = "ноль десять двадцать тридцать сорок пятьдесят шестьдесят семьдесят восемьдесят девяносто".Split();
        static string[] nums_100_900 = "ноль сто двести триста четыреста пятьсот шестьсот семьсот восемьсот девятьсот".Split();
        static string[] razrad = " тысяч миллион миллиард".Split();

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            Console.Write("Введите число: ");
            string n = Console.ReadLine();
            foreach (var s in solve(splitIntoCategories(n)))
            Console.Write($" { s}");
            Console.ReadLine();
        }
        //розбиваємо на розряди
        static IEnumerable<string> splitIntoCategories(string s)
        {
            s = s.PadLeft(s.Length + 3 - s.Length % 3, '0');
            return Enumerable.Range(0, s.Length / 3).Select(i => s.Substring(i * 3, 3));
        }
        //виводимо назви цифр у розряді
        static IEnumerable<string> solve(IEnumerable<string> n)
        {
            var ii = 0;
            foreach (var s in n)
            {
                var countdown = n.Count() - ++ii;
                yield return
                String.Format("{0} {1} {2} {3}",
                s[0] == '0' ? "" : nums_100_900[getDigit(s[0])],
                getE1(s[1], s[2]),
                getE2(s[1], s[2], countdown),
                s == "000" ? "" : getRankName(s, countdown));
            }
        }
        //друга цифра розряду
        private static string getE1(char p1, char p2)
        {
            if (p1 != '0')
            {
                if (p1 == '1')
                    return nums_10_19[getDigit(p2)];
                return nums_20_90[getDigit(p1)];
            }
            return "";
        }
        //третя цифра розряду
        private static string getE2(char p1, char p2, int cd)
        {
            if (p1 != '1')
            {
                if (p2 == '0') return "";
                return (p2 == '2' && cd == 1) ? "две" : nums_1_9[getDigit(p2)];
            }
            return "";
        }
        private static int getDigit(char p1)
        {
            return Int32.Parse(p1.ToString());
        }
        //виводимо назви розрядів
        private static string getRankName(string s, int ii)
        {
            if (ii == 0) return "";
            var r = razrad[ii];
            if (s[1] == '1') return r + (ii == 1 ? " " : "ов");

            if (new[] { '2', '3', '4' }.Contains(s[2]))
            {
                return r + (ii == 1 ? "и" : "а");
            }
            else
            return r + (ii == 1 ? "" : "ов");
        }
    }
}