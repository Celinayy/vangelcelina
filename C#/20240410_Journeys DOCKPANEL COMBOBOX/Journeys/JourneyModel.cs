using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Journeys
{
    internal class JourneyModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public DateTime Departure { get; set; }
        public int? Capacity { get; set; }
        public string PictureUrl { get; set; }
        public VehicleModel Vehicle { get; set; }

        public JourneyModel()
        {
            
        }

        public JourneyModel(string row)
        {
            var splitted = row.Split(';');
            //id;vehicleid;vehicletype;country;description;departure;capacity;pictureUrl
            Id = int.Parse(splitted[0]);
            Vehicle = new VehicleModel() { Id = int.Parse(splitted[1]), Type = splitted[2] };
            Country = splitted[3];
            Description = splitted[4];
            Departure = DateTime.Parse(splitted[5]);
            Capacity = splitted[6] == "" ? 0 : int.Parse(splitted[6]);
            PictureUrl = splitted[7];
        }

        public static List<JourneyModel> LoadFromCsv(string filename)
        {
            List<JourneyModel> journeyModels = new List<JourneyModel>();
            foreach (var row in File.ReadAllLines(filename).Skip(1))
            {
                journeyModels.Add(new JourneyModel(row));
            }
            return journeyModels;
        }

        public static List<JourneyModel> LoadFromJSON(string filename)
        {
            return JsonConvert.DeserializeObject<JourneyModel[]>(File.ReadAllText(filename)).ToList();
        }
    }
}
