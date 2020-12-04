using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Common
{
    public static class ConsoleUtils
    {
        public static void ColoredConsoleWriteLine(object value, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void YellowConsoleWriteLine(object value)
        {
            ColoredConsoleWriteLine(value, ConsoleColor.Yellow);
        }

        public static void RedConsoleWriteLine(object value)
        {
            ColoredConsoleWriteLine(value, ConsoleColor.Red);
        }

        public static void GreenConsoleWriteLine(object value)
        {
            ColoredConsoleWriteLine(value, ConsoleColor.Green);
        }

        public static void BlueConsoleWriteLine(object value)
        {
            ColoredConsoleWriteLine(value, ConsoleColor.Blue);
        }
    }
}