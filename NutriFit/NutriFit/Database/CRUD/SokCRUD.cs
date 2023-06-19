using NutriFit.Database.Conversions;
using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.CRUD
{
    public class SokCRUD : ICRUD<Sok>
    {
        private static readonly Lazy<SokCRUD> _instance =
         new Lazy<SokCRUD>(() => new SokCRUD());
        DBConversion conversion = new DBConversion();

        public static SokCRUD Instance
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
                Sokovi sok= item as Sokovi;
                DBModels.Instance.Sokovi.Add(sok);
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
                Sok sok = item as Sok;
                Sokovi dbSok = DBModels.Instance.Sokovi.Where(s => s.id == sok.Id).FirstOrDefault();
                if (dbSok != null)
                {
                    DBModels.Instance.Sokovi.Remove(dbSok);
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

        public ICollection<Sok> GetAll()
        {
            ICollection<Sok> sokovi = new List<Sok>();
            DBModels.Instance.Sokovi.ToList().ForEach(sok => sokovi.Add(conversion.ConvertSok(sok)));
            return sokovi;
        }

        public bool Update(IModel item)
        {
            throw new NotImplementedException();
        }
    }
}
