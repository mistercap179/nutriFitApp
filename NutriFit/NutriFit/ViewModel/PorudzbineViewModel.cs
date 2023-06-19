using NutriFit.Database.CRUD;
using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriFit.ViewModel
{
    public class PorudzbineViewModel
    {
        public ObservableCollection<Racun> Racuni { get; set; }
        public PorudzbineViewModel()
        {
            Racuni = new ObservableCollection<Racun>();
            RacunCRUD.Instance.GetAll().ToList().ForEach(racun => Racuni.Add(racun));
        }
    }
}
