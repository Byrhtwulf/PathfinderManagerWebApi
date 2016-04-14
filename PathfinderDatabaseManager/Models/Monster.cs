using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathfinderDatabaseManager.Models
{
    public class Monster
    {
        public string name { get; set; }
        public string type { get; set; }
        public int initiative { get; set; }
        public string senses { get; set; }
        public string auras { get; set; }
        public string AC { get; set; }
        public string HP { get; set; }
        public int HD { get; set; }
        public string HPmods { get; set; }
        public string fortitude { get; set; }
        public string reflex { get; set; }
        public string will { get; set; }
        public string saveMods { get; set; }
        public string defenses { get; set; }
        public string defensiveAbilities { get; set; }
        public string weaknesses { get; set; }
        public string speed { get; set; }
        public string space { get; set; }
        public string reach { get; set; }
        public IList<Attack> attacks { get; set; }
        public int baseAttack { get; set; }
        public string CMB { get; set; }
        public string CMBMods { get; set; }
        public int currentCMB { get; set; }
        public int currentCMBRoll { get; set; }
        public string CMD { get; set; }
        public string specialAttacks { get; set; }
        public string specialQualities { get; set; }
        public string abilityScores { get; set; }
        public string feats { get; set; }
        public string skills { get; set; }
        public string description { get; set; }
        [JsonProperty(PropertyName = "monsterAdditionalNotes")]
        public IList<MonsterAdditionalNote> monsterAdditionalNotes { get; set; }
    }
}