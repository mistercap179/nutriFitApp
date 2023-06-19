using NutriFit.Database.Conversions;
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
        public PorudzbineViewModel(JelaViewModel jelaViewModel)
        {
            Racuni = new ObservableCollection<Racun>();
            RacunCRUD.Instance.GetAll().ToList().ForEach(racun => Racuni.Add(racun));
            jelaViewModel.DataChanged += Refresh;
        }

        public void Refresh(object sender, EventArgs e)
        {
            Racuni.Clear();
            RacunCRUD.Instance.GetAll().ToList().ForEach(racun => Racuni.Add(racun));
        }
    }
}
