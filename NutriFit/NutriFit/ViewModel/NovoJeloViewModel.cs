using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using NutriFit.Database;
using NutriFit.Database.CRUD;
using NutriFit.Models;
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
    public class NovoJeloViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Tipovi { get; set; }
        public ObservableCollection<string> Vrste { get; set; }

        public ICommand BrowseCommand { get; }
        public ICommand AddCommand { get; }

        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }

        private string slika;
        public string Slika
        {
            get { return slika; }
            set
            {
                slika = value;
                OnPropertyChanged(nameof(Slika));
            }
        }

        private int sifraKasa;
        public int SifraKasa
        {
            get { return sifraKasa; }
            set
            {
                sifraKasa = value;
                OnPropertyChanged(nameof(SifraKasa));
            }
        }

        private string sastojci;
        public string Sastojci
        {
            get { return sastojci; }
            set
            {
                sastojci = value;
                OnPropertyChanged(nameof(Sastojci));
            }
        }

        private double cijena;
        public double Cijena
        {
            get { return cijena; }
            set
            {
                cijena = value;
                OnPropertyChanged(nameof(Cijena));
            }
        }


        private double proteini;
        public double Proteini
        {
            get { return proteini; }
            set
            {
                proteini = value;
                OnPropertyChanged(nameof(Proteini));
            }
        }

        private double ugljeniHidrati;
        public double UgljeniHidrati
        {
            get { return ugljeniHidrati; }
            set
            {
                ugljeniHidrati = value;
                OnPropertyChanged(nameof(UgljeniHidrati));
            }
        }
        private double kalorije;
        public double Kalorije
        {
            get { return kalorije; }
            set
            {
                kalorije = value;
                OnPropertyChanged(nameof(Kalorije));
            }
        }
        private double masti;
        public double Masti
        {
            get { return masti; }
            set
            {
                masti = value;
                OnPropertyChanged(nameof(Masti));
            }
        }

        private VrstaJela vrsta;
        public VrstaJela Vrsta
        {
            get { return vrsta; }
            set
            {
                vrsta = value;
                OnPropertyChanged(nameof(Vrsta));
            }
        }

        private TipJela tip;
        public TipJela Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged(nameof(Tip));
            }
        }


        private void Browse()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                Slika = openFileDialog.FileName;
            }
        }


        public NovoJeloViewModel()
        {
            Tipovi = new ObservableCollection<string>() { "Jelo", "Dodatak", "Prilog"};
            Vrste = new ObservableCollection<string>() { "Dorucak","Potaz","Kombinacija","Pasta","Rizoto","Falafel","ObrokSalata","Pecivo", "Slatko"};
            AddCommand = new RelayCommand(AddJelo);
            BrowseCommand = new RelayCommand(Browse);
        }


        public void AddJelo()
        {
            var jelo = new Jela
            {
                id = new Guid(),
                naziv = Naziv,
                putanjaSlike = Slika,
                sifraKasa = SifraKasa,
                sastojci = Sastojci,
                cijena = Cijena,
                proteini = Proteini,
                ugljeniHidrati = UgljeniHidrati,
                kalorije = Kalorije,
                masti = Masti,
                vrstaJela = Vrsta.ToString(),
                tipJela = Tip.ToString()
            };

            if (!IsFormValid())
            {
                MessageBox.Show("Niste popunili sva polja forme!");
            }
            else
            {
                insertJelo(jelo);
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsFormValid()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Naziv) || string.IsNullOrWhiteSpace(Slika)
                || string.IsNullOrWhiteSpace(Sastojci))
            {
                isValid = false;
            }

            if (Cijena <= 0 || Proteini <= 0 || UgljeniHidrati <= 0 || Kalorije <= 0 || Masti <= 0)
            {
                isValid = false;
            }

            if (SifraKasa <= 0)
            {
                isValid = false;
            }

            return isValid;
        }


        public void insertJelo(Jela jelo)
        {
            JeloCRUD.Instance.Create(jelo);
            RefreshForm();
        }

        public void RefreshForm()
        {
           
            Naziv = string.Empty;
            Slika = string.Empty;
            SifraKasa = 0;
            Sastojci = string.Empty;
            Cijena = 0;
            Proteini = 0;
            UgljeniHidrati = 0;
            Kalorije = 0;
            Masti = 0;
            Vrsta = VrstaJela.Dorucak;
            Tip = TipJela.Jelo;

            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }
    }

}
