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
        static int GetUserInt(string message)
        {
            int result;
            Console.Write(message);
            do
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                    if (result < 18)
                    {
                        Console.WriteLine("You are too young for getting a job!");
                    }
                    else if (result > 65)
                    {
                        Console.WriteLine("Go on retirement old man!");
                    }
                    return result;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Try to pass a value that is between 18 and 65");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("You have to pass only a number");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("idk sth went wrong . . .");
                }
            }
            while(true);
            
        }
    }
}
