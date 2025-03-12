using RouteBeheerBL.Exceptions;
using RouteBeheerBL.Managers;
using RouteBeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RouteBeheerUI
{
    /// <summary>
    /// Interaction logic for WindowUpdateLocation.xaml
    /// </summary>
    public partial class WindowUpdateLocation : Window
    {
        private NetworkManager networkManager;
        public WindowUpdateLocation(NetworkManager networkManager)
        {
            InitializeComponent();
            this.networkManager = networkManager;
            ComboBoxLocations.ItemsSource = networkManager.GetLocations();
            ComboBoxLocations.SelectedIndex = 0;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = (Location)ComboBoxLocations.SelectedItem;
                location.Name = TextBoxLocationName.Text;
                networkManager.UpdateLocation(location);
                MessageBox.Show($"{location}", "Location Updated", MessageBoxButton.OK);
                TextBoxLocationName.Text = "";
            }
            catch (NetworkException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK);
            }
        }
    }
}
