using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Practice
{
    public class GarphAgain
    {
        private int nodes;
        private List<int>[] edges;
        bool[] visited;
        bool isdirected;

        public GarphAgain(int nodes, bool directed = true)
        {
            this.nodes = nodes;
            visited = new bool[nodes];
            isdirected = directed;

            edges = new List<int>[nodes];

            for (int i = 0; i < edges.Count(); i++)
            {
                edges[i] = new List<int>();
            }
        }

        public void AddEdge(int a, int b)
        {
            edges[a].Add(b);

            if (!isdirected)
            {
                edges[b].Add(a);
            }
        }

        public void DFS(int a)
        {
            if (!visited[a])
            {
                visited[a] = true;
                Console.WriteLine(a);

                foreach (var item in edges[a])
                {
                    DFS(item);
                }
            }

        }

        public int NumberOfIsland()
        {
            int num = 0;

            for (int i = 0; i < nodes; i++)
            {
                if (!visited[i])
                {
                    num++;
                    DFS(i);
                    //  visited[i] = true;
                }

            }

            return num;
        }


        public bool HasPath(int a, int b, bool[] visited)
        {
            if (a == b)
                return true;

            if (!visited[a])
            {
                visited[a] = true;
                foreach (var item in edges[a])
                {
                    if (!visited[item])
                    {
                        if (item == b)
                            return true;

                        // Important step not to return false to complete the loop
                        if (HasPath(item, b, visited))
                            return true;
                    }

                }
            }

            return false;
        }


        public List<List<int>> Paths(int src, int des)
        {
            List<List<int>> paths = new List<List<int>>();
            HashSet<int> path = new HashSet<int>();

            bool[] visited = new bool[nodes];
            visited[src] = true;
            path.Add(src);

            foreach (var item in edges[src])
            {
                if (!visited[item])
                {
                    path.Add(item);
                    //  visited[item] = true;

                    if (des == item || HasPath(item, des, new bool[nodes]))
                    {
                        path.Add(des);
                        paths.Add(new List<int>(path));
                        path.Remove(des);
                    }

                    path.Remove(item);
                    //   visited[item] = false;
                }
            }

            return paths;
        }

        public List<List<int>> allPaths = new List<List<int>>();
        public void AllPaths(int src, int des, List<int> path, bool[] visited)
        {
            if (src == des)
            {
                allPaths.Add(new List<int>(path));
                return;
            }

            visited[src] = true;

            foreach (var item in edges[src])
            {
                if (!visited[item])
                {
                    visited[item] = true;
                    path.Add(item);
                    AllPaths(item, des, path, visited);
                    path.Remove(item);
                    visited[item] = false;
                }
            }

            //   visited[src] = false;

            // return allPaths;
        }


        public bool HasCycleDirectedGraph()
        {
            for (int i = 0; i < nodes; i++)
            {
                if (CheckHasCycleDirected(i))
                    return true;
            }

            return false;
        }

        public bool CheckHasCycleDirected(int i)
        {
            if (visited[i])
                return true;

            visited[i] = true;

            foreach (var item in edges[i])
            {
                if (CheckHasCycleDirected(item))
                    return true;
            }

            visited[i] = false;

            return false;
        }


        public bool HasCycleUnDirected()
        {
            for (int i = 0; i < nodes; i++)
            {
                if (CheckHasCycleUnDirected(i, -1))
                    return true;
            }

            return false;
        }

        private bool CheckHasCycleUnDirected(int i, int parent)
        {
            //visited[i] = true;

            foreach (var item in edges[i])
            {               
                if (!visited[item])
                {
                    visited[item] = true;
                    if (CheckHasCycleUnDirected(item, i))
                       return true ;
                    visited[item] = false;
                }
                else
                {
                    // child is already visited if it is parent of current node that is i
                    if (item != parent)
                        return true;
                }
               
            }



            return false;
        }
    }
}
