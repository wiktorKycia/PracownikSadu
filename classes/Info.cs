using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class Info
    {
        public string Message { get; set; }
        public ConsoleColor Color { get; set; }
        public int? TurnDisplay { get; set; } = null;

        public Info(string message)
        {
            Message = message;
            Color = ConsoleColor.White;
        }
        public Info(string message, ConsoleColor color):this(message)
        {
            Color = color;
        }
        public Info(string message, ConsoleColor color, int turnDisplay) : this(message, color)
        {
            TurnDisplay = turnDisplay;
        }
        public void Display()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
