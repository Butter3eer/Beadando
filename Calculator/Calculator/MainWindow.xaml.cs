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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double elsoSzam;
        private double masodikSzam;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (uresMezoEllenorzes())
            {
                szamokErtekAdasa();
                textBlockEredmeny.Text = (elsoSzam + masodikSzam).ToString();
            }
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (uresMezoEllenorzes())
            {
                szamokErtekAdasa();
                textBlockEredmeny.Text = (elsoSzam - masodikSzam).ToString();
            }
        }

        private void buttonMulti_Click(object sender, RoutedEventArgs e)
        {
            if (uresMezoEllenorzes())
            {
                szamokErtekAdasa();
                textBlockEredmeny.Text = (elsoSzam * masodikSzam).ToString();
            } 
        }

        private void buttonDevi_Click(object sender, RoutedEventArgs e)
        {
            if (uresMezoEllenorzes())
            {
                szamokErtekAdasa();
                textBlockEredmeny.Text = Math.Round(elsoSzam / masodikSzam, 2).ToString();
            }    
        }

        private void buttonSzaz_Click(object sender, RoutedEventArgs e)
        {
            if (uresMezoEllenorzes())
            {
                szamokErtekAdasa();
                textBlockEredmeny.Text = (elsoSzam * (masodikSzam / 100)).ToString();
            }
        }

        private bool uresMezoEllenorzes()
        {
            bool tenylegSzam = int.TryParse(textBoxElso.Text, out int number);
            bool tenylegSzam2 = int.TryParse(textBoxMasodik.Text, out int number2);

            if (textBoxElso.Text == "" || textBoxMasodik.Text == "")
            {
                MessageBox.Show("Mind a 2 beviteli mező kitöltése kötelező.");
                textBoxElso.Text = "";
                textBoxMasodik.Text = "";
                return false;
            }
            else if (!tenylegSzam || !tenylegSzam2)
            {
                MessageBox.Show("Csak számokkal lehet számolni.");
                textBoxElso.Text = "";
                textBoxMasodik.Text = "";
                return false;
            }

            return true;
        }

        private void szamokErtekAdasa()
        {
            elsoSzam = Convert.ToInt32(textBoxElso.Text);
            masodikSzam = Convert.ToInt32(textBoxMasodik.Text);
        }
    }
}
