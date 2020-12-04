using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS.Practicing.Common
{
    public static class ConsoleUtils
    {
        public static void ColoredWriteLine(object value, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void YellowWriteLine(object value)
        {
            ColoredWriteLine(value, ConsoleColor.Yellow);
        }

        public static void RedWriteLine(object value)
        {
            ColoredWriteLine(value, ConsoleColor.Red);
        }

        public static void GreenWriteLine(object value)
        {
            ColoredWriteLine(value, ConsoleColor.Green);
        }

        public static void BlueWriteLine(object value)
        {
            ColoredWriteLine(value, ConsoleColor.Blue);
        }

        /// <summary>
        /// This is needed to have an optional feature to toggle of console logs if CLI automation mode.
        /// </summary>
        public static void WriteLine(object value)
        {
            Console.WriteLine(value);
        }

        public static void BreakLine()
        {
            Console.WriteLine("\n");
        }
    }
}