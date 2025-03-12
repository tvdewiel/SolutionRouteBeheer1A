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
    /// Interaction logic for WindowAddLocation.xaml
    /// </summary>
    public partial class WindowAddLocation : Window
    {
        private NetworkManager networkManager;
        public WindowAddLocation(NetworkManager networkManager)
        {
            InitializeComponent();
            this.networkManager = networkManager;
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("klikt doet niets");
            try
            {
                Location location = new Location(TextBoxLocationName.Text);
                networkManager.AddLocation(location);
                MessageBox.Show($"{location}", "Location Added", MessageBoxButton.OK);
                TextBoxLocationName.Text = "";
            }
            catch (NetworkException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK);
            }
        }
    }
}
