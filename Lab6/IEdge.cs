using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    // IComparable will compare Weight only.
    public interface IEdge : IComparable<IEdge>
    {
        double Weight { get; }
        int EitherVertex { get; }
        int OtherVertex(int vertex);
        int[] Vertex { get; }
    }
}
