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

        public Job(int salary, int bonusMax)
        {
            Salary = salary;
            BonusMin = 0;
            BonusMax = bonusMax;
        }
        public Job(int salary, int bonusMin, int bonusMax) : this(salary, bonusMax)
        {
            BonusMin = bonusMin;
        }
        public int GetBonus()
        {
            Random random = new Random();
            return random.Next(BonusMin, BonusMax);
        }
        public void PresentJobOffer(string message)
        {
            Console.WriteLine("\n" + message + "\n");
        }
    }
}
