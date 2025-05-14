using Microsoft.Data.SqlClient;
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

namespace Lab9ZadanieA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
            public static async Task<(double x, double y, double wartosc)> ZnajdźMinimumFunkcji2D(
             double minX, double maxX,
             double minY, double maxY,
             long liczbaIteracji,
             Func<double, double, double> funkcja)
            {
                Random los = new Random();
                double? najlepszeX = null;
                double? najlepszeY = null;

                double minWartość = double.MaxValue;
            object semaforMinWartość = new object();

            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 3
            };

            //for (long i = 0; i < liczbaIteracji; i++)
            await Task.Factory.StartNew(() =>
            {

                Parallel.For(0, liczbaIteracji, (i) =>
                {
                    double x, y;
                    lock (los)
                    {
                        x = minX + los.NextDouble() * (maxX - minX);
                        y = minY + los.NextDouble() * (maxY - minY);
                    }
                    double wartość = funkcja(x, y);

                    lock (semaforMinWartość)
                    {
                        if (wartość < minWartość)
                        {
                            minWartość = wartość;
                            najlepszeX = x;
                            najlepszeY = y;
                        }
                    }
                });
            });

                return ((double)najlepszeX, (double)najlepszeY, minWartość);
            }

        

        private async void btnWyswietl_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection polaczenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                var command = new SqlCommand("EXEC [dbo].[sp_GetStudents]", polaczenie);
                await polaczenie.OpenAsync();

                var dr = await command.ExecuteReaderAsync();
                lbxLista.Items.Clear();
                while(await dr.ReadAsync())
                {
                    lbxLista.Items.Add($"{dr["Nazwisko"]} {dr["Wiek"]}");
                }
                polaczenie.Close();
               }
        }

        private async void btnKliknij2_Click(object sender, RoutedEventArgs e)
        {
            var wynik = await ZnajdźMinimumFunkcji2D(-5, -5, 5, 5, 100000000, (x, y) => x * x + y * y);
            MessageBox.Show($"{wynik}");
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            using (var s = new Student())
            {

            }

          
        }

        private void btnGarbage_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}