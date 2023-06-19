using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Models
{
    public class Racun
    {
        private Guid id;
        private List<Stavka> stavke;
        private float ukupnaCijena;

        public Guid Id { get => id; set => id = value; }
        public List<Stavka> Stavke { get => stavke; set => stavke = value; }
        public float UkupnaCijena { get => ukupnaCijena; set => ukupnaCijena = value; }
        public Racun(Guid id, List<Stavka> stavke, float ukupnaCijena)
        {
            Id = id;
            Stavke = stavke;
            UkupnaCijena = ukupnaCijena;
        }

        public Racun() { }
    }
}
