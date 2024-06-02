using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hianyzasok_2024.Models
{
    public class Hianyzas
    {

        //Név;Osztály;Első nap; Utolsó nap; Mulasztott órák

        public string Nev { get; set; }
        public string Osztaly { get; set; }
        public int Elso_nap { get; set; }
        public int Utolso_nap { get; set; }
        public int Mulasztott_orak { get; set; }




        public Hianyzas(string row)
        {
            var splitted = row.Split(';');

            Nev = splitted[0];
            Osztaly = splitted[1];
            Elso_nap = int.Parse(splitted[2]);
            Utolso_nap = int.Parse(splitted[3]);
            Mulasztott_orak = int.Parse(splitted[4]);

        }

        public static List<Hianyzas> LoadFromCsv(string filename)
        {
            List<Hianyzas> hianyzasok = new List<Hianyzas>();

            foreach (var row in File.ReadAllLines(filename).Skip(1))
            {
                hianyzasok.Add(new Hianyzas(row));    
            }

            return hianyzasok;
        }

    }
}
