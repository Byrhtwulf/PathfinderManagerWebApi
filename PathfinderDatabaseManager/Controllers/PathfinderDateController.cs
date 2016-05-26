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
    public class PathfinderDateController : ApiController
    {

        // GET api/<controller>
        public PathfinderDatabaseManager.Date Get()
        {
            Date date = DateService.GetDate();
            return date;
        }


        // PUT api/<controller>/5
        public void Put([FromBody]DateData dateData)
        {
            PathfinderDatabaseManager.Models.Date newDate = JsonConvert.DeserializeObject<PathfinderDatabaseManager.Models.Date>(dateData.DateString);
            DateService.SetDate(newDate.month, newDate.day, newDate.year, newDate.time);
        }

    }
    public class DateData
    {
        public string DateString { get; set; }
    }

  
}