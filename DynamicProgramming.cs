using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class DynamicProgramming
    {

        // DP probem has following characteristic 
        // 1) There will be choice/decision
        // 2) Optimal problem - Max, Min - Backtracking is all solution 
        // 3) Repeatitive subproblem - Parent problem is recursion, multiple calls to same recusion
        // DP = Recursion + Store old result 


        // Uses recursion - can have stackoverflow issue
        public static int KnapSack(int[] wt, int maxW, int[] value, int n)
        {
            int max = int.MinValue;
            if (n == 0 || maxW == 0)
            {
                // Console.Write("Profit is zero");
                return 0;
            }

            if (wt[n - 1] > maxW)
                return KnapSack(wt, maxW, value, n - 1);

            if (wt[n - 1] <= maxW)
            {
                max = Math.Max(KnapSack(wt, maxW, value, n - 1),
                 KnapSack(wt, maxW - wt[n - 1], value, n - 1) + value[n-1]);
            }

            return max;
        }

        #region KnapSack Memoization
        // Memoization we store results so no need to calucate them again 

        // Dimension on this is based on what are dynamic paramters
        // Here N will vary and maxW will vary for each recursion step
        private static int[,] memKnapSack;

        public static int KanpSackMemoization(int[] wt, int maxW, int[] value, int n)
        {
            // intialise with empty value
            memKnapSack = new int[n + 1, maxW + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= maxW; j++)
                {
                    memKnapSack[i, j] = -1;
                }
            }

            KnapSackMemSubProblem(wt, maxW, value, n);

            return memKnapSack[n, maxW];
        }

        private static int KnapSackMemSubProblem(int[] wt, int maxW, int[] value, int n)
        {
            
            // First thing to check if value already stored from previous recusion, return it.
            if (memKnapSack[n, maxW] != -1)
                return memKnapSack[n, maxW];

            if (wt[n - 1] > maxW)
            {
                return memKnapSack[n, maxW] = KnapSack(wt, maxW, value, n - 1);
                 
            }

            if (wt[n - 1] <= maxW)
            {
                 memKnapSack[n, maxW] = Math.Max(KnapSack(wt, maxW, value, n - 1),
                 KnapSack(wt, maxW - wt[n - 1], value, n - 1) + value[n - 1]);
            }

            return memKnapSack[n, maxW];
        }

        #endregion
    }
}
