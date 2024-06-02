using Microsoft.EntityFrameworkCore;
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
using wpf_Hianyzasok_2024.Models;

namespace wpf_Hianyzasok_2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HianyzasContext context = new HianyzasContext();

        Hianyza hianyzo;
        public MainWindow()
        {
            InitializeComponent();


            context.Hianyzas.Load();
        List<Hianyza> hianyzasok = context.Hianyzas.Local.ToList();
            lbNev.ItemsSource = hianyzasok;
            lbNev.DisplayMemberPath = "Nev";
        }

        private void lbNev_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbNev.SelectedItem != null)
            {
                hianyzo = (Hianyza)lbNev.SelectedItem;
                spDetails.DataContext = lbNev.SelectedItem;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            var osszesOraHiany = context.Hianyzas.Local.Sum(x => x.MulasztottOrak);

            lbCounter.Content = osszesOraHiany;

        }
    }
}