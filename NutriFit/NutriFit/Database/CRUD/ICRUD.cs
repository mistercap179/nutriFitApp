using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.Database.CRUD
{
    public interface ICRUD<T> where T : IModel
    {
        ICollection<T> GetAll();
        bool Create(IDBModel item);
        bool Update(IModel item);
        bool Delete(IModel item);
    }
}
