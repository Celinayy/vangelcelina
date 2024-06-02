using Kutyák_2024.Models;
using System.Net.WebSockets;

namespace Kutyák_2024
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<KutyaNevek> kutyaNevekLista = KutyaNevek.LoadKutyaNevek("KutyaNevek.csv");
            List<KutyaFajtak> kutyaFajtakLista = KutyaFajtak.LoadKutyaFajtak("KutyaFajtak.csv");
            List<Kutyak> KutyakLista = Kutyak.LoadKutyak("Kutyak.csv", kutyaFajtakLista, kutyaNevekLista);


            Console.WriteLine("3. feladat: Kutyanevek száma: {0}", kutyaNevekLista.Count());

            var avgEletkor = KutyakLista.Average(r => r.eletkor);
            Console.WriteLine("4. feladat: Kutyák átlag életkora: {0:f2}", avgEletkor);


            var oldestDog = KutyakLista.MaxBy(r => r.eletkor);
            Console.WriteLine("5. feladat: Legidősebb kutya neve és fajtája: {0}, {1}", oldestDog.nevId.kutyaNev, oldestDog.fajtaId.magyarFajtaNev);


            // 8. feladat
            var fajtaDb = KutyakLista
                .Where(r => r.utolsoOrvosiVizsgalatIdeje == "2018.01.10").GroupBy(dog => dog.fajtaId.magyarFajtaNev).Select(csoport
                => new
                {
                    fajtaNeve = csoport.Key,
                    dbSzam = csoport.Count(),
                }).ToList();

            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták:");
            foreach (var dog in fajtaDb)
            {
                Console.WriteLine("\t{0}: {1} kutya", dog.fajtaNeve, dog.dbSzam);
            }

            //var dictionary = new Dictionary<string, int>();


            //foreach (var dog in dateKutyak)
            //{
            //    var fajtaNeve = dog.fajtaId.magyarFajtaNev;
            //    if( dictionary.ContainsKey(fajtaNeve) )
            //    {
            //        dictionary[fajtaNeve]++;
            //    }
            //    else
            //    {
            //        dictionary[fajtaNeve] = 1;
            //    }
            //}

            //foreach (var kutyaFajta in dictionary.Keys)
            //{
            //    Console.WriteLine("\t{0}: {1} kutya", kutyaFajta, dictionary[kutyaFajta]);
            //}


            // 9. feladat

            var a = KutyakLista.GroupBy(r => r.utolsoOrvosiVizsgalatIdeje).Select(r => new
            {
                datum = r.Key,
                counter  = r.Count()
            }).MaxBy(r => r.counter);


            Console.WriteLine("9. feladat: Legjobban leterhelt nap: {0}: {1} kutya", a.datum, a.counter);


            // 10. feladat

            var writeToFileDictionary = new Dictionary<string, int>();

            foreach(var dog in KutyakLista)
            {
                if(writeToFileDictionary.ContainsKey(dog.nevId.kutyaNev))
                {
                    writeToFileDictionary[dog.nevId.kutyaNev]++;
                }
                else
                {
                    writeToFileDictionary[dog.nevId.kutyaNev] = 1;

                }
            }

            using (StreamWriter writetext = new StreamWriter("Névstatisztika.txt"))
            {
                Console.WriteLine("10. feladat: Névstatisztika.txt");

                foreach (var item in writeToFileDictionary.Keys.OrderByDescending(key => writeToFileDictionary[key]))
                {
                    writetext.WriteLine("{0};{1}", item, writeToFileDictionary[item]);

                }
            }

        }

    }
}