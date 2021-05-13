using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphLib;
using QueueLib;

namespace UnitTestProject1
{//Test
    [TestClass]
    public class GraphLibTest
    {
        [TestMethod]
        public void T00_testEdge()
        {
            Edge edge = new Edge(0, 1, .5);
            Assert.AreEqual(.5, edge.Weight);
            Assert.AreEqual(1, edge.OtherVertex(0));
            Assert.AreEqual(0, edge.OtherVertex(1));
        }

        [TestMethod]
        public void T01_edgeCompare()
        {
            Edge edge = new Edge(0, 1, .5);
            Edge secondEdge = new Edge(0, 1, .4);
            Edge thirdEdge = new Edge(0, 1, .4);
            Assert.IsTrue(edge.CompareTo(secondEdge) > 0);
            Assert.IsTrue(thirdEdge.CompareTo(secondEdge) == 0);
            Assert.IsTrue(thirdEdge.CompareTo(edge) < 0);
        }

        [TestMethod]
        public void T02_heapTest()
        {
            Heap<double, string> priorityQueue =
                new Heap<double, string>(new Reverse<double>());
            priorityQueue.Enqueue(.23, "ab");
            priorityQueue.Enqueue(.53, "ac");
            priorityQueue.Enqueue(.2, "ad");
            priorityQueue.Enqueue(.531, "ae");
            priorityQueue.Enqueue(.432, "af");
            priorityQueue.Enqueue(.52, "ag");

            double key;
            string payload;
            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .2);
            Assert.AreEqual(payload, "ad");

            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .23);
            Assert.AreEqual(payload, "ab");

            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .432);
            Assert.AreEqual(payload, "af");

            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .52);
            Assert.AreEqual(payload, "ag");

            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .53);
            Assert.AreEqual(payload, "ac");

            priorityQueue.Dequeue(out key, out payload);
            Assert.AreEqual(key, .531);
            Assert.AreEqual(payload, "ae");
        }

        [TestMethod]
        public void T03_bigHeapTest()
        {
            Heap<double, string> priorityQueue = new Heap<double, string>(new Reverse<double>());

            int seed = 2332411;
            Random rand = new Random(seed);
            const int N_ELEMENTS_IN_TEST = 1024 * 64;

            List<double> doublesForQueue = new List<double>();
            for (int i = 0; i < N_ELEMENTS_IN_TEST; i++)
            {
                doublesForQueue.Add(rand.NextDouble());
            }

            foreach (double next in doublesForQueue)
            {
                priorityQueue.Enqueue(next, "aa");
            }

            double key;
            string payload;
            doublesForQueue.Sort();
            for (int i = 0; i < doublesForQueue.Count; i++)
            {
                priorityQueue.Dequeue(out key, out payload);
                Assert.AreEqual(doublesForQueue[i], key);
                Assert.AreEqual(payload, "aa");
            }
        }

        [TestMethod]
        public void T04_makeWeightedGraph()
        {
            IWeightedGraph graph = new WeightedGraph();
            graph.AddEdge(0, 1, 2.0);
            graph.AddEdge(0, 2, 4.0);
            graph.AddEdge(0, 3, 6.0);
            bool[] seen = new bool[4];
            foreach (IEdge nextEdge in graph.GetEdgesFrom(0))
            {
                seen[nextEdge.OtherVertex(0)] = true;
                double expectedWeight = (double)nextEdge.OtherVertex(0) * 2;
                if (nextEdge.OtherVertex(0) == 1)
                {
                    Assert.AreEqual(expectedWeight, nextEdge.Weight);
                }
            }
            Assert.IsTrue(seen[1]);
            Assert.IsTrue(seen[2]);
            Assert.IsTrue(seen[3]);
        }

        [TestMethod]
        public void T05_firstPrim()
        {
            IWeightedGraph graph = new WeightedGraph();
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(0, 3, 3);

            PrimMST prim = new PrimMST(graph);

            int countEdge = 0;
            foreach (Edge edge in prim.GetMST())
            {
                ++countEdge;
            }
            Assert.AreEqual(3, countEdge);
        }

        [TestMethod]
        public void T06_secondPrim614()
        {
            IWeightedGraph graph = new WeightedGraph();
            graph.AddEdge(4, 5, .35);
            graph.AddEdge(4, 7, .37);
            graph.AddEdge(5, 7, .28);
            graph.AddEdge(0, 7, .16);
            graph.AddEdge(1, 5, .32);
            graph.AddEdge(0, 4, .38);
            graph.AddEdge(2, 3, .17);
            graph.AddEdge(1, 7, .19);
            graph.AddEdge(0, 2, .26);
            graph.AddEdge(1, 2, .36);
            graph.AddEdge(1, 3, .29);
            graph.AddEdge(2, 7, .34);
            graph.AddEdge(6, 2, .4);
            graph.AddEdge(3, 6, .52);
            graph.AddEdge(6, 0, .58);
            graph.AddEdge(6, 4, .93);

            PrimMST prim = new PrimMST(graph);

            Assert.AreEqual(1.81, prim.WeightOfMst);
            List<Edge> mstList = new List<Edge>();
            foreach (Edge edge in prim.GetMST())
            {
                mstList.Add(edge);
            }
            Assert.AreEqual(7, mstList.Count);
            mstList.Sort();
            Assert.AreEqual(.16, mstList[0].Weight);
            Assert.AreEqual(.17, mstList[1].Weight);
            Assert.AreEqual(.4, mstList[6].Weight);
        }
    }
}
