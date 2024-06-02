using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Eszaki_kozephegyseg_kilatoi.Models
{
    public class LocationModel
    {
        public int id { get; set; }

        public string location { get; set; }



        public LocationModel(string row)
        {
            var splittedRow = row.Split(';');

            id = int.Parse(splittedRow[0]);
            location = splittedRow[1];
        }



        public static List<LocationModel> loadLocations(string filename)
        {
            List<LocationModel> locations = new List<LocationModel>();

            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                locations.Add(new LocationModel(item));
            }

            return locations;

        }

    }
}
