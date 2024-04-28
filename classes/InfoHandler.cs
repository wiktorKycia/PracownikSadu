using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class InfoHandler
    {
        public List<Info> Messages { get; set; } 

        public InfoHandler()
        {
            Messages = new List<Info>();
        }
        public void ShowMessages(int turn)
        {
            List<Info> messagesToShow = Messages.Where(m => m.TurnDisplay == turn).ToList();
            messagesToShow = messagesToShow.Concat(Messages.Where(m => m.TurnDisplay is null).ToList()).ToList();
            Console.WriteLine("\nMessages: ");
            foreach (Info message in messagesToShow)
            {
                Console.WriteLine();
                message.Display();
            }
            Console.WriteLine();
            //Messages.RemoveAll(m => messagesToShow.Contains(m));
            Messages.RemoveAll(messagesToShow.Contains);
            messagesToShow.Clear();
        }
        public void CreateNewMessage(string message)
        {
            Messages.Add(new Info(message));
        }
        public void CreateNewMessage(string message, ConsoleColor color)
        {
            Messages.Add(new Info(message, color));
        }
        public void CreateNewMessage(string message, ConsoleColor color, int turn)
        {
            Messages.Add(new Info(message, color, turn));
        }
    }
}
