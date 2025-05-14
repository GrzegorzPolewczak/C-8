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
using Kolokwium8GP.Model;

namespace Kolokwium8GP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DbBiblioteka db = new DbBiblioteka();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Odswiez()
        {
            lbxKsiazki.ItemsSource = db.Ksiazki.ToList();
            var sredniaStron = db.Ksiazki.Average(k => k.LiczbaStron);
            lbSredniaStron.Content = $"Średnia stron wszystkich książek: {sredniaStron}";
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {   
            var k = new Ksiazka { Tytul = txtTytul.Text, Autor = txtAutor.Text, ISBN = txtISBN.Text, LiczbaStron = Convert.ToInt32(txtLiczbaStron.Text)};

            db.Ksiazki.Add(k);
            db.SaveChanges();
            Odswiez();
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (lbxKsiazki.SelectedItem is Ksiazka wyb)
            {
                db.Ksiazki.Remove(wyb);
                db.SaveChanges();
                Odswiez();
            }
        }
    }
}