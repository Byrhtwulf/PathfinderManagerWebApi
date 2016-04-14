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
        public IEnumerable<string> Get(string data)
        {
            List<Monster> monsters = MonsterService.GetAllMonsters();
            Debug.WriteLine("Data: " + data);
            foreach (Monster m in monsters)
            {
                Debug.WriteLine("Monster Name: " + m.Name);
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            Debug.WriteLine("Get With Data");
            return "value";
        }

        // POST api/<controller>

        public void test(string data)
        {
            List<Monster> monsters = MonsterService.GetAllMonsters();
            Debug.WriteLine("Data: " + data);
            foreach (Monster m in monsters)
            {
                Debug.WriteLine("Monster Name: " + m.Name);
            }
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