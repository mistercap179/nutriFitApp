using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Models
{
    public class Jelo : IModel
    {
        private Guid id;
        private string naziv;
        private string slika;
        private int sifraKasa;
        private string sastojci;
        private double cijena;
        private double proteini;
        private double ugljeniHidrati;
        private double kalorije; 
        private double masti;
        private VrstaJela vrsta;
        private TipJela tip;

        public Guid Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Slika { get => slika; set => slika = value; }
        public int SifraKasa { get => sifraKasa; set => sifraKasa = value; }
        public string Sastojci { get => sastojci; set => sastojci = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public double Proteini { get => proteini; set => proteini = value; }
        public double UgljeniHidrati { get => ugljeniHidrati; set => ugljeniHidrati = value; }
        public double Kalorije { get => kalorije; set => kalorije = value; }
        public double Masti { get => masti; set => masti = value; }
        public VrstaJela Vrsta { get => vrsta; set => vrsta = value; }
        public TipJela Tip { get => tip; set => tip = value; }

        public Jelo(Guid id, string naziv, string slika, int sifraKasa, string sastojci, double cijena,
                   double proteini, double ugljeniHidrati, double kalorije, double masti, VrstaJela vrsta, TipJela tip)
        {
            Id = id;
            Naziv = naziv;
            Slika = slika;
            SifraKasa = sifraKasa;
            Sastojci = sastojci;
            Cijena = cijena;
            Proteini = proteini;
            UgljeniHidrati = ugljeniHidrati;
            Kalorije = kalorije;
            Masti = masti;
            Vrsta = vrsta;
            Tip = tip;
        }

        public Jelo() { }
    }
}
