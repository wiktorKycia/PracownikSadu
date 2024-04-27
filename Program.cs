using PracownikSadu.classes;
namespace PracownikSadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static string GetUserInput(string message)
        {
            Console.Write(message);
            string? result = Console.ReadLine();
            return result ?? "";
        }
    }
}
