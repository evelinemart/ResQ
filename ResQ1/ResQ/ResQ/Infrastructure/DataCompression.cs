using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResQ.Models;

namespace ResQ.Infrastructure
{
    public static class DataCompression
    {
        public static List<JsonFireStation> GetListOfFireStation(ApplicationDbContext _cont)
        {
            List<JsonFireStation> res = new List<JsonFireStation>() { };
            foreach (var temp in _cont.FireStations)
            {
                res.Add(new JsonFireStation() 
                { 
                    FireStationName = temp.FireStationName, 
                    X = temp.Location.X, 
                    Y = temp.Location.Y 
                });
            }
            return res;
        }
    }
}