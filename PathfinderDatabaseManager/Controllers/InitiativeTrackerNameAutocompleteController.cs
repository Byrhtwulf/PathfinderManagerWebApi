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
    public class InitiativeTrackerNameAutocompleteController : ApiController
    {

        // GET api/<controller>
        public List<Monster_Names> Get()
        {
            List<Monster_Names> monsters = MonsterService.GetAllMonsterNames();
            Debug.WriteLine("Accessing Get All Monster Names");
            //var json = JsonConvert.SerializeObject(monsters);
            //JToken token = JObject.Parse(json);
            return monsters;
        }
    }

  
}