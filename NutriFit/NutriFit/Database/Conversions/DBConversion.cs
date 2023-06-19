using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.Conversions
{
    public class DBConversion : IConversion
    {
        public Jelo ConvertJelo(Jela model)
        {
            return new Jelo
            {
                Id = model.id,
                Naziv = model.naziv,
                Slika = model.putanjaSlike,
                SifraKasa = model.sifraKasa,
                Sastojci = model.sastojci,
                Cijena = model.cijena,
                Proteini = model.proteini,
                UgljeniHidrati = model.ugljeniHidrati,
                Masti = model.masti,
                Kalorije = model.kalorije,
                Vrsta = (VrstaJela)Enum.Parse(typeof(VrstaJela), model.vrstaJela),
                Tip = (TipJela)Enum.Parse(typeof(TipJela), model.tipJela),
            };
            
        }

        public Racun ConvertRacun(Racuni model)
        {
            List<Stavka> listaStavki = new List<Stavka>();
            model.Stavke.ToList().ForEach(stavka => listaStavki.Add(ConvertStavka(stavka)));
            return new Racun
            {
                Id = model.id,
                UkupnaCijena = model.ukupnaCijena,
                Stavke = listaStavki
            };
        }

        public Sok ConvertSok(Sokovi model)
        {
            return new Sok
            {
                Id = model.id,
                Cijena = model.cijena,
                SifraKasa = model.sifraKasa,
                Kolicina = model.kolicina,
                Slika = model.putanjaSlike,
                Naziv = model.naziv
            };
        }

        public Stavka ConvertStavka(Stavke model)
        {
            return new Stavka
            {
                Id = model.id,
                Kolicina = model.kolicina,
                SifraKasa = model.sifraKasa,
                Naziv = model.naziv,
                JedinicnaCijena = model.jedinicnaCijena,
                UkupnaCijena = model.ukupnaCijena,
                IdRacuna = model.idRacuna
            };
        }
    }
}
