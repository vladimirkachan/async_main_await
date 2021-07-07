using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMainAwaitIsPossible
{
    public static class ConsoleHelper
    {
        const string lockObject = "console";
        public static void PrintLine(this string text, ConsoleColor color = ConsoleColor.Gray)
        {
            lock (lockObject)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }
        public static void PrintLine(this string text, int color)
        {
            PrintLine(text, (ConsoleColor)color);
        }
        public static void Print(this string text, ConsoleColor color = ConsoleColor.Gray)
        {
            lock (lockObject)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
        }
        public static void Print(this string text, int color)
        {
            Print(text, (ConsoleColor)color);
        }
    }
}
