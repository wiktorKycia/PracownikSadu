using PracownikSadu.classes;
namespace PracownikSadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in my game!");
            string name = GetUserInput("How would you like to be called? ");
            int age = GetUserInt("How old are you? (you can pass nothing, then 18 will be assigned) ");
            Player player;
            if(age < 18)
            {
                player = new Player(name);
            }
            else
            {
                int money = GetUserInt("What is your starting money? ");
                if (money < 0)
                {
                    player = new Player(name, age);
                }
                else
                {
                    player = new Player(name, age, money);
                }
            }
            DisplayMainMenu(player);
        }

        private static void DisplayMainMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Player: {player.Name}\nYou are {player.Age} years old\nYou have ${player.Money}");
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
                    return result;
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine($"Try to pass a value that is between {int.MinValue} and {int.MaxValue}");
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
