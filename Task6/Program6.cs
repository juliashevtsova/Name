using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static string[][] numbers =
            {
            new string[3] {"ноль", "нуль", "0"},
            new string[5] {"один", "одна", "одну", "одно", "1"},
            new string[3] {"два", "две", "2"},
            new string[2] {"три", "3"},
            new string[2] {"четыре", "4"},
            new string[2] {"пять", "5"},
            new string[2] {"шесть", "6"},
            new string[2] {"семь", "7"},
            new string[2] {"восемь", "8"},
            new string[2] {"девять", "9"},
            new string[2] {"десять", "10"},
            new string[2] {"одиннадцать", "11"},
            new string[2] {"двенадцать", "12"},
            new string[2] {"тринадцать", "13"},
            new string[2] {"четырнадцать", "14"},
            new string[2] {"пятнадцать", "15"},
            new string[2] {"шестнадцать", "16"},
            new string[2] {"семнадцать", "17"},
            new string[2] {"восемьдесять", "80"},
            new string[2] {"девятнадцать", "19"},
            new string[2] {"двадцать", "20"},
            new string[2] {"тридцать", "30"},
            new string[2] {"сорок", "40"},
            new string[2] {"пятьдесят", "50"},
            new string[2] {"шестьдесят", "60"},
            new string[2] {"семьдесят", "70"},
            new string[2] {"восемьдесят", "80"},
            new string[2] {"девяносто", "90"},
            new string[2] {"сто", "100"},
            new string[2] {"двести", "200"},
            new string[2] {"триста", "300"},
            new string[2] {"четыреста", "400"},
            new string[2] {"пятьсот", "500"},
            new string[2] {"шестьсот", "600"},
            new string[2] {"семьсот", "700"},
            new string[2] {"восемьсот", "800"},
            new string[2] {"девятьсот", "900"},
            new string[4] {"тысяч", "тысячи", "тысяча", "1000" },
            new string[4] {"миллиона", "миллионов", "миллион", "1000000"},
            new string[4] {"миллиарда", "миллиард", "миллиардов", "1000000000"},
        };
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1251 = Encoding.GetEncoding(1251);
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.InputEncoding = enc1251;

            Console.Write("Введите число: ");
            string text = Console.ReadLine();
            text = text + " ";
            decimal numeric = RecipeToNum(text);
            Console.WriteLine(numeric);
            Console.ReadKey();
        }
        public static decimal RecipeToNum(string _text)
        {
            _text = _text.Replace(".", ",");
            if (decimal.TryParse(_text, out decimal numeric)) return numeric;
            var reg = new Regex(@"[,\/\\\(\)\-\+\=\*\&\?\^\%\$\#;" + '"' + @"'`~@\[\{\]\}\!\№\:]");
            _text = reg.Replace(_text, "");
            var trep = 0;
            var flag = false;
            var words = _text.Split();
            decimal temp = 0;
            var num = new decimal[words.Length];

            for (var w = 0; w < words.Length; w++)
            switch (words[w])
            {
               default:
                if (decimal.TryParse(words[w], out num[w]))
                {
                   continue;
                }
                else
                {
                    foreach (string[] t in numbers)
                    {
                        if (!flag)
                        {
                            for (var j = 0; j < t.Length - 1; j++)
                            {
                                if (String.Equals(t[j], words[w], StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (!(words[w] == "тысяч" || words[w] == "тысячи" || words[w] == "тысяча" ||
                                    words[w] == "миллиона" || words[w] == "миллионов" || words[w] == "миллион" ||
                                    words[w] == "миллиарда" || words[w] == "миллиард" || words[w] == "миллиардов"))
                                    {
                                        if (!decimal.TryParse(t[t.Length - 1], out num[w]))
                                        {
                                           num[w] = 0;
                                           flag = true;
                                        }
                                    }
                                    else
                                    {
                                        for (var d = trep; d < w; d++)
                                        temp += num[d];
                                        numeric += temp * decimal.Parse(t[t.Length - 1]);
                                        trep = w;
                                        temp = 0;
                                        flag = true;                                                
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                 break;
            }
            Console.Write("Результат: ");
            return numeric;            
        }
    }
}