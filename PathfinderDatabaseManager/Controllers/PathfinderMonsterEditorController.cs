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
    public class PathfinderMonsterEditorController : ApiController
    {


        // PUT api/<controller>/5
        public Monster_Names Put(int id, [FromBody]MonsterData monsterData)
        {
            PathfinderDatabaseManager.Models.Monster newMonster = JsonConvert.DeserializeObject<PathfinderDatabaseManager.Models.Monster>(monsterData.monsterDataString);
            Monster_Names name = MonsterService.EditMonster(id, newMonster);
            if (name != null)
            {
                return name;
            }
            return null;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            MonsterService.DeleteMonster(id);
        }
    }
    public class MonsterData
    {
        public string monsterDataString { get; set; }
    }

  
}