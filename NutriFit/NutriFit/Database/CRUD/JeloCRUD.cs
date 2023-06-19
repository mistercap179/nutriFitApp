using NutriFit.Database.Conversions;
using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.CRUD
{
    public class JeloCRUD : ICRUD<Jelo>
    {
        private static readonly Lazy<JeloCRUD> _instance =
         new Lazy<JeloCRUD>(() => new JeloCRUD());
        DBConversion  conversion = new DBConversion(); 

        public static JeloCRUD Instance
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
                Jela jelo = item as Jela; 
                DBModels.Instance.Jela.Add(jelo);
                DBModels.Instance.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                // Iterate through each validation error
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Get the error message and property name
                        string errorMessage = validationError.ErrorMessage;
                        string propertyName = validationError.PropertyName;

                        // Handle or log the validation error as needed
                        Console.WriteLine($"Validation error: Property '{propertyName}', Error: '{errorMessage}'");
                    }
                }
                return false;
            }
        }

        public bool Delete(IModel item)
        {
            try
            {
                Jelo jelo = item as Jelo;
                Jela dbJelo = DBModels.Instance.Jela.Where(j => j.id == jelo.Id).FirstOrDefault();
                if (dbJelo != null)
                {
                    DBModels.Instance.Jela.Remove(dbJelo);
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

       
        public bool Update(IModel item)
        {
            try
            {
                return true;

            }
            catch
            {
                return false;
            }
        }

        public ICollection<Jelo> GetAll()
        {
            try
            {
                ICollection<Jelo> jela = new List<Jelo>();
                DBModels.Instance.Jela.ToList().ForEach(jelo => jela.Add(conversion.ConvertJelo(jelo)));
                return jela;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.InnerException.Message);
                return null;
            }
        }
    }
}
