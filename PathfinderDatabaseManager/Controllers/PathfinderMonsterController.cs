using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PathfinderDatabaseManager.Services;
using System.Diagnostics;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PathfinderDatabaseManager.Models;

namespace PathfinderDatabaseManager.Controllers
{
    //[EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class PathfinderMonsterController : ApiController
    {

        // GET api/<controller>
        public Monster Get(string monsterName)
        {
            Monster monster = MonsterService.GetMonsterByName(monsterName);
            return monster;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            Monster monster = MonsterService.GetMonsterById(id);
            string monsterString = JsonConvert.SerializeObject(monster, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return monsterString;
        }


        // PUT api/<controller>/5
        public void Put([FromBody]MonsterData monsterData)
        {
            PathfinderDatabaseManager.Models.Monster newMonster = JsonConvert.DeserializeObject<PathfinderDatabaseManager.Models.Monster>(monsterData.monsterDataString);
            MonsterService.CreateMonster(newMonster);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
    public class MonsterData
    {
        public string monsterDataString { get; set; }
    }

  
}