using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Models
{
    public class Stavka : IModel
    {
        private Guid id;
        private int kolicina;
        private string naziv;
        private int sifraKasa;
        private double jedinicnaCijena;
        private double ukupnaCijena;
        private Guid? idRacuna;
        public Guid Id { get => id; set => id = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int SifraKasa { get => sifraKasa; set => sifraKasa = value; }
        public double JedinicnaCijena { get => jedinicnaCijena; set => jedinicnaCijena = value; }
        public double UkupnaCijena { get => ukupnaCijena; set => ukupnaCijena = value; }
        public Guid? IdRacuna { get => idRacuna; set => idRacuna = value; }

        public Stavka(Guid id, int kolicina, string naziv, int sifraKasa, double jedinicnaCijena, double ukupnaCijena, Guid? idRacuna)
        {
            Id = id;
            Kolicina = kolicina;
            Naziv = naziv;
            SifraKasa = sifraKasa;
            JedinicnaCijena = jedinicnaCijena;
            UkupnaCijena = ukupnaCijena;
            IdRacuna = idRacuna;
        }

        public Stavka() { }
    }
}
