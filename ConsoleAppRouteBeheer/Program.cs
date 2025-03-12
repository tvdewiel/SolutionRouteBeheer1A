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
            NetworkRepository nwrepo = new NetworkRepository(connectionString);
            NetworkManager nm = new NetworkManager(nwrepo);
            //nm.AddLocation(new Location("Gent"));
            Location l1 = new Location(1,"Gent");
            l1.Name = "Ledeberg";
            nm.UpdateLocation(l1);

        }
    }
}
