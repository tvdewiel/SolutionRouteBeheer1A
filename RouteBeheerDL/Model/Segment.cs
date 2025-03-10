using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteBeheerDL.Model
{
    public class Segment
    {
        public Segment(Location startLocation, Location endLocation, double distance, bool fromTo)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
            Distance = distance;
            FromTo = fromTo;
        }

        public Segment(int id, Location startLocation, Location endLocation, double distance, bool fromTo)
        {
            Id = id;
            StartLocation = startLocation;
            EndLocation = endLocation;
            Distance = distance;
            FromTo = fromTo;
        }

        public int Id { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public double Distance { get; set; }
        public bool FromTo { get; set; }
    }
}
