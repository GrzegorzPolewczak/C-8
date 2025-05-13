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
using KolZadaniA.Model;

namespace KolZadaniA;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DbKomis db = new DbKomis();
    public MainWindow()
    {
        InitializeComponent();
        OdswiezListe();
    }

    private void OdswiezListe()
    {
        lbxKomis.ItemsSource = db.Samochody.ToList();
        var sumaPrzeb = db.Samochody.Sum(s => s.Przebieg);
        lbSumaPrzebiegow.Content = $"Suma przebiegów: {sumaPrzeb}";
    }

    private void btnDodaj_Click(object sender, RoutedEventArgs e)
    {
        var s = new Samochod { Marka = txtMarka.Text, Model = txtModel.Text, RokProdukcji = Convert.ToInt32(txtRokProdukcji.Text), Przebieg = Convert.ToInt32(txtPrzebieg.Text) };

        db.Samochody.Add(s);
        db.SaveChanges();
        OdswiezListe();
    }

    private void btnUsun_Click(object sender, RoutedEventArgs e)
    {
        if(lbxKomis.SelectedItem is Samochod wybrany)
        {
            db.Samochody.Remove(wybrany);
            db.SaveChanges();
            OdswiezListe();
        }
    }
}