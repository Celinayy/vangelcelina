using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi_2024.Models
{
    public class Igeny
    {
        public string id { get; set; }
        public string indulas { get; set; }
        public string cel { get; set; }
        public int szemelyekSzama { get; set; }



        public Igeny(string row)
        {
                var splittedRow = row.Split(';');

            this.id = splittedRow[0];
            this.indulas = splittedRow[1];
            this.cel = splittedRow[2];
            this.szemelyekSzama = int.Parse((splittedRow[3]));

        }


        public static List<Igeny> LoadIgenyek(string filename)
        {
           List<Igeny> igenyek = new List<Igeny>(); 


            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                igenyek.Add(new Igeny(item));
            }
            return igenyek;
        }

    }
}
