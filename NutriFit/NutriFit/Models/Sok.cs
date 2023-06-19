using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Models
{
    public class Sok
    {
        private Guid id;
        private float cijena;
        private int sifraKasa;
        private int kolicina;
        private string naziv;
        private string slika;


        public Guid Id { get => id; set => id = value; }
        public float Cijena { get => cijena; set => cijena = value; }
        public int SifraKasa { get => sifraKasa; set => sifraKasa = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Slika { get => slika; set => slika = value; }

        public Sok(Guid id, float cijena, int sifraKasa, int kolicina, string naziv, string slika)
        {
            Id = id;
            Cijena = cijena;
            SifraKasa = sifraKasa;
            Kolicina = kolicina;
            Naziv = naziv;
            Slika = slika;
        }

        public Sok() { }
    }
}
