using PracownikSadu.classes;
namespace PracownikSadu
{
    internal class Program
    {
        public static bool running = true;
        public static int turn = 1;
        public static InfoHandler infoHandler = new InfoHandler();
        public static Dictionary<int, Job> jobs = new Dictionary<int, Job>()
        {
            {1, new Job("name", 1000, 200) }
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in my game!");
            string name = GetUserInput("How would you like to be called? ");
            int age;
            string? ageInput;
            do
            {
                Console.Write($"How old are you, {name}? (pass a number between 18 and 65) ");
                ageInput = Console.ReadLine();
                if (ageInput is null || ageInput == "")
                {
                    age = 18;
                    break;
                }
            }
            while (!int.TryParse(ageInput ?? "18", out age) || age > 65 || age < 18);
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
            while(running)
            {
                DisplayMainMenu(player);
            }
        }

        private static void DisplayMainMenu(Player player)
        {
            Console.Clear();
            Console.WriteLine($"Player: {player.Name}\nYou are {player.Age} years old\nYou have ${player.Money}");
            infoHandler.ShowMessages(turn);
            Console.WriteLine("Choose one option from the list: ");
            Console.WriteLine("1. Next turn");
            Console.WriteLine("2. Go to work");
            Console.WriteLine("3. See your current job");
            Console.WriteLine("4. See job offers");
            Console.WriteLine("5. Set up own business");
            Console.WriteLine("6. Exit game");
            int input = GetUserInt("");
            while(!(input > 0 && input < 7))
            {
                input = GetUserInt("Please, give me a number between 1 and 6: ");
            }
            switch (input)
            {
                case 1:
                    if (player.Job is not null)
                    {
                        player.Money += player.Job.Salary;
                    }
                    turn++;
                    break;
                case 2:
                    if(player.Job is not null)
                    {
                        player.Money += player.Job.GetBonus();
                    }
                    else
                    {
                        infoHandler.CreateNewMessage("You are unemployeed, thus you cannot work! Apply for a job", ConsoleColor.Yellow);
                    }
                    break;
                case 3:
                    if (player.Job is not null)
                    {
                        infoHandler.CreateNewMessage($"You work at: {player.Job.Name}\n" +
                            $"You have a stable salary of ${player.Job.Salary}\n" +
                            $"You can get bonus money for extraordinary work, from ${player.Job.BonusMin}, up to ${player.Job.BonusMax}");
                        //Console.WriteLine($"You work at: {player.Job.Name}");
                        //Console.WriteLine($"You have a stable salary of ${player.Job.Salary}");
                        //Console.WriteLine($"You can get bonus money for extraordinary work, from ${player.Job.BonusMin}, up to ${player.Job.BonusMax}");
                    }
                    break;
                case 4:
                    return;
                case 5:
                    return;
                case 6:
                    running = false;
                    return;
                default: return;
            }
        }
        static void ShowJobOffers()
        {
            Console.Clear();
            Console.WriteLine("Job offers: ");
            foreach (KeyValuePair<int, Job> job in jobs)
            {
                Console.Write($"{job.Key}. {job.Value.PresentJobOffer}");
            }
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
