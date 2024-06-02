using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyák_2024.Models
{
    public class KutyaNevek
    {
        public int id { get; set; }
        public string kutyaNev { get; set; }

        public KutyaNevek(string row)
        {
            var splittedRow = row.Split(";");
            id = int.Parse(splittedRow[0]);
            kutyaNev = splittedRow[1];
        }


        public static List<KutyaNevek> LoadKutyaNevek(string filename)
        {
             List<KutyaNevek> kutyaNevek = new List<KutyaNevek>();


            foreach (var item in File.ReadLines(filename).Skip(1))
            {
                kutyaNevek.Add(new KutyaNevek(item));  
            }
            return kutyaNevek;
        }
    }
}
