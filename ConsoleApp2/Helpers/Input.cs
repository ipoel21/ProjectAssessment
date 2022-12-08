using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Helpers
{
    internal static class Input
    {
        public static int InputInt(string InputString)
        {
            Console.Write(InputString);
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return InputInt(InputString);
            }
        }
    }
}
