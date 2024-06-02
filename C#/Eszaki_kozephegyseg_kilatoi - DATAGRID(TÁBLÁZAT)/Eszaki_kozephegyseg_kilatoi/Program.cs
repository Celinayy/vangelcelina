using Eszaki_kozephegyseg_kilatoi.Models;

namespace Eszaki_kozephegyseg_kilatoi
{
    internal class Program
    {


        static void Main(string[] args)
        {
            List<LocationModel> locations = LocationModel.loadLocations("locations.csv");
            List<ViewpointModel> viewpoints = ViewpointModel.loadViewpoints("viewpoints.csv", locations);

            var highestViewpoint = viewpoints.MaxBy(r => r.height);


            Console.WriteLine("6.feladat:\nMegnevezés: {0}\n\tHegy neve: {1}\n\tHegység neve: {2}\n\tMagasság: {3}", highestViewpoint.viewpointName, highestViewpoint.mountain, highestViewpoint.height);

        }
    }
}