using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracownikSadu.classes
{
    internal class Training
    {
        public int Turns { get; set; }
        public int Cost { get; set; }
        public int ExpGain { get; set; }
        public int SkillGain { get; set; }
        public string Name { get; set; }
        public Training(string name, int skillGain, int expGain, int cost = 0, int turns = 1)
        {
            Name = name;
            SkillGain = skillGain;
            ExpGain = expGain;
            Cost = cost;
            Turns = turns;
        }
    }
}
