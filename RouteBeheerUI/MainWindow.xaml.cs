using RouteBeheerBL.Exceptions;
using RouteBeheerBL.Managers;
using RouteBeheerBL.Model;
using RouteBeheerDL.Repos;
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

namespace RouteBeheerUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private NetworkManager networkManager;
    private string connectionString= "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=XRouteA;Integrated Security=True;Trust Server Certificate=True";
    public MainWindow()
    {
        InitializeComponent();
        networkManager = new NetworkManager(new NetworkRepository(connectionString));
    }

    private void ButtonAdd_Click(object sender, RoutedEventArgs e)
    {
        WindowAddLocation w = new WindowAddLocation(networkManager);
        w.ShowDialog();
    }

    private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
    {
        WindowUpdateLocation w = new WindowUpdateLocation(networkManager);
        w.ShowDialog();
    }
}