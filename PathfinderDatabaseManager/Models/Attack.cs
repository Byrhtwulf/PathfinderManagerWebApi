using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathfinderDatabaseManager.Models
{
    public class Attack
    {
        public string groupName { get; set; }
        [JsonProperty(PropertyName = "groupAttacks")]
        public IList<GroupAttack> groupAttacks { get; set; }
    }
}