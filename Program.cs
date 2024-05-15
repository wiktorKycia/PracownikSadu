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
            {1, new Job("name", 1000, 200, "please come to our orchard", 10, 20, 0, 0) },
            {2, new Job("name", 500, 750, "please come to our orchard", 20, 150, 0, 50) },
            {3, new Job("name", 5000, 0, "please come to our orchard", 40, 10, 500, 150) },
            {4, new Job("name", 1500, 600, "please come to our orchard", 30, 50, 450, 200) }
        };
        public static List<Training> Trainings = new List<Training>()
        {
            new Training("Apple collecting tutorial", 5, 1),
            new Training("Putting apples to the basket tutorial", 2, 1),
            new Training("Collecting apples from higher trees using a ladder", 15, 2, 10, 3),
            new Training("Checking if the apples are ok to eat", 25, 3, 15, 5),
            new Training("Planting your own trees", 50, 5, 500, 7),
            new Training("How to water a tree?", 20, 1, 5)
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
            player.ShowStatistics();
            infoHandler.ShowMessages(turn);
            Console.WriteLine("Choose one option from the list: ");
            Console.WriteLine("1. Next turn");
            Console.WriteLine("2. Go to work");
            Console.WriteLine("3. See your current job");
            Console.WriteLine("4. See job offers");
            Console.WriteLine("5. Go on employee training");
            Console.WriteLine("6. Set up own business");
            Console.WriteLine("7. Exit game");
            int input = GetUserInt("");
            while(!(input > 0 && input < 8))
            {
                input = GetUserInt("Please, give me a number between 1 and 7: ");
            }
            switch (input)
            {
                case 1:
                    if (player.Job is not null)
                    {
                        player.Money += player.Job.Salary;
                        player.Experience += player.Job.ExperienceGain;
                    }
                    turn++;
                    break;
                case 2:
                    if(player.Job is not null)
                    {
                        player.Money += player.Job.GetBonus();
                        player.Experience += player.Job.ExperienceGain;
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
                    else
                    {
                        infoHandler.CreateNewMessage("You are unemployeed. Please, apply for a job!", ConsoleColor.Yellow);
                    }
                    break;
                case 4:
                    ShowJobOffers();
                    do
                    {
                        int choice = GetUserInt("To which job you wanna apply? (0 for exit)");
                        if (choice == 0)
                        {
                            break;
                        }
                        else if (choice > 0)
                        {
                            if(jobs.ContainsKey(choice))
                            {
                                if (jobs[choice].SkillRequirements > player.Skill)
                                {
                                    Console.WriteLine("You do not meet the skill requirements yet");
                                    Console.WriteLine($"You have {player.Skill}, but {jobs[choice].SkillRequirements} is required");
                                }
                                else if (jobs[choice].ExperienceRequirements > player.Experience)
                                {
                                    Console.WriteLine("You do not meet the experience requirements yet");
                                    Console.WriteLine($"You have {player.Experience}, but {jobs[choice].ExperienceRequirements} is required");
                                }
                                else
                                {
                                    player.Job = jobs[choice];
                                    player.Skill += jobs[choice].SkillGain;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Try to pass a number between 0 and {jobs.Count}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("you must pick a positive number!");
                        }
                    } while (true);
                    
                    return;
                case 5:
                    return;
                case 6:
                    foreach (Training training in Trainings)
                    {
                        training.PresentOffer();
                        Console.WriteLine();
                    }
                    do
                    {
                        int choice = GetUserInt("On which training do you wanna go? (0 for exit)");
                        if (choice == 0)
                        {
                            break;
                        }
                        else if (choice > 0)
                        {
                            if (Trainings.Count >= choice)
                            {
                                player.Experience += Trainings[choice].ExpGain;
                                player.Skill += Trainings[choice].SkillGain;
                                player.Money -= Trainings[choice].Cost;
                                turn += Trainings[choice].Turns;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Try to pass a number between 0 and {jobs.Count}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("you must pick a positive number!");
                        }
                    } while (true);
                    return;
                case 7:
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
                Console.Write($"{job.Key}. ");
                job.Value.PresentJobOffer();
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
