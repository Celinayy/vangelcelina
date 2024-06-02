using Microsoft.EntityFrameworkCore;
using RealEstateGUI.Models;
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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IngatlanContext context = new IngatlanContext();
        Seller seller;
        public MainWindow()
        {
            InitializeComponent();

            context.Realestates.Load();

            context.Sellers.Load();
            lbSeller.ItemsSource = context.Sellers.Local.ToList();
            lbSeller.DisplayMemberPath = "Name";

        }

        private void lbSeller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSeller.SelectedItem != null)
            {
                seller = (Seller)lbSeller.SelectedItem;
                spDetails.DataContext = lbSeller.SelectedItem;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            lbCounter.Content = context.Realestates.Local
                .Where(r => r.SellerId == seller.Id)
                .Count()
                .ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbSeller.SelectedItem != null)
            {
                context.Sellers.Remove((Seller)lbSeller.SelectedItem).Context.SaveChanges();
                context.Sellers.Load();
                lbSeller.ItemsSource = context.Sellers.Local.ToList();
            }
        }
    }
}