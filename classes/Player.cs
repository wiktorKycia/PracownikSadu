using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public int Skill { get; set; }
        public Job? Job { get; set; } = null;
        public Player(string name)
        {
            Name = name;
            Age = 18;
            Money = 0;
        }
        public Player(string name, int age)
        {
            Name = name;
            Age = age;
            Money = 0;
        }
        public Player(string name, int age, int money) : this(name, age)
        {
            Money = money;
        }
        public void ShowStatistics()
        {
            Console.WriteLine($"Player: {Name}\nYou are {Age} years old\nYou have ${Money}");
            if(Job is not null)
            {
                Console.WriteLine($"You work at: {Job.Name}\n" +
                $"You have a stable salary of ${Job.Salary}\n" +
                $"You can get bonus money for extraordinary work, from ${Job.BonusMin}, up to ${Job.BonusMax}");
                
            }
            Console.WriteLine($"Your Skill: {Skill}");
            Console.WriteLine($"Your Experience: {Experience}");
        }
    }
}
