using NutriFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NutriFit.Views
{
    /// <summary>
    /// Interaction logic for NovoJeloView.xaml
    /// </summary>
    public partial class NovoJeloView : Window
    {
        public NovoJeloView()
        {
            InitializeComponent();
           
        } 
        public NovoJeloView(VrstaJela sok)
        {
            InitializeComponent();
            //229
            HideItems();
        }

        private void HideItems()
        {
            SastojciLabel.Visibility = Visibility.Collapsed;
            SastojciTextBox.Visibility = Visibility.Collapsed;
            ProteiniLabel.Visibility = Visibility.Collapsed;
            ProteiniTextBox.Visibility = Visibility.Collapsed;
            UgljeniHidratiLabel.Visibility = Visibility.Collapsed;
            UgljeniHidratiTextBox.Visibility = Visibility.Collapsed;
            KalorijeLabel.Visibility = Visibility.Collapsed;
            KalorijeTextBox.Visibility = Visibility.Collapsed;
            MastiLabel.Visibility = Visibility.Collapsed;
            MastiTextBox.Visibility = Visibility.Collapsed;
            VrstaLabel.Visibility = Visibility.Collapsed;
            VrstaListBox.Visibility = Visibility.Collapsed;
            TipLabel.Visibility = Visibility.Collapsed;
            TipListBox.Visibility = Visibility.Collapsed;
            // Calculate the new height of the window
            double originalHeight = this.Height;
            double newHeight = originalHeight - 250; // Adjust the value based on the height of the hidden items

            // Set the new height of the window
            this.Height = newHeight;
        }
    }
}
