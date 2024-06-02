using JourneysGUI.Models;
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

namespace JourneysGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UtazasokContext context = new UtazasokContext();
        
        public MainWindow()
        {
            InitializeComponent();
            context.Journeys.Load();

            DataContext = context.Vehicles.ToList();
        }

        private void lbxVihcles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var journeys = context.Journeys
                                    .Where(j => j.VehicleNavigation == (Vehicle)lbxVihcles.SelectedItem)
                                    .ToList();
            cboJourneys.ItemsSource = journeys;
        }

    }
}