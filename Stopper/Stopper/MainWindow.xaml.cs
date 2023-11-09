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
using System.Windows.Threading;

namespace Stopper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime startTime;
        private TimeSpan eltelt;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(szamlalo);
        }

        private void szamlalo(object? sender, EventArgs e)
        {
            eltelt = DateTime.Now - startTime;
            textBlockTimer.Text = eltelt.ToString("mm':'ss':'fff");
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                buttonStart.Content = "Stop";
                buttonReset.Content = "Részidő";
                startTime = DateTime.Now;
                timer.Start();
            }
            else
            {
                buttonStart.Content = "Start";
                buttonReset.Content = "Reset";
                timer.Stop();
            }
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            if (buttonReset.Content.ToString() == "Reset")
            {
                startTime = DateTime.Now;
                textBlockTimer.Text = "00:00:000";
                listBoxReszidok.Items.Clear();
            }
            else
            {
                listBoxReszidok.Items.Add(textBlockTimer.Text);
            }
        }
    }
}
