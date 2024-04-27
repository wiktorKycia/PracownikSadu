using PracownikSadu.classes;
namespace PracownikSadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in my game!");
            string name = GetUserInput("How would you like to be called? ");
        }
        static string GetUserInput(string message)
        {
            Console.Write(message);
            string? result = Console.ReadLine();
            return result ?? "";
        }
    }
}
