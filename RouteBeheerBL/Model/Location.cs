using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteBeheerBL.Model
{
    public class Location
    {
        public Location(string name)
        {
            Name = name;
        }

        public Location(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id},{Name}";
        }
    }
}
