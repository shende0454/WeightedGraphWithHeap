using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueLib;

namespace GraphLib
{
    public class PrimMST
    {
        private bool[] marked; // MST vertices
        private Queue<Edge> mst; // MST edges
        private Heap<Edge,Edge> pq; // crossing (and ineligible) edges
        Comparer<Edge> comparer;
        public PrimMST(IWeightedGraph g)
        {
           
            
        }
       
    }
}
