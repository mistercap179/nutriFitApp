using GalaSoft.MvvmLight.Command;
using NutriFit.Database;
using NutriFit.Database.CRUD;
using NutriFit.Models;
using NutriFit.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NutriFit.ViewModel
{
    public class JelaViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Models.Jelo> Jela { get; set; }
        public Dictionary<Guid,Stavka> Stavke { get; set; }

        public ObservableCollection<string> ListBoxVrste = new ObservableCollection<string>();

        public ObservableCollection<Stavka> StavkeCollection { get; set; }

        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand OpenNovoJeloWindowCommand { get; set; }
        public ICommand DodajKorpaCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand PovecajBrojStavkiCommand { get; set; }
        public ICommand AddPorudzbinaCommand { get; set; }
        public ICommand ObrisiStavkuCommand { get; set; }


        public JelaViewModel()
        {
            Jela = new ObservableCollection<Jelo>();
            Stavke = new Dictionary<Guid, Stavka>();
            StavkeCollection = new ObservableCollection<Stavka>();
            
            ListBoxVrste  = new ObservableCollection<string>() { "Dorucak", "Potaz", "Kombinacija", "Pasta", "Rizoto", "Falafel", "Salata", "Pecivo", "Slatko" };
            JeloCRUD.Instance.GetAll().ToList().ForEach(item => Jela.Add(item));

            OpenNovoJeloWindowCommand = new RelayCommand(DodajJelo);
            DodajKorpaCommand = new RelayCommand<object>(DodajUkorpu);
            ObrisiStavkuCommand = new RelayCommand<object>(ObrisiIzKorpe);
            PovecajBrojStavkiCommand = new RelayCommand<object>(UvecajBrojStavke);
            AddPorudzbinaCommand = new RelayCommand(NovaPorudzbina);
            CancelCommand = new RelayCommand(CancelSearch);

        }
        public void CancelSearch() { }
        public void DodajJelo()
        {
            var novoJeloViewModel = new NovoJeloViewModel();
            var secondWindow = new NovoJeloView() { DataContext = novoJeloViewModel };
            secondWindow.Closed += SecondWindowClosed;
            secondWindow.Show();

        }

        public void DodajUkorpu(object param)
        {
            if (param is Jelo item)
            {
                if (!this.Stavke.ContainsKey(item.Id))
                {
                    this.Stavke.Add(item.Id,new Stavka 
                    { 
                        Id = item.Id,
                        JedinicnaCijena = item.Cijena,
                        Naziv = item.Naziv,
                        SifraKasa = item.SifraKasa,
                        Kolicina = 1,
                        UkupnaCijena = item.Cijena
                    });

                    StavkeCollection.Clear();
                    Stavke.Values.ToList().ForEach(stavka => this.StavkeCollection.Add(stavka));
                }
                else
                {
                    this.Stavke[item.Id].Kolicina++;
                    this.Stavke[item.Id].UkupnaCijena = this.Stavke[item.Id].Kolicina * this.Stavke[item.Id].JedinicnaCijena;
                    StavkeCollection.Clear();
                    Stavke.Values.ToList().ForEach(stavka => this.StavkeCollection.Add(stavka));

                }
            }

        }

        public void UvecajBrojStavke(object param)
        {
            if (param is Stavka item)
            {
                this.Stavke[item.Id].Kolicina++;
                this.Stavke[item.Id].UkupnaCijena = this.Stavke[item.Id].Kolicina * this.Stavke[item.Id].JedinicnaCijena;
                StavkeCollection.Clear();
                Stavke.Values.ToList().ForEach(stavka => this.StavkeCollection.Add(stavka));

            }
        }

        public void ObrisiIzKorpe(object param)
        {
            if (param is Stavka item)
            {
                this.Stavke[item.Id].Kolicina--;
                this.Stavke[item.Id].UkupnaCijena = this.Stavke[item.Id].Kolicina * this.Stavke[item.Id].JedinicnaCijena;

                if (this.Stavke[item.Id].Kolicina == 0)
                {
                    this.Stavke.Remove(item.Id);
                }

                StavkeCollection.Clear();
                Stavke.Values.ToList().ForEach(stavka => this.StavkeCollection.Add(stavka));
            }
        }


        public void NovaPorudzbina()
        {
            var ukupnaCijena = new double();
            ICollection<Stavke> stavke = new Collection<Stavke>();
            Stavke.Values.ToList().ForEach(item => stavke.Add(new Database.Stavke 
            {
                id = item.Id,
                idRacuna = item.IdRacuna,
                jedinicnaCijena = item.JedinicnaCijena,
                kolicina = item.Kolicina,
                naziv = item.Naziv,
                sifraKasa = item.SifraKasa,
                ukupnaCijena = item.UkupnaCijena
            }));

            stavke.ToList().ForEach(stavka => ukupnaCijena += stavka.ukupnaCijena);

            var racun = new Racuni
            {
                id = Guid.NewGuid(),
                Stavke = stavke,
                ukupnaCijena = ukupnaCijena
            };
            RacunCRUD.Instance.Create(racun);
            Stavke.Clear();
            StavkeCollection.Clear();
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
                JeloCRUD.Instance.GetAll().ToList().ForEach(item => Jela.Add(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Search()
        {
            if (SelectedItem == null )
            {
                MessageBox.Show("Izaberite tip pretrage");
            }
            else if (SelectedItem != null)
            {
                ObservableCollection<Models.Jelo> filteredJela = new ObservableCollection<Models.Jelo>();

                switch (SelectedItem)
                {
                    case "Dorucak":
                        Jela.Where(item => item.Tip.ToString() == SelectedItem);
                        break;
                    case "Potaz":
                        
                        break;
                    case "Kombinacija":
                        
                        break;
                    case "Pasta":
                       
                        break;
                    case "Rizoto":

                        break;
                    case "Falafel":

                        break;
                    case "Salata":

                        break;
                    case "Pecivo":

                        break;
                    case "Slatko":

                        break;
                }

                filteredJela = new ObservableCollection<Models.Jelo>();
                Jela.Clear();
                filteredJela.ToList().ForEach(item => Jela.Add(item));

            }

        }



    }
}
