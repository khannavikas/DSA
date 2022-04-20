using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class Graph
    {
        LinkedList<int>[] graph;

        Dictionary<int, int> childCount;

        int nodes;

        bool[] visited;

        public Graph(int n)
        {
            nodes = n;
            graph = new LinkedList<int>[n];

            visited = new bool[nodes];
            childCount = new Dictionary<int, int>();
         
            for (int i = 0; i < n; i++)
            {
                graph[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            graph[u].AddLast(v);
          // graph[v].AddLast(u);
        }

        public void BFSFromNode(int x)
        {
            bool[] visitied = new bool[nodes];

            Queue<int> q = new Queue<int>();

            q.Enqueue(x);
            visitied[x] = true;

            while (q.Count > 0)
            {
                LinkedList<int> adjList = graph[q.First()];
                Console.WriteLine(q.First());

                foreach (int item in adjList)
                {
                    if (!visitied[item])
                    {
                        q.Enqueue(item);
                        visitied[item] = true;
                    }
                }

                q.Dequeue();

            }

        }

        public void DFSNew(int x)
        {
            Console.WriteLine(x);

            var list = graph[x];

            visited[x] = true;

            foreach (int p in list)
            {
                if (!visited[p])
                    DFSNew(p);
            }

        }

        int count = 0;
        public int NumIsland()
        {

            for (int i = 0; i < nodes; i++)
            {
                if (!visited[i])
                {
                    count++;
                    DFSNew(i);
                }
            }
            return count;
        }

        public void DFS(int x)
        {

            bool[] visi = new bool[nodes];




            Stack<int> q = new Stack<int>();


            q.Push(x);

            while (q.Count() > 0)

            {
                var x1 = q.Pop();
                // q.Pop();

                if (!visi[x1])
                {
                    Console.WriteLine(x1);

                    visi[x1] = true;
                }
                foreach (int v in graph[x1])
                {
                    if (!visi[v])
                    {
                        q.Push(v);


                    }

                }

            }

        }

        public void BFSNew(int x)
        {
            bool[] visited = new bool[nodes];

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(x);

            while (queue.Count > 0)
            {
                int nodeVal = queue.Peek();

                if (!visited[nodeVal])
                {

                    visited[nodeVal] = true;

                    Console.Write(nodeVal);

                    foreach (int y in graph[nodeVal])
                    {
                        if (!visited[y])

                            queue.Enqueue(y);
                    }

                }

                queue.Dequeue();

            }

        }

        public int MotherVertex()
        {
            int count = 0;
            for (int i = 0; i < graph.Count(); i++)
            {
                //  int? node = x.FirstOrDefault();

                count = GetChildNodes(i, new HashSet<int>());

                if (count == graph.Length - 1)
                {
                    return i;
                }


            }

            return -1;
        }

        public bool HasPath(int u, int v)
        {
            if (u == v)
                return true;
            foreach (var item in graph[u])
            {
                if (item == v || HasPath(item, v))
                    return true;
            }


            return false;
        }

        public bool HasCycle()
        {
            for (int i = 0; i < nodes; i++)
            {
                foreach (var item in graph[i])
                {
                    if (HasPath(item, item))
                        return true;
                }
            }

            return false;
        }

        public void ListAllPath(int u, int v)
        {
            visited[u] = true;
            PrintPath(u, v, new List<int>());
        }

        public void PrintPath(int u, int v, List<int> nodes)
        {
            if (u == v)
            {
                Console.WriteLine();

                foreach (var noe in nodes)
                {
                    Console.Write(noe + "-->");
                }

                Console.Write(u);
                return;
            }

            visited[u] = true;
            nodes.Add(u);

            foreach (var item in graph[u])
            {                              
                    if (!visited[item])
                    {                       
                        PrintPath(item, v, nodes);               
                    }
                
            }

            //Back Tracking
            visited[u] = false;
            nodes.Remove(u);


        }

        public bool HasPath(int u, int v, List<int> nodes)
        {
            foreach (var item in graph[u])
            {
                if (item == v || item == u)
                {
                    nodes.Add(item);
                    return true;
                }

                return (HasPath(item, v, nodes));

            }

            return false;

        }

        public int GetChildNodes(int x, HashSet<int> childs)
        {
            var node = graph[x];

            foreach (int p in node)
            {
                childs.Add(p);
                GetChildNodes(p, childs);
            }

            return childs.Count;
        }

        public int WaysToReach(int u, int v)
        {
          

            int count = 0;

            if (u == v)
                return count;

            foreach (var item in graph[u])
            {
                if (item == v)
                {
                    count++;
                }

                count += WaysToReach(item, v);
            }

            return count;
        }

        public bool HasPathSum(int sum)
        {
            for (int i = 0; i < nodes; i++)
            {
                int currsum = 0;
                foreach (var item in graph[i])
                {
                    currsum += GetChildNodesSum(item, sum);
                    if (currsum >= sum)
                        return true;
                }
            }

            return false;
        }

        private int GetChildNodesSum(int v, int maxsum)
        {
            int sum = v;

            foreach (var item in graph[v])
            {
                sum += GetChildNodesSum(item, maxsum);
                if (sum >= maxsum)
                    break;
            }

            return sum;
        }


        public class Node
        {
            public int val;
            public List<int> parent = new List<int>();

        }

        public void BFSPath(int x, int y)
        {
            bool[] childVisited = new bool[nodes];
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(new Node() { val = x });

            while (q.Count > 0)
            {
                Node n = q.Dequeue();

                if (n.val == y)
                {
                    Console.WriteLine();

                    foreach (int i in n.parent)
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write(y);
                }
                else
                {

                    foreach (int p in graph[n.val])
                    {
                        if (!n.parent.Contains(p))
                        {
                            var newlst = new List<int>(n.parent);
                            newlst.Add(n.val);
                            q.Enqueue(new Node() { val = p, parent = newlst });
                        }
                    }

                }


            }


        }


        public bool HasCycleRec()
        {
            for (int i = 0; i < nodes; i++)
            {
                if (HasCycle(i, new List<int>()))
                    return true;
            }

           // int i = Math.Sqrt(8);
            for (int i = 2; i < Math.Sqrt(8); i++)
            {

            }
                return false;
        }

        private bool HasCycle(int v, List<int> parents)
        {
            // If path to this node already has this node
            // means it is a cycle
            if (parents.Contains(v))
                return true;

            parents.Add(v); // 2, 012, 2,3,0
            foreach (var item in graph[v])
            {
                if (HasCycle(item, parents))
                    return true;
            }

            parents.Remove(v);
            return false;
        }


        // A recursive function that uses visited[]
        // and parent to detect cycle in subgraph
        // reachable from vertex v.


        bool isCyclicUtil(int v, bool[] visited,
                             int parent)
        {
            // Mark the current node as visited
            visited[v] = true;

            // Recur for all the vertices
            // adjacent to this vertex
            foreach (int i in graph[v])
            {
                // If an adjacent is not visited,
                // then recur for that adjacent
                if (!visited[i])
                {
                    if (isCyclicUtil(i, visited, v))
                        return true;
                }

                // If an adjacent is visited and
                // not parent of current vertex,
                // then there is a cycle.
                // In case of undirected graph x-->y and Y-->X but this is not cycle.
                else if (i != parent)
                    return true;
            }
            return false;
        }

        // Returns true if the graph contains
        // a cycle, else false.
        public bool isCyclic()
        {
            // Mark all the vertices as not visited
            // and not part of recursion stack
            bool[] visited = new bool[nodes];
            for (int i = 0; i < nodes; i++)
                visited[i] = false;

            // Call the recursive helper function
            // to detect cycle in different DFS trees
            for (int u = 0; u < nodes; u++)

                // Don't recur for u if already visited
                if (!visited[u])
                    if (isCyclicUtil(u, visited, -1))
                        return true;

            return false;
        }




        public bool IsCycleDirectedGraph()
        {

            for (int i = 0; i < nodes; i++)
            {
                visited[i] = true;
                if (CheckCycle(i))
                    return true;
                visited[i] = false;
            }

            return false;

        }



        private bool CheckCycle(int src)
        {

            foreach (int node in graph[src])
            {
                if (visited[node])
                    return true;
                visited[node] = true;
                if (CheckCycle(node))
                    return true;
                visited[node] = false;

            }


            return false;

        }


        public void PrintDijkastra()
        {
            int[,] minDisGraph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            int[] dis = new int[minDisGraph.GetLength(0)];

            for (int i = 0; i < dis.Length; i++)
            {
                dis[i] = int.MaxValue;

            }

            dis[0] = 0;
            List<int> nodesPath = new List<int>();
            ShortestPath(0, minDisGraph, dis, nodesPath);

            foreach (var item in dis)
            {
                Console.WriteLine(item);
            }

        }

        private void ShortestPath(int x, int[,] minGraph, int[] dis, List<int> path)
        {
            bool[] visit = new bool[dis.Length];
            visit[x] = true;

            for (int i = 0; i < dis.Length; i++)
            {
                if (!visit[i] && minGraph[x, i] > 0)
                {
                    visit[i] = true;

                    dis[i] = Math.Min(dis[i], minGraph[x, i] + dis[x]);

                }

            }

            path.Add(x);

            int index = GetMin(dis, path);

            if (index > -1)
            {
                ShortestPath(index, minGraph, dis, path);
            }

        }

        private int GetMin(int[] dis, List<int> path)
        {
            int min = int.MaxValue;
            int index = -1;

            for (int i = 0; i < dis.Length; i++)
            {
                if (dis[i] < min && !path.Contains(i))
                {
                    min = dis[i];
                    index = i;
                }
            }

            return index;
        }


        int min = int.MaxValue;
        List<int> shortPath = new List<int>();

        public void Path(int u, int v, int k, List<int> path, int costSoFar)
        {

            if (u == v && k == 0)
            {
                min = Math.Min(min, costSoFar);
                shortPath = path;
                return;
            }

            if (k < 0)
                return;

            visited[u] = true;

            foreach (int x in graph[u])
            {

                //Path(x, v, k - 1, path.Add(x), costSoFar + graph[u]);

                 path.Remove(x);
            }

            visited[u] = false;

        }


        public static int ShortestPathBinaryMatrix(int[][] grid)
        {


            int rows = grid.Length;
            int cols = grid[0].Length;

            if (rows == 0)
                return -1;

            if (cols == 0)
                return -1;


            if (grid[rows - 1][cols - 1] != 0 || grid[0][0] != 0)
                return -1;

            List<int[]> directions = new List<int[]>
                                    {
                                            new int[]{1,0},
                                            new int[]{0,1},
                                            new int[]{-1, 0},
                                            new int[]{0, -1},
                                            new int[]{1,1},
                                            new int[]{1,-1},
                                            new int[]{-1,1},
                                            new int[]{-1,-1}
                                     };

            return GetLength(grid, directions, rows, cols);

        }


        private static int GetLength(int[][] grid, List<int[]> directions, int lastrow, int lastcol)
        {
            Queue<int[]> q = new Queue<int[]>();

            q.Enqueue(new int[] { 0, 0 });

            grid[0][0] = 1;

            while (q.Count > 0)
            {
                int[] item = q.Dequeue();

                int r = item[0];
                int c = item[1];

                int dis = grid[r][c];

                if (r == lastrow && c == lastcol)
                    return dis;

                foreach (var dir in directions)
                {

                    int row = r + dir[0];
                    int col = c + dir[1];

                    if ( row < 0 || col < 0 ||  row >= grid.Length || col >= grid[0].Length || grid[row][col] != 0 )
                        continue;

                    q.Enqueue(new int[] { row, col });

                    grid[row][col] = dis + 1;

                }


            }

            return -1;
        }

        public static int[] ShortestToChar(String S, char C)
        {
            int N = S.Length;
            int[] ans = new int[N];
            int prev = int.MinValue / 2;

            for (int i = 0; i < N; ++i)
            {
                if (S[i] == C) prev = i;
                ans[i] = i - prev;
            }

            prev = int.MaxValue / 2;
            for (int i = N - 1; i >= 0; --i)
            {
                if (S[i] == C) prev = i;
                ans[i] = Math.Min(ans[i], prev - i);
            }

            return ans;
        }


    }

}
