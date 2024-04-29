using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class Job
    {
        public int Salary { get; set; }
        public int BonusMin { get; set; }
        public int BonusMax { get; set; }
        public string Name { get; set; }
        public string Presentation { get ; set; }

        public Job(string name, int salary, int bonusMax, string presentation)
        {
            Name = name;
            Salary = salary;
            BonusMin = 0;
            BonusMax = bonusMax;
            Presentation = presentation;
        }
        public Job(string name, int salary, int bonusMin, int bonusMax, string presentation) : this(name, salary, bonusMax, presentation)
        {
            BonusMin = bonusMin;
        }
        public int GetBonus()
        {
            Random random = new Random();
            return random.Next(BonusMin, BonusMax);
        }
        public void PresentJobOffer()
        {
            Console.WriteLine($"{Name}:\n" + Presentation);
            Console.WriteLine($"We offer the stable salary of ${Salary}");
            if (BonusMin!=0)
                Console.WriteLine($"We also offer bonuses from ${BonusMin} up to ${BonusMax} \n");
            else
                Console.WriteLine($"We also offer bonuses up to ${BonusMax} \n");
        }
    }
}
