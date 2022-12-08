using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Helpers
{
    internal class Pages<T>
    {
        List<T> _list;
        public Pages(List<T> coba)
        {
            _list = coba;
        }

        private Dictionary<string, int> lenPerField(List<T> page)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var item in typeof(T).GetProperties())
            {

                var lenProp = item.Name.Length;
                var i = page.Select(x => x.GetType().GetProperty(item.Name).GetValue(x).ToString()).Max(x => x.Length);
                result.Add(item.Name, i < lenProp ? lenProp : i);
            }

            return result;

        }
        private string linePage(Dictionary<string, int> keys)
        {
            string result = "+";
            foreach (var key in keys)
            {
                result += "-";
                for (int i = 0; i < key.Value; i++)
                {
                    result += "-";
                }
                result += "-+";
            }
            return result;
        }
        private string TextAligenLeft(string text, int len)
        {
            string result = " " + text;
            for (int i = 0; i < len - text.Length + 1; i++)
            {
                result += " ";
            }
            return result;
        }

        public void page(string H = "")
        {
            var totalProduct = _list.Count();
            var start = 0; var end = 5;
            int maxPage = totalProduct % 5 == 0 ? totalProduct / 5 : (totalProduct / 5) + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(H);
                Console.WriteLine($"page: {(start / 5) + 1}");
                Console.WriteLine($"Max page: {maxPage}");
                var page = _list.Skip(start).Take(end).ToList();
                if (page.Count != 0)
                {
                    var lenF = lenPerField(page);
                    var lp = linePage(lenF);
                    var Heading = typeof(T).GetProperties();
                    Console.WriteLine(lp);
                    Console.Write("|");
                    foreach (var property in Heading)
                    {
                        Console.Write(TextAligenLeft(property.Name, lenF[property.Name]) + "|");
                    }
                    Console.WriteLine("\n" + lp);
                    foreach (var i in page)
                    {
                        Console.Write("|");
                        foreach (var property in Heading)
                        {
                            Console.Write(TextAligenLeft(property.GetValue(i).ToString(), lenF[property.Name]) + "|");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine(lp);
                }
                else
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine("|     Empty Data     |");
                    Console.WriteLine("=====================");
                }
                Console.WriteLine("PRESS X FOR EXIT!");
                Console.Write("\npress 'F' for Forward Or 'B' Or Go To: ");
                var backOrforward = Console.ReadLine().ToUpper();

                try
                {
                    start = (Convert.ToInt32(backOrforward) * 5) - 5;
                }
                catch (Exception) { }


                if ((start <= 0 && backOrforward == "B") || (start + 5 >= _list.Count && backOrforward == "F"))
                {
                    continue;
                }
                else if (backOrforward == "F")
                {
                    start += 5;
                }
                else if (backOrforward == "B")
                {
                    start -= 5;
                }
                else if (backOrforward == "X")
                {
                    break;
                }
            }
        }
    }
}
