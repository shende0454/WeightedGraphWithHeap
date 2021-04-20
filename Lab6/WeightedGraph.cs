using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class WeightedGraph : IWeightedGraph
    {
        public int v;
        public int e;
        public List<List<Edge>> _adjacencyList;
        public int NVertices { get; set; }

        public int NEdges { get; set; }
        public WeightedGraph()
        {
            NVertices = 0;
            NEdges = 0;
            _adjacencyList = new List<List<Edge>>();
            foreach (List<Edge> i in _adjacencyList)
            {
                i.Add(new Edge());
            }

        }
        public void AddEdge(int firstVertex, int secondVertex, double weight)
        {
            Edge e = new Edge(firstVertex, secondVertex, weight);
            int v = e.EitherVertex, w = e.OtherVertex(v);
            _adjacencyList[v].Add(e);
            _adjacencyList[w].Add(e);
            //if (_adjacencyList[firstId].Contains(secondId) == false)
            //{
            //    _adjacencyList[firstId].Add(secondId);
            //}
            //if (_adjacencyList[secondId].Contains(firstId) == false)
            //{
            //    _adjacencyList[secondId].Add(firstId);
            //}
            NEdges++;
        }

        public void AddEdge(int firstVertex, int secondVertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAdjacentVertices(int vertexId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEdge> GetEdgesFrom(int vertex)
        {
            return _adjacencyList[vertex];
        }
    }
}
