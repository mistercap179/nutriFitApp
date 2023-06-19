using NutriFit.Database.Conversions;
using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.CRUD
{
    public class RacunCRUD : ICRUD<Racun>
    {
        private static readonly Lazy<RacunCRUD> _instance =
       new Lazy<RacunCRUD>(() => new RacunCRUD());
        DBConversion conversion = new DBConversion();

        public static RacunCRUD Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public bool Create(IDBModel item)
        {
            try
            {
                //potencijalno promeniti na dodavanje pojedinacnih
                //stavki pa onda tek racun
                Racuni racuni = item as Racuni;
                DBModels.Instance.Racuni.Add(racuni);
                DBModels.Instance.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(IModel item)
        {
            try
            {
                Racun racun = item as Racun;
                Racuni dbRacun = DBModels.Instance.Racuni.Where(r => r.id == racun.Id).FirstOrDefault();
                if (dbRacun != null)
                {
                    DBModels.Instance.Racuni.Remove(dbRacun);
                    DBModels.Instance.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public ICollection<Racun> GetAll()
        {

            ICollection<Racun> racuni = new List<Racun>();
            DBModels.Instance.Racuni.ToList().ForEach(racun =>
            racuni.Add(conversion.ConvertRacun(racun)));
            return racuni;
        }

        public bool Update(IModel item)
        {
            throw new NotImplementedException();
        }
    }
}
