using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eszaki_kozephegyseg_kilatoi.Models
{
    public class ViewpointModel
    {
        public int id { get; set; }
        public string viewpointName { get; set; }
        public string mountain { get; set; }
        public double height { get; set; }
        public string description { get; set; }
        public string built { get; set; }
        public string imageUrl { get; set; }
        public LocationModel location { get; set; }

        public ViewpointModel(string row, List<LocationModel> locations)
        {
            var splittedRow = row.Split(';');

            id = int.Parse(splittedRow[0]);
            viewpointName = splittedRow[1];
            mountain = splittedRow[2];
            height = double.Parse(splittedRow[3].Replace(".", ","));
            description = splittedRow[4];
            built = splittedRow[5];
            imageUrl = splittedRow[6];
            int locationId = int.Parse(splittedRow[7]);
            location = locations.Find(r => r.id == locationId);
        }
        public static List<ViewpointModel> loadViewpoints(string filename, List<LocationModel> locations)
        {

            List<ViewpointModel> viewpoints = new List<ViewpointModel>();
            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                viewpoints.Add(new ViewpointModel(item, locations));
            }
            return viewpoints;
        }

    }
}
