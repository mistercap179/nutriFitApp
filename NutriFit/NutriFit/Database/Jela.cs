namespace NutriFit.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jela")]
    public partial class Jela:IDBModel
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string vrstaJela { get; set; }

        [Required]
        public string naziv { get; set; }

        public string putanjaSlike { get; set; }

        public int sifraKasa { get; set; }

        [Required]
        public string sastojci { get; set; }

        public double cijena { get; set; }

        public double proteini { get; set; }

        public double ugljeniHidrati { get; set; }

        public double masti { get; set; }

        public double kalorije { get; set; }

        [Required]
        [StringLength(50)]
        public string tipJela { get; set; }
    }
}
