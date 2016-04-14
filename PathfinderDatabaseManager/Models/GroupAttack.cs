using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathfinderDatabaseManager.Models
{
    public class GroupAttack
    {
        public string name { get; set; }
        public string bonusToHit { get; set; }
        public string diceValue { get; set; }
        public string diceCount { get; set; }
        public string diceBonus { get; set; }
        public string lowerCriticalRange { get; set; }
        public string additionalEffects { get; set; }
    }
}