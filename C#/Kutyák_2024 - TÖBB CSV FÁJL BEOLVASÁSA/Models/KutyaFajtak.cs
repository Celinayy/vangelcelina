using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyák_2024.Models
{
    public class KutyaFajtak
    {
        public int id { get; set; }
        public string magyarFajtaNev { get; set; }

        public string angolFajtaNev { get; set; }


        public KutyaFajtak(string row)
        {
            var splittedRow = row.Split(';');   

            id = int.Parse(splittedRow[0]);
            magyarFajtaNev = splittedRow[1];
            angolFajtaNev += splittedRow[2];
        }

        public static List<KutyaFajtak> LoadKutyaFajtak(string filename)
        {

            List<KutyaFajtak> kutyaFajtak = new List<KutyaFajtak>();

            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                kutyaFajtak.Add(new KutyaFajtak(item));
            }
            return kutyaFajtak;
        }

    }
}
