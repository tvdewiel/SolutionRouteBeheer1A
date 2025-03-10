using RouteBeheerDL.Model;
using RouteBeheerDL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppRouteBeheer
{
    public class NetworkManager
    {
        private NetworkReository repo;

        public NetworkManager(NetworkReository repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            try
            {
                if (repo.HasLocation(location)) throw new NetworkException("Location already exists");
                repo.AddLocation(location);
            }
            catch(Exception ex)
            {
                throw new NetworkException("AddLocation", ex);
            }
        }
    }
}
