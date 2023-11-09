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

namespace Masodfoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double szam1;
        private double szam2;
        private double szam3;
        private Random random = new Random();
        private double x1;
        private double x2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSzamol_Click(object sender, RoutedEventArgs e)
        {
            Szamol();
        }

        private void Szamol()
        {
            szam1 = Convert.ToDouble(textBoxElso.Text);
            szam2 = Convert.ToDouble(textBoxMasodik.Text);
            szam3 = Convert.ToDouble(textBoxHarmadik.Text);
            x1 = random.NextDouble() * 100;
            x2 = random.NextDouble() * 100;

            double discriminant = szam2 * szam2 - 4 * szam1 * szam3;

            if (discriminant >= 0)
            {
                double x1 = (-szam2 + Math.Sqrt(discriminant)) / (2 * szam1);
                double x2 = (-szam2 - Math.Sqrt(discriminant)) / (2 * szam1);

                if (x1 == x2)
                {
                    textBlockEredmeny.Text = $"x1 = x2 = {x2}";
                }
                else
                {
                    textBlockEredmeny.Text = $"x1 = {x1}\nx2 = {x2}";
                }            
            }
            else
            {
                textBlockEredmeny.Text = "Nem oldható meg a valós számok halmazán";
            }
        }
    }
}
