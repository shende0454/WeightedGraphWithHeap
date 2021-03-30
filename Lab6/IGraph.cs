using System;
using System.Collections.Generic;

namespace GraphLib
{
    public interface IGraph
    {
        int NVertices { get; } // V()

        int NEdges { get; }  // E()

        // addEdge
        void AddEdge(int firstVertex, int secondVertex);

        // adj(v)
        IEnumerable<int> GetAdjacentVertices(int vertexId);

    }
}