using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Lotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Random random = new Random();
        private int counter = 0;
        private int huzasSzamok = 5;
        private List<int> sorsolasok = new List<int>();
        private int randomNumber;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.10);
            timer.Tick += new EventHandler(timerEvent);
        }

        private void buttonSorsol_Click(object sender, RoutedEventArgs e)
        {
            buttonSorsolFunction();
            
        }

        private void buttonSorsolFunction()
        {
            if (huzasSzamok == 0)
            {
                textBlockHuzasok.Text = "";
                textBlockEredmeny.Text = "";

                var sorsolasokRendezett = sorsolasok;
                sorsolasokRendezett.Sort();
                sorsolasokRendezett.ForEach(item => textBlockHuzasok.Text += item + " ");

                sorsolasok.Clear();
                huzasSzamok = 5;
                buttonSorsol.Content = "Sorsol";
            }
            else
            {
                if (huzasSzamok == 1)
                {
                    buttonSorsol.Content = "Rendez";
                }

                timer.Start();
                counter = 0;
                huzasSzamok--;
            }
        }

        private void sorsolas()
        {
            randomNumber = random.Next(1, 101);
            
            while (sorsolasok.Contains(randomNumber))
            {
                randomNumber = random.Next(1, 101);
            }

            sorsolasok.Add(randomNumber);
            textBlockEredmeny.Text = randomNumber.ToString();
            textBlockHuzasok.Text = "";
            sorsolasok.ForEach(item => textBlockHuzasok.Text += item + " ");
        }

        private void timerEvent(object? sender, EventArgs e)
        {
            counter++;

            if (counter > 2)
            {
                timer.Stop();
                sorsolas();
            }
            else
            {
                textBlockEredmeny.Text = random.Next(1, 101).ToString();
            }
        }
    }
}
