using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Money { get; set; }
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
    }
}
