namespace Journeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<JourneyModel> journeys = JourneyModel.LoadFromCsv("journeys.csv");
            List<JourneyModel> journeys = JourneyModel.LoadFromJSON("journeys.json");

            //6. feladat LINQ
            var earliest = journeys
                .Where(j => j.Vehicle.Type == "repülőgép")
                .OrderBy(j => j.Departure)
                .First();

            Console.WriteLine("6. feladat:");
            foreach (var item in journeys.Where(j => j.Vehicle.Type == "repülőgép"))
            {
                if (item ==  earliest)
                    Console.WriteLine($"\t{item.Country} - legkorábbi ({item.Departure.ToShortDateString()})");
                else
                    Console.WriteLine($"\t{item.Country}");
            }

            //6. feladat LINQ mentes
            Console.WriteLine("6. feladat LINQ nélkül");
            JourneyModel earliest2 = null;
            foreach (var item in journeys)
            {
                if (item.Vehicle.Type == "repülőgép")
                {
                    if (earliest2 == null || item.Departure < earliest2.Departure)
                    {
                        earliest2 = item;
                    }
                }
            }

            foreach (var item in journeys)
            {
                if (item.Vehicle.Type == "repülőgép")
                {
                    if (item == earliest2)
                        Console.WriteLine($"\t{item.Country} - legkorábbi ({item.Departure.ToShortDateString()})");
                    else
                        Console.WriteLine($"\t{item.Country}");
                }
            }

            //7. feladat - LINQ
            Console.WriteLine("7. feladat");
            var stat = journeys
                        .GroupBy(j => j.Vehicle.Type)
                        .Select(g => new
                                        {
                                            Vehicle = g.Key,
                                            Count = g.Count(),
                                            Sum = g.Sum(j => j.Capacity),
                                            Independent = g.Any(j => j.Capacity == null)
                                        });
            foreach (var item in stat)
            {
                if (item.Independent)
                    Console.WriteLine($"\t{item.Vehicle} : {item.Count} utazás, önálló szervezés");
                else
                    Console.WriteLine($"\t{item.Vehicle} : {item.Count} utazás, férőhely összesen {item.Sum} fő");
            }

            //7. feladat - LINQ nélkül
            Console.WriteLine("7. feladat - LINQ nélkül");
            Dictionary<string, int> stat2 = new Dictionary<string, int>();
            foreach (var item in journeys)
            {
                if (stat2.ContainsKey(item.Vehicle.Type))
                    stat2[item.Vehicle.Type]++;
                else
                    stat2.Add(item.Vehicle.Type, 1);
            }
            foreach (var item in stat2)
            {
                int? totalCapacity = 0;
                foreach (var j in journeys)
                {
                    if (j.Vehicle.Type == item.Key)
                        totalCapacity += j.Capacity;
                }
                Console.Write($"\t{item.Key} - {item.Value} utazás");
                Console.WriteLine(totalCapacity == null ? ", önálló szervezés" : $", férőhely összesen {totalCapacity} fő");
            }
        }
    }
}
