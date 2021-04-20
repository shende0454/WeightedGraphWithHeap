using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Edge : IEdge
    {
        public int vt;
        public Edge() { }
        public Edge(int v, int eitherVertex, double weight)
        {
            Weight = weight;
            EitherVertex = eitherVertex;
            var listOfStrings = new List<int>();
            vt = v;
            int[] Vertex = listOfStrings.ToArray() ;
           
        }
        public double Weight
        {
            get;
        }

        public int EitherVertex
        {
            get;
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
            int otherVertex = -1;
            if (vertex == EitherVertex)
            {
                otherVertex = vt;
            }

            else if (vertex == vt)
            {
                otherVertex = EitherVertex;
            }
            else throw new Exception("Inconsistent edge");
            return otherVertex;
        }
    }
}
