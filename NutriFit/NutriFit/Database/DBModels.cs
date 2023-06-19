using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NutriFit.Database
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }
        private static readonly Lazy<DBModels> _instance =
            new Lazy<DBModels>(() => new DBModels());

        public static DBModels Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public virtual DbSet<Jela> Jela { get; set; }
        public virtual DbSet<Racuni> Racuni { get; set; }
        public virtual DbSet<Sokovi> Sokovi { get; set; }
        public virtual DbSet<Stavke> Stavke { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Racuni>()
                .HasMany(e => e.Stavke)
                .WithOptional(e => e.Racuni)
                .HasForeignKey(e => e.idRacuna);
        }
    }
}
