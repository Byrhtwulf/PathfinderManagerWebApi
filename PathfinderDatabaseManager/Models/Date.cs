using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PathfinderDatabaseManager.Models
{
    public class Date
    {
        public int month { get; set; }
        public int day { get; set; }
        public int year { get; set; }
        public int time { get; set; }
    }
}