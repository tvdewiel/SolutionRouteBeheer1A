﻿using RouteBeheerDL.Model;
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
        private NetworkRepository repo;

        public NetworkManager(NetworkRepository repo)
        {
            this.repo = repo;
        }

        public void AddLocation(Location location)
        {
            try
            {
                if (repo.HasLocationName(location.Name)) throw new NetworkException("Location already exists");
                repo.AddLocation(location);
            }
            catch(Exception ex)
            {
                throw new NetworkException("AddLocation", ex);
            }
        }
        public void UpdateLocation(Location location)
        {
            try
            {
                if (location==null) throw new NetworkException("UpdateLocation");
                if (location.Id==0) throw new NetworkException("UpdateLocation");
                if (repo.HasLocationName(location.Name)) throw new NetworkException("UpdateLocation"); //check dubbels
                if (!repo.HasLocationId(location.Id)) throw new NetworkException("UpdateLocation"); //id bestaat niet
                repo.UpdateLocation(location);
            }
            catch(Exception ex)
            {
                throw new NetworkException("UpdateLocation", ex);
            }
        }
    }
}
