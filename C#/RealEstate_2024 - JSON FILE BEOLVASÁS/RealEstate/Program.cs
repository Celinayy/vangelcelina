using RealEstate.Models;

namespace RealEstate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> ads = Ad.LoadFromsJson("realestates.json");

            var avgFloors = ads.Where(f => f.Floors == 1).Average(f => f.Area);
            Console.WriteLine("1. Földszinti ingatlnaok átlagos alapterülete: {0:f2} m2", avgFloors);



            double lat = 47.4164220114023;
            double lon = 19.066342425796986;

            var closestRealEstate = ads.Where(a => a.FreeOfCharge)
                .OrderBy(b => b.DistanceTo(lat, lon))
                .First();

            Console.WriteLine("2. feladat:\nMesevárhoz legközelebb van:");
            Console.WriteLine("\tEladó neve: {0}", closestRealEstate.Seller.Name);
            Console.WriteLine("\tEladó telefonszáma: {0}", closestRealEstate.Seller.Phone);
            Console.WriteLine("\tAlapterület: {0}", closestRealEstate.Area);
            Console.WriteLine("\tSzoba szám: {0}", closestRealEstate.Rooms);




        }
    }
}