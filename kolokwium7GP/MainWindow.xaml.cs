using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace kolokwium7GP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAnalizuj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog plik = new OpenFileDialog
            {
                Filter = "Pliki logów|*.log;*.txt"
            };

            if (plik.ShowDialog() == true)
            {
                var linie = File.ReadAllLines(plik.FileName);
                int licznik = linie.Count(l => l.IndexOf("ERROR", StringComparison.OrdinalIgnoreCase) >= 0);

                MessageBox.Show($"Ilość linii error: {licznik}");
            }
        }
    }
}