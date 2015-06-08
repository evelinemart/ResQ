using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResQ.Models;

namespace ResQ.Infrastructure
{
    public class DataComputing
    {
        // MainMeth
        public static string FindTheNearestFireStation(ApplicationDbContext _context, int? reqId)
        {
            Location requestLocation = getRequestLocation(_context, reqId);
            List<Location> fireStationLocation = getFireStationLocation(_context);
            Location nearest = getNearestFirestation(requestLocation, fireStationLocation);
            
            var res = (from temp in _context.FireStations
                       where temp.LocationId == nearest.Id
                       select temp).ToArray()[0].FireStationName;
            return res;
        }



        // Get location of request
        private static Location getRequestLocation(ApplicationDbContext _context, int? reqId)
        {
            IQueryable<Location> request = from temp in _context.Requests
                                           where temp.ID == reqId
                                           select temp.Location;
            return request.ToList()[0];
        }

        // Get list of fire station's location
        private static List<Location> getFireStationLocation(ApplicationDbContext _context)
        {
            List<Location> request = (from temp in _context.FireStations
                                      select temp.Location).ToList();
            return request;
        }

        // Get array with index, which contain id nearest fire stations
        private static Location getNearestFirestation(Location requestLocation, List<Location> fireStationLocation)
        {
            return fireStationLocation[getNearestFire(requestLocation, fireStationLocation)];
        }

        private static int getNearestFire(Location requestLocation, List<Location> fireStationLocation)  // Функция для определния ближайших служб
        {
            double[] list = new double[fireStationLocation.Count];                                       // Контейнер для хранения информции
            for (int i = 0; i < fireStationLocation.Count; i++)
            {
                // Определяем растояние между сигналом SOS и пожарной части, используя метод getDistance
                list[i] = getDistance(fireStationLocation[i].X, fireStationLocation[i].Y, requestLocation.X, requestLocation.Y);
            }
            
            double min = list.Min();                                                                     // Находим минимальное расстояние
            return Array.IndexOf(list, min);                                                             // и возвращаем индекс минимального
        }
        
        // Get distance between two points
        private static double getDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));                              // Функция которая определяет расстояние 
        }                                                                                               // между двумя точками

    }
}