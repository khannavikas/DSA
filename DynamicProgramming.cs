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
                 KnapSack(wt, maxW - wt[n - 1], value, n - 1) + value[n - 1]);
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

            if (n == 0 || maxW == 0)
                return 0;

            // First thing to check if value already stored from previous recusion, return it.
            if (memKnapSack[n, maxW] != -1)
                return memKnapSack[n, maxW];

            //Very Important to take n-1 and not n
            if (wt[n - 1] > maxW)
            {
                return memKnapSack[n, maxW] = KnapSackMemSubProblem(wt, maxW, value, n - 1);

            }

            //if (wt[n - 1] <= maxW)
            //{
            return memKnapSack[n, maxW] = Math.Max(KnapSackMemSubProblem(wt, maxW, value, n - 1),
               KnapSackMemSubProblem(wt, maxW - wt[n - 1], value, n - 1) + value[n - 1]);
            // }

            //return memKnapSack[n, maxW];
        }

        #endregion

        #region KnapSack DP

        public static int KnapsackDP(int[] wt, int maxW, int[] value, int n)
        {
            int[,] dp = new int[n + 1, maxW + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= maxW; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= maxW; j++)
                {
                    if (wt[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - wt[i - 1]] + value[i - 1]);
                    }
                }
            }

            return dp[n, maxW];

        }



        #endregion


        public static bool HasSubsetWithSumKRec(int[] a, int k, int n)
        {
            if (n == 0)
                return false;

            if (k == 0)
                return true;

            if (a[n - 1] > k)
                return HasSubsetWithSumKRec(a, k, n - 1);

            return HasSubsetWithSumKRec(a, k - a[n - 1], n - 1) || HasSubsetWithSumKRec(a, k, n - 1);
        }


        public static int NumberOfWaysToSumKRec(int[] a, int n, int k)
        {

            // 2nd condition handles -ve numbers
            if (k == 0)
                return 1;

            if (n == 0)
                return 0;

            if (a[n - 1] > k)
                return NumberOfWaysToSumKRec(a, n - 1, k);


            return NumberOfWaysToSumKRec(a, n - 1, k) +
             NumberOfWaysToSumKRec(a, n - 1, k - a[n - 1]);

        }


        #region Coin change Recursive

        public static int NumbeOfWaysToCoinSum(int[] coins, int sum, int n)
        {


            if (n == 0)
                return 0;

            if (sum == 0)
                return 1;


            if (coins[n - 1] > sum)
                return NumbeOfWaysToCoinSum(coins, sum, n - 1);

            return NumbeOfWaysToCoinSum(coins, sum - coins[n - 1], n) + NumbeOfWaysToCoinSum(coins, sum, n - 1);
        }

        #endregion

        #region Coin change min coins  Recursive

        public static int MinCoinsToCoinSum(int[] coins, int sum, int n)
        {
            if (sum == 0)
                return 0;


            if (n == 0)
                return int.MaxValue;


            if (coins[n - 1] > sum)
                return MinCoinsToCoinSum(coins, sum, n - 1);

            return Math.Min(1 + MinCoinsToCoinSum(coins, sum - coins[n - 1], n), MinCoinsToCoinSum(coins, sum, n - 1));
        }

        #endregion


        #region Coin change min coins Dp

        public static int MinCoinsToCoinSumDP(int[] coins, int sum)
        {
            int[] dpmincoins = new int[sum + 1];

            for (int i = 0; i < dpmincoins.Length; i++)
            {
                dpmincoins[i] = int.MaxValue;
            }


            //Zero sum can be created with Zero coins
            dpmincoins[0] = 0;

            // For each sum we need to create
            for (int i = 0; i < dpmincoins.Length; i++)
            {
                //Try each coin 
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                        dpmincoins[i] = Math.Min(dpmincoins[i], 1 + dpmincoins[i - coins[j]]);
                }
            }

            return dpmincoins[sum] == int.MaxValue ? -1 : dpmincoins[sum];
        }

        #endregion


        #region Longest common substring recursive






        #endregion


        // DP of this is Hard this is recursive
        public static bool HasSubsetDivK(int[] a, int k, int n, int sumSofar)
        {
            if (n == 0 || k == 0)
                return false;

            if (k == 1)
                return true;

            if (a[n - 1] % k == 0 || (sumSofar + a[n - 1]) % k == 0)
                return true;
            else
                return HasSubsetDivK(a, k, n - 1, sumSofar) || HasSubsetDivK(a, k, n - 1, sumSofar + a[n - 1]);

        }

        public static int NumberOfWaysToNthStair(int n)
        {
            int[] res = new int[n + 1];
            res[0] = 1;
            res[1] = 1;
            res[2] = 2;

            for (int i = 3; i <= n; i++)
                res[i] = res[i - 1] + res[i - 2]
                         + res[i - 3];

            return res[n];

        }

        // Recursive function to find total ways to reach the n'th stair from the bottom
        // when a person is allowed to take at most `m` steps at a time
        public static int totalWays(int n, int m)
        {
            // create an array of size `n+1` for storing solutions to the subproblems
            int[] lookup = new int[n + 1];

            // base case: 1 way (with no steps)
            lookup[0] = 1;

            // 1 way to reach the 1st stair
            lookup[1] = 1;

            // 2 ways to reach the 2nd stair
            lookup[2] = 2;

            // fill the lookup table in a bottom-up manner
            for (int i = 3; i <= n; i++)
            {
                lookup[i] = 0;
                for (int j = 1; j <= m && (i - j) >= 0; j++)
                {
                    lookup[i] += lookup[i - j];
                }
            }

            return lookup[n];
        }

        public static int RodCuttingRecur(int[] lenArr, int[] priceArray, int rodLen, int n)
        {

            if (rodLen == 0 || n == 0)
                return 0;

            if (lenArr[n - 1] > rodLen)
                return RodCuttingRecur(lenArr, priceArray, rodLen, n - 1);

            return Math.Max(RodCuttingRecur(lenArr, priceArray, rodLen, n - 1), priceArray[n - 1] + RodCuttingRecur(lenArr, priceArray, rodLen - lenArr[n - 1], n));

        }

        public static int RodCuttingDP(int[] lenArr, int[] priceArray, int rodLen, int n)
        {

            int[,] profitCut = new int[lenArr.Length + 1, rodLen + 1];

            for (int i = 0; i <= lenArr.Length; i++)
            {
                for (int j = 0; j <= rodLen; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        profitCut[i, j] = 0;

                    }
                    else
                    {
                        if (lenArr[i - 1] <= j)
                        {
                            profitCut[i, j] = Math.Max(profitCut[i - 1, j], priceArray[i - 1] + profitCut[i, j - lenArr[i - 1]]);
                        }
                        else
                        {
                            profitCut[i, j] = profitCut[i - 1, j];
                        }
                    }
                }
            }

            return profitCut[lenArr.Length, rodLen];


        }

        public static int MinStepToEnd(int[] a)
        {
            if (a.Length == 0 || a[0] == 0)
                return -1;

            int[] minStep = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                minStep[i] = int.MaxValue;
            }

            // Min step to reach 1st step = 0
            minStep[0] = 0;

            // for each element
            for (int x = 0; x < a.Length - 1; x++)
            {
                // Only If steps can be taken from here
                if (a[x] > 0)
                {
                    // Start from 1 to number of steps that can be taken 
                    for (int y = 1; y <= a[x] && x + y < a.Length; y++)
                    {
                        minStep[x + y] = Math.Min(minStep[x + y], minStep[x] + 1);
                    }

                }

            }

            if (minStep[a.Length - 1] == int.MaxValue)
                return -1;
            else
                return minStep[a.Length - 1];
        }


        public static int MaxSteal(int[] a, int n, int maxSofar)

        {
            if (n <= 0)
                return maxSofar;


            return Math.Max(MaxSteal(a, n - 2, maxSofar + a[n - 1]), MaxSteal(a, n - 1, maxSofar));

        }


        // Function to calculate the
        // maximum stolen value
        public static int MaxLoot(int[] hval, int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return hval[0];
            if (n == 2)
                return Math.Max(hval[0], hval[1]);

            // dp[i] represent the maximum value stolen
            // so far after reaching house i.            
            int[] dp = new int[n];

            // Initialize the dp[0] and dp[1]
            dp[0] = hval[0];
            dp[1] = Math.Max(hval[0], hval[1]);

            // Fill remaining positions
            for (int i = 2; i < n; i++)
                dp[i] = Math.Max(hval[i] + dp[i - 2], dp[i - 1]);

            return dp[n - 1];
        }

        // Function to calculate the
        // maximum stolen value using only 2 variables
       public static int maxLoot(int[] hval, int n)
        {
            if (n == 0)
                return 0;

            int value1 = hval[0];
            if (n == 1)
                return value1;

            int value2 = Math.Max(hval[0], hval[1]);
            if (n == 2)
                return value2;

            // contains maximum stolen value at the end
            int max_val = 0;

            // Fill remaining positions
            for (int i = 2; i < n; i++)
            {
                max_val = Math.Max(hval[i] + value1, value2);
                value1 = value2;
                value2 = max_val;
            }

            return max_val;
        }

    }
}
