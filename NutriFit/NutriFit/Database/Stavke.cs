namespace NutriFit.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stavke")]
    public partial class Stavke : IDBModel
    {
        public Guid id { get; set; }

        [Required]
        public string naziv { get; set; }

        public int kolicina { get; set; }

        public int sifraKasa { get; set; }

        public double jedinicnaCijena { get; set; }

        public double ukupnaCijena { get; set; }

        public Guid? idRacuna { get; set; }

        public virtual Racuni Racuni { get; set; }
    }
}
