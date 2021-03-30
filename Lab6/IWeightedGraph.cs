using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public interface IWeightedGraph : IGraph
    {
        void AddEdge(int firstVertex, int secondVertex, double weight);

        IEnumerable<IEdge> GetEdgesFrom(int vertex);
    }
}
