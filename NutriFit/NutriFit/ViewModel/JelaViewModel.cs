using GalaSoft.MvvmLight.Command;
using NutriFit.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NutriFit.ViewModel
{
    public class JelaViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Models.Jelo> Jela { get; set; }
        public Dictionary<Guid,int> Stavke { get; set; }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                OnPropertyChanged(nameof(Filter));
            }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand OpenNovoJeloWindowCommand { get; set; }

        public ICommand DodajKorpaCommand { get; set; }

        public JelaViewModel()
        {
            //this.service.getStudenti().ForEach(item => Jela.Add(item));
            Jela = new ObservableCollection<Models.Jelo> { new Models.Jelo { Kalorije = 123123, Cijena = 123123 ,Slika = "C://Users//marko//OneDrive//Desktop//NutriFit//NutriFit//NutriFit//Images//addbutton.png" } };
            OpenNovoJeloWindowCommand = new RelayCommand(DodajJelo);
           // DodajKorpaCommand = new RelayCommand<object>(DodajUkorpu()); 

        }

        public void DodajJelo()
        {
            var novoJeloViewModel = new NovoJeloViewModel();
            var secondWindow = new NovoJeloView() { DataContext = novoJeloViewModel };
            secondWindow.Closed += SecondWindowClosed;
            secondWindow.Show();

        }

        public void DodajUkorpu()
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SecondWindowClosed(object sender, EventArgs e)
        {
            Jela.Clear();
            try
            {
                //this.service.getStudenti().ForEach(item => Students.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
