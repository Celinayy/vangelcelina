using Telekocsi_2024.Models;
using System.IO;

namespace Telekocsi_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = Auto.LoadAutok("autok.csv");
            List<Igeny> igenyek = Igeny.LoadIgenyek("igenyek.csv");

            // 2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("\t{0} autós hirdet fuvart.", autok.Count());

            // 3. feladat
            Console.WriteLine("3. feladat");
            var bpToMiskolc = autok.Where(a => a.indulas == "Budapest" && a.cel == "Miskolc").Count();
            Console.WriteLine("\tÖsszesen {0} férőhelyet hírdettek az autósok Budapestről Miskolcra.", bpToMiskolc);


            // 4. feladat
            Console.WriteLine("4. feladat");
            var mostFerohely = autok.MaxBy(a => a.ferohely);
            Console.WriteLine("A legtöbb férőhelyet ({0}) a {1} - {2} útvonalon ajánlották fel a hírdetők.", mostFerohely.ferohely, mostFerohely.indulas, mostFerohely.cel);


            // 5. feladat
            List<Auto> elerhetoAutok;
            elerhetoAutok= autok.OrderBy(a => a.ferohely).ToList();

            Console.WriteLine("5. feladat");
            foreach (var igeny in igenyek)
            {

                var auto = elerhetoAutok.Find(a => a.cel == igeny.cel && a.indulas == igeny.indulas && a.ferohely >= igeny.szemelyekSzama);

                if (auto != null )
                {
                    Console.WriteLine("{0} => {1}", igeny.id, auto.rendszam);
                    elerhetoAutok.Remove(auto);
                }

            }

            // 6. feladat
            Console.WriteLine("6. feladat: utazasuzenetek.txt");

            elerhetoAutok = autok.OrderBy(a => a.ferohely).ToList();
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("utazasuzenetek.txt")))
            {
                foreach (var igeny in igenyek)
                {

                    var auto = elerhetoAutok.Find(a => a.cel == igeny.cel && a.indulas == igeny.indulas && a.ferohely >= igeny.szemelyekSzama);

                    if (auto != null)
                    {
                        outputFile.WriteLine("{0}: Rendszám: {1}, Telefonszám: {2}", igeny.id, auto.rendszam, auto.telefonszam);
                        elerhetoAutok.Remove(auto);
                    }
                    else
                    {
                        outputFile.WriteLine("{0}: Sajnos nem sikerült autót találni!", igeny.id);
                    }

                }
            }



        }
    }
}