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
using ZadanieBLab8.Model;

namespace ZadanieBLab8
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

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DbUczelnia())
            {

                foreach(var student in db.Studenci.OrderBy(s=>s.Nazwisko))
                {
                    lbxListaStudentow.Items.Add(student);
                }

                var sredniaOcen = db.Studenci.Average(s=>s.Ocena);
                lbSredniaOcen.Content = $"Średnia ocen: {sredniaOcen:F2}";
            }
        }
    }
}