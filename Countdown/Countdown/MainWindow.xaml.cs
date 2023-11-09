using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace Countdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime bevittDate;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(szamlalo);
        }

        private void buttonIndit_Click(object sender, RoutedEventArgs e)
        {
            bool dateTimeTenyleg = DateTime.TryParseExact(textBoxDatum.Text, "yyyy.MM.dd HH:mm:ss", null, DateTimeStyles.None, out DateTime datum);

            if (dateTimeTenyleg && DateTime.ParseExact(textBoxDatum.Text, "yyyy.MM.dd HH:mm:ss", null, DateTimeStyles.None) > DateTime.Now)
            {
                timer.Start();
            }
            else
            {
                MessageBox.Show("A dátum rossz formátumú.");
            }
        }

        private void szamlalo(object? sender, EventArgs e)
        {   
            szamlaloFrissit();
        }

        private void szamlaloFrissit()
        {
            bevittDate = DateTime.ParseExact(textBoxDatum.Text, "yyyy.MM.dd HH:mm:ss", null, DateTimeStyles.None);
            TimeSpan kulonbseg = bevittDate - DateTime.Now;
            int evek = Convert.ToInt32(kulonbseg.TotalDays / 365);
            int honapok = Convert.ToInt32(kulonbseg.TotalDays % 365 / 30);
            int napok = Convert.ToInt32(kulonbseg.TotalDays % 30);

            if (kulonbseg.TotalSeconds > 0)
            {
                textBlockTimer.Text = $"{evek} év {honapok} hó {napok} nap {kulonbseg.Hours}:{kulonbseg.Minutes}:{kulonbseg.Seconds}";
            }
            else
            {
                timer.Stop();
                MessageBox.Show("A timer leállt.");
            } 
        }
    }
}
