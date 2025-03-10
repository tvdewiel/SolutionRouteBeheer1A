using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteBeheerDL.Model
{
    public class XRoute
    {
        private readonly double minDistance;
        private List<Segment> segments = new List<Segment>();

        public XRoute(double minDistance, List<Segment> segments)
        {
            //TODO check if valid segments
            //TODO at least 2 stops
            this.segments = segments;
            this.minDistance = minDistance;
        }
        public int Id { get; set; }
    }
}
