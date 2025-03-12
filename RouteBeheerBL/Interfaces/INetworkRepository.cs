using RouteBeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteBeheerBL.Interfaces
{
    public interface INetworkRepository
    {
        void AddLocation(Location location);      
        bool HasLocationName(string name);      
        bool HasLocationId(int id);
        void UpdateLocation(Location location);
        List<Location> GetLocations();
    }
}
