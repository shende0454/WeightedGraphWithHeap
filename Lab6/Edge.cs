using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Edge : IEdge
    {
       
        public Edge() { }
        public Edge(int v, int eitherVertex, double weight)
        {
            Weight = weight;
            Vertex = new int[2];
            Vertex[0] = v;
            Vertex[1] = eitherVertex;
           
        }
        public Edge(int v, int eitherVertex)
        {
            Vertex = new int[2];
            Vertex[0] = v;
            Vertex[1] = eitherVertex;
        }
        public double Weight
        {
            set;
            get;
        }

        public int EitherVertex
        {
            set { Vertex[0] = value; }
            get { return Vertex[0]; }
        }

        public int[] Vertex
        {
            get;
            set;
        }
        
        
        public int CompareTo(IEdge other)
        {
            int retVal = -2;
            if (this.Weight < other.Weight)
            {
                retVal = -1;
            }
            else if (this.Weight > other.Weight)
            {
                retVal = 1;
            }
            else
            {
                retVal = 0;
            }
            return retVal;
        }

        public int OtherVertex(int vertex)
        {
            return (vertex == Vertex[0]) ? Vertex[1] : Vertex[0];
        }
    }
}
