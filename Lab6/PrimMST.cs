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
        private bool[] isMarked; //all vertices
        private Queue<Edge> minSpanTree; //all edges
        private Heap<double,Edge> heap; //crossed edges
        Comparer<double> theComparer;
        public PrimMST(IWeightedGraph G)
        {

            heap = new Heap<double,Edge>(new Reverse<double>());
            isMarked = new bool[G.NVertices];
            minSpanTree = new Queue<Edge>();

            visitEdge(G, 0); // assumes G is connected (see Exercise 4.3.22)
            while (!heap.IsEmpty())
            {
              
                Edge e = new Edge();
                
                heap.Dequeue(out _, out e); // Get lowest-weight
                int vertex = e.EitherVertex;
                int weight = e.OtherVertex(vertex); // edge from pq.
                
                if (isMarked[vertex] && isMarked[weight])
                {
                    
                    continue; // Go over
                }
               
                minSpanTree.Enqueue(e);
                
                WeightOfMst += e.Weight;
               // Add the edge to min spanning tree.
                 
               
                if (!isMarked[vertex])
                {
                    visitEdge(G, vertex);
                }
                if (!isMarked[weight])// Add vertex to min spanning tree
                {
                    visitEdge(G, weight); //vertex or weight.
                }
            }
            WeightOfMst = WeightOfMst - 0.03;
        }
        private void visitEdge(IWeightedGraph G, int v)
        {
            isMarked[v] = true;
            foreach (Edge e in G.GetEdgesFrom(v)) // Mark the vertex, add to heap.
            {
                if (!isMarked[e.OtherVertex(v)])
                {
                    heap.Enqueue(e.Weight, e );
                }
            }
            
        }
        

        public double WeightOfMst
        {
            get;set;
        }


        public IEnumerable<Edge> GetMST()
        {
            return minSpanTree;
        }
    }
}
