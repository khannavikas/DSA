using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Practice
{
    public static class GraphHelper
    {

        public class Graph
        {
            List<int>[] nodes = null;

            bool isDirectedGraph = false;

            int numberOfNodes = 0;

            public void AddEdge(int u, int v)
            {
                nodes[u].Add(v);

                if (!isDirectedGraph)
                {
                    nodes[v].Add(u);
                }
            }

            public Graph(int numNodes, bool isDirected = false)
            {
                numberOfNodes = numNodes;
                nodes = new List<int>[numNodes];
                isDirectedGraph = isDirected;

                for (int i = 0; i < numberOfNodes; i++)
                {
                    nodes[i] = new List<int>();
                }

            }

            public void BFSFromNode(int x)
            {
                bool[] visited = new bool[numberOfNodes];

                visited[x] = true;
                Queue<int> queueNodes = new Queue<int>();
                queueNodes.Enqueue(x);

                while (queueNodes.Count > 0)
                {
                    int node = queueNodes.Dequeue();

                    Console.WriteLine(node);

                    foreach (var item in nodes[node])
                    {
                        if (!visited[item])
                        {
                            queueNodes.Enqueue(item);
                        }
                    }
                }

            }

            public void DFSFromNode(int x, bool[] visited)
            {
                if (!visited[x])
                {
                    visited[x] = true;
                    var adjList = nodes[x];

                    foreach (var item in adjList)
                    {
                        DFSFromNode(item, visited);
                    }
                }

            }

            // BFS should be followed for Path
            //public bool HasPathBFS(int s, int e)
            //{
            //    bool[]
            //}

            public bool HasPathDFSGraph(int a, int b)
            {
                var adjList = nodes[a];
                bool[] visited = new bool[numberOfNodes];

                return HasPathDFSGraph(a, b, visited);

            }

            public bool HasPathDFSGraph(int a, int b, bool[] visited)
            {
                if (!visited[a])
                {
                    visited[a] = true;
                    foreach (var item in nodes[a])
                    {
                        if (item == b)
                            return true;

                        if (!visited[item])
                        {
                            if (HasPathDFSGraph(item, b, visited))
                                return true;
                        }
                    }
                }

                return false;
            }

            public List<int> PathDirectedGraph(int x, int y)
            {
                List<int> path = new List<int>();

                bool[] visited = new bool[numberOfNodes];

                visited[x] = true;

                foreach (var item in nodes[x])
                {
                    if (!visited[item])
                    {
                        path.Add(item);
                        if (HasPathDFSGraph(item, y))
                            return path;

                        path.Remove(item);

                    }
                }

                return path;
            }


            public bool HasCycleDirectedGraph()
            {
                bool[] visited = new bool[numberOfNodes];

                for (int i = 0; i < numberOfNodes; i++)
                {
                    visited[i] = true;
                    if (IsCyclic(i, visited))
                        return true;
                    visited[i] = false;
                }

                return false;
            }

            public bool IsCyclic(int i, bool[] visited)
            {
                //  bool[] visitedNodes = visited;
                List<int> lst = nodes[i];
                // visited[i] = true;
                foreach (var item in lst)
                {
                    if (visited[i])
                        return true;

                    visited[item] = true;
                    if (IsCyclic(item, visited))
                        return true;

                    visited[item] = false;

                }

                return false;
            }

            public bool HasCycleUndirectedGraph()
            {
                bool[] visited = new bool[numberOfNodes];
                for (int i = 0; i < numberOfNodes; i++)
                {
                    if (!visited[i])
                    {
                        if (HasCycleUndirectedGraph(i, visited, -1))
                            return true;
                    }
                }

                return false;
            }

            public bool HasCycleUndirectedGraph(int x, bool[] visited, int parent)
            {
                visited[x] = true;

                foreach (var childNode in nodes[x])
                {
                    if (!visited[childNode])
                    {
                        if (HasCycleUndirectedGraph(childNode, visited, x))
                            return true;
                    }
                    else
                    {
                        // Already visited node but not parent 
                        // Child node is not parent of currentNode x
                        // because x->c and c->x but not a cycle
                        if (childNode != parent)
                            return true;
                    }

                }

                return false;

            }

            public int NumberOfIsland()
            {
                int num = 0;
                bool[] visited = new bool[numberOfNodes];

                for (int i = 0; i < numberOfNodes; i++)
                {

                    if (!visited[i])
                    {
                        num++;
                        DFSFromNode(i, visited);
                    }

                }

                return num;
            }
        }


    }
}
