using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PathfinderDatabaseManager.Models;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace PathfinderDatabaseManager.Services
{
    public static class DateService
    {
        static pathfinder_managerEntities database = new pathfinder_managerEntities();

        public static PathfinderDatabaseManager.Date GetDate(){
            PathfinderDatabaseManager.Date date = database.Dates.FirstOrDefault();
            if (date != null){
                return date;
            }
            return null;
        }

        public static void SetDate(int month, int day, int year, int time){
            PathfinderDatabaseManager.Date date = database.Dates.FirstOrDefault();
            if (date != null){
                date.Month = month;
                date.Day = day;
                date.Year = year;
                date.Time = time;
            }
            database.SaveChangesAsync();

        }
        
    }
}