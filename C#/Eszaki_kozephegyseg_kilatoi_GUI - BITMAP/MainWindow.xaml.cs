using Eszaki_kozephegyseg_kilatoi_GUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        public MainWindow()
        {
            InitializeComponent();

            context.Locations.Load();
            context.Viewpoints.Load();

            lbHegyseg.ItemsSource = context.Locations.Local.ToList();
            lbHegyseg.DisplayMemberPath = "Location1";

        }

        private void lbHegyseg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbHegyseg.SelectedItem != null)
            {

                Location location = (Location)lbHegyseg.SelectedItem;
                dgDetails.ItemsSource = location.Viewpoints.OrderByDescending(h => h.Height);
            }


        }

        private void dgDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgDetails.SelectedItem != null)
            {
                Viewpoint viewpoint = (Viewpoint)dgDetails.SelectedItem;
                txbDescription.Text = viewpoint.Description;
                imgImage.Source = new BitmapImage(new Uri(viewpoint.ImageUrl));

            }
        }
    }
}