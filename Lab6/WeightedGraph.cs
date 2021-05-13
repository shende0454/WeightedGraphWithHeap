using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class WeightedGraph : IWeightedGraph, IGraph
    {
        public int vertex;
        public int edge;
        public List<List<Edge>> _adjacencyList;
        public int NVertices { get; set; }

        public int NEdges { get; set; }
        public WeightedGraph()
        {
            NVertices = 0;
            NEdges = 0;
            _adjacencyList = new List<List<Edge>>();
           
        }

        public void MakeVertex(int id)
        {

            while (_adjacencyList.Count <= id)
            {
                _adjacencyList.Add(new List<Edge>());
            }

            NVertices++;
        }
        public void AddEdge(int firstVertex, int secondVertex, double weight)
        {
            Edge e = new Edge(firstVertex, secondVertex, weight);

            int vtx = e.EitherVertex;
            int wght = e.OtherVertex(vertex);

            MakeVertex(firstVertex);
            MakeVertex(secondVertex);
            _adjacencyList[vtx].Add(e);
            _adjacencyList[wght].Add(e);
            
            NEdges++;
        }

        public void AddEdge(int firstVertex, int secondVertex)
        {
            Edge e = new Edge(firstVertex, secondVertex);

            int vtx = e.EitherVertex;
            int wght = e.OtherVertex(vertex);

            MakeVertex(firstVertex);
            MakeVertex(secondVertex);
            _adjacencyList[vtx].Add(e);
            _adjacencyList[wght].Add(e);

            NEdges++;
        }
        
        public IEnumerable<int> GetAdjacentVertices(int vertexId)
        {
            return (IEnumerable<int>)_adjacencyList[vertexId];
        }

        public IEnumerable<IEdge> GetEdgesFrom(int vertex)
        {
            return _adjacencyList[vertex];
        }
    }
}
