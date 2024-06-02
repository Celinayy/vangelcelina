using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Telekocsi_2024.Models
{
    public class Auto
    {
        public string indulas { get; set; }
        public string cel { get; set; }
        public string rendszam { get; set; }
        public string telefonszam { get; set; }
        public int ferohely { get; set; }




        public Auto(string row)
        {
            var splittedRow = row.Split(';');   

            this.indulas = splittedRow[0];
            this.cel = splittedRow[1];
            this.rendszam = splittedRow[2]; 
            this.telefonszam = splittedRow[3];
            this.ferohely = int.Parse(splittedRow[4]);
        }


        public static List<Auto> LoadAutok(string filename)
        {
            List<Auto> autok = new List<Auto>();

            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                autok.Add(new Auto(item));
            }
            return autok;
            

        }
    }
}
