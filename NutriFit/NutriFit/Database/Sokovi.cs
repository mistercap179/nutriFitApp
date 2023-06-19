namespace NutriFit.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sokovi")]
    public partial class Sokovi
    {
        public Guid id { get; set; }

        public double cijena { get; set; }

        public double kolicina { get; set; }

        [Required]
        public string naziv { get; set; }

        public string putanjaSlike { get; set; }

        public int sifraKasa { get; set; }
    }
}
