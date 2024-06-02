using Eszaki_kozephegyseg_kilatoi_GUI.Models;
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

namespace Eszaki_kozephegyseg_kilatoi_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NcmviewpointsContext context = new NcmviewpointsContext();
        Viewpoint viewpoint;

        public MainWindow()
        {
            InitializeComponent();

            context.Viewpoints.Load();
            context.Locations.Load();

            lbHegyseg.ItemsSource = context.Locations.Local.ToList();
            lbHegyseg.DisplayMemberPath = "Location1";
        }

        private void lbHegyseg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          dgDetails.ItemsSource = context.Viewpoints.Local.Where(v => v.LocationNavigation == (Location)lbHegyseg.SelectedItem).OrderByDescending(x => x.Height);
        }
    }
}