using Hianyzasok_2024.Models;

namespace Hianyzasok_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Hianyzas> hianyzasok = Hianyzas.LoadFromCsv("szeptember.csv");

            var osszesHianyzas = hianyzasok.Sum(x => x.Mulasztott_orak);

            Console.WriteLine("2. feladat\nÖsszes mulasztott órák száma: {0} óra.", osszesHianyzas);


            Console.Write("3. feladat\n\tKérem adjon meg egy napot: ");
            int userNap = int.Parse(Console.ReadLine());

            Console.Write("\tTanuló neve: ");
            string userNev = Console.ReadLine();

            bool isHianyzott = hianyzasok.Any(x => x.Nev == userNev);


            Console.WriteLine("4. feladat");


            if (isHianyzott)
            {
                Console.WriteLine("\tA tanuló hiányzott szeptemberben");
            }
            else
            {
                Console.WriteLine("\tA tanuló NEM hiányzott szeptemberben");
            }


            Console.WriteLine("5. feladat: Hiányzók 2017.09.{0}-n:", userNap);


            var hianyzottakNapon = hianyzasok.Where(x => userNap >= x.Elso_nap && userNap <= x.Utolso_nap);

            foreach (var tanulo in hianyzottakNapon)
            {
                Console.WriteLine("\t{0} ({1})", tanulo.Nev, tanulo.Osztaly);
            }

            Dictionary<string, string> stat = new Dictionary<string, string>();
            foreach (var t in hianyzottakNapon)
            {
                stat.Add(t.Nev, t.Osztaly);
            }

            Console.WriteLine("STATISZTIKÁVAL 5. feladat: Hiányzók 2017.09.{0}-n:", userNap);
            foreach (var tanulo in stat)
            {
                Console.WriteLine("\t{0} ({1})", tanulo.Key, tanulo.Value);
            }





            Dictionary<string, int> statMulasztott = new Dictionary<string, int>();

            foreach (var t in hianyzasok)
            {
                var ujMulasztottOrak = t.Mulasztott_orak;

                if(statMulasztott.ContainsKey(t.Osztaly))
                {
                    ujMulasztottOrak += statMulasztott[t.Osztaly];
                } 

                statMulasztott[t.Osztaly] = ujMulasztottOrak;
            }
            



           
           using (StreamWriter outputFile = new StreamWriter(Path.Combine("osszesites.csv ")))
           {
               foreach (string osztaly in statMulasztott.Keys)
                {
                    outputFile.WriteLine("{0};{1}", osztaly, statMulasztott[osztaly]);
                }
            }
        }
    }
}