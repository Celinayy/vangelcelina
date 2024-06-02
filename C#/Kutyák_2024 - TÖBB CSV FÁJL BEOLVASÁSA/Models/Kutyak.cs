using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutyák_2024.Models
{
    public class Kutyak
    {
        //id;fajta_id;név_id;életkor;utolsó orvosi ellenőrzés
        public int id { get; set; }
        public KutyaFajtak fajtaId { get; set; }
        public KutyaNevek nevId { get; set; }
        public int eletkor { get; set; }
        public string utolsoOrvosiVizsgalatIdeje { get; set; }


        public Kutyak(string row, List<KutyaFajtak> kutyaFajtak, List<KutyaNevek> kutyaNevek)
        {
            var splittedRow = row.Split(';');

            id = int.Parse(splittedRow[0]);
            int kutyaFajtadId = int.Parse(splittedRow[1]);
            fajtaId = kutyaFajtak.Find(r => r.id == kutyaFajtadId);
            int kutyaNeveId = int.Parse(splittedRow[2]);
            nevId = kutyaNevek.Find(r => r.id == kutyaNeveId);
            eletkor = int.Parse(splittedRow[3]);
            utolsoOrvosiVizsgalatIdeje = splittedRow[4];
        }

        public static List<Kutyak> LoadKutyak(string filename, List<KutyaFajtak> kutyaFajtak, List<KutyaNevek> kutyaNevek)
        {
            List<Kutyak> kutyakLista = new List<Kutyak>();

            foreach (var item in File.ReadLines(filename).Skip(1))
            {
                kutyakLista.Add(new Kutyak(item, kutyaFajtak, kutyaNevek));
            }

            return kutyakLista;
        }
    }
}
