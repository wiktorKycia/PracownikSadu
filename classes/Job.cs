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
        public int BonusMin { get; set; } = 0;
        public int BonusMax { get; set; }
        public string Name { get; set; }
        public string Presentation { get ; set; }

        public int ExperienceGain { get; set; }
        public int SkillGain { get; set; }
        public int ExperienceRequirements { get; set; }
        public int SkillRequirements { get; set; }

        public Job(string name, int salary, int bonusMax, string presentation, int experienceGain, int skillGain, int expRequirements, int skillRequirements)
        {
            Name = name;
            Salary = salary;
            BonusMin = 0;
            BonusMax = bonusMax;
            Presentation = presentation;
            ExperienceGain = experienceGain;
            SkillGain = skillGain;
            ExperienceRequirements = expRequirements;
            SkillRequirements = skillRequirements;
        }
        public Job(string name, int salary, int bonusMin, int bonusMax, string presentation, int experienceGain, int skillGain, int expRequirements, int skillRequirements) : this(name, salary, bonusMax, presentation, experienceGain, skillGain, expRequirements, skillRequirements)
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
            Console.WriteLine($"You can improve your skills by {SkillGain}\n and gain {ExperienceGain} experience per turn");
            Console.WriteLine($"We offer the stable salary of ${Salary}");
            if (BonusMin > 0)
            {
                Console.WriteLine($"We also offer bonuses from ${BonusMin} up to ${BonusMax} \n");
            }
            else
            {
                Console.WriteLine($"We also offer bonuses up to ${BonusMax} \n");
            }
            Console.WriteLine($"However, we require from you to have skill above {SkillRequirements}\n" +
                $"And experience greater than {ExperienceRequirements}");
        }
    }
}
