using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Ad
    {

        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }

        public Seller Seller { get; set; }

        public Ad()
        {

        }
        public double Lat
        {
            get
            {
                return double.Parse(LatLong.Split('.')[0].Replace('.', ','));
            }

        }
        public double Long
        {
            get
            {
                return double.Parse(LatLong.Split('.')[1].Replace('.', ','));
            }

        }




        public static List<Ad> LoadFromsJson(string filename)
        {
            var json = File.ReadAllText(filename);
            var result = JsonConvert.DeserializeObject<List<Ad>>(json);
            return result;
        }

        public double DistanceTo(double lat, double lon)
        {
            var a = Lat - lat;
            var b = Long - lon;
            return Math.Sqrt(a * a + b * b);
        }

    }
}
