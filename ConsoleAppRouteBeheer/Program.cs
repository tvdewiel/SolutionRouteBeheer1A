using RouteBeheerDL.Model;
using RouteBeheerDL.Repos;

namespace ConsoleAppRouteBeheer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=NB21-6CDPYD3\\SQLEXPRESS;Initial Catalog=XRouteA;Integrated Security=True;Trust Server Certificate=True";
            NetworkReository nwrepo = new NetworkReository(connectionString);
            NetworkManager nm = new NetworkManager(nwrepo);
            nm.AddLocation(new Location("Gent"));
        }
    }
}
