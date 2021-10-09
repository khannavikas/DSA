using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCIFinal.Practice
{
    public class DPHelper
    {


        public static int max = 0;

        public static int LCSubRecursive(string s1, string s2, int n1, int n2)
        {

            LCSubString(s1, s2, n1, n2, 0);

            return max;

        }

        public static int LCSubString(string s1, string s2, int n1, int n2, int maxSofar)
        {
            if (n1 == 0 || n2 == 0)
                return maxSofar;

            if (s1[n1 - 1] == s2[n2 - 1])

            {               
               return  LCSubString(s1, s2, n1 - 1, n2 - 1, maxSofar + 1);
            }
            else
            {
                int max =  Math.Max(maxSofar, LCSubString(s1, s2, n1 - 1, n2, 0));
               return Math.Max(max, LCSubString(s1, s2, n1, n2 - 1, 0));

            }


        }


        public static int KnapSackRecursive(int[] wt, int[] value, int maxAllowedWeight, int n)
        {
            if (n <= 0 || maxAllowedWeight <= 0)
                return 0;

            if (wt[n - 1] > maxAllowedWeight)
                return KnapSackRecursive(wt, value, maxAllowedWeight, n - 1);

            return Math.Max(KnapSackRecursive(wt, value, maxAllowedWeight, n - 1),
                            value[n - 1] + KnapSackRecursive(wt, value, maxAllowedWeight - wt[n - 1], n - 1));

        }

        private static int[,] memo;
        public static int KnapSackMemoization(int[] wt, int[] value, int maxAllowedWeight, int n)
        {
            memo = new int[n + 1, maxAllowedWeight + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= maxAllowedWeight; j++)
                {
                    memo[i, j] = -1;
                }
            }

            return KnapSackMem(wt, value, maxAllowedWeight, n);


        }

        private static int KnapSackMem(int[] wt, int[] value, int maxAllowedWeight, int n)
        {

            if (n == 0 || maxAllowedWeight == 0)
                return 0;

            if (memo[n, maxAllowedWeight] != -1)
            {
                return memo[n, maxAllowedWeight];
            }

            if (wt[n - 1] > maxAllowedWeight)
                return memo[n, maxAllowedWeight] = KnapSackMemoization(wt, value, maxAllowedWeight, n - 1);

            return memo[n, maxAllowedWeight] = Math.Max(KnapSackMemoization(wt, value, maxAllowedWeight, n - 1), value[n - 1]
                + KnapSackMemoization(wt, value, maxAllowedWeight - wt[n - 1], n - 1));

            //return memo[n, maxAllowedWeight];
        }

        public static int KnapSackDP(int[] wt, int[] value, int maxAllowedWeight, int n)
        {
            int[,] dp = new int[n + 1, maxAllowedWeight + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= maxAllowedWeight; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (wt[i - 1] > j)
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j], value[i - 1] + dp[i - 1, j - wt[i - 1]]);
                        }
                    }
                }
            }

            return dp[n, maxAllowedWeight];

        }

        public static int SubSetSumDP(int[] a, int targetSum, int n)
        {
            int[,] dpTargetSum = new int[n + 1, targetSum + 1];

            for (int i = 0; i <= n; i++)
            {
                dpTargetSum[i, 0] = 1;
            }

            for (int j = 0; j <= targetSum; j++)
            {
                dpTargetSum[0, j] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= targetSum; j++)
                {

                    if (a[i - 1] > j)
                    {
                        dpTargetSum[i, j] = dpTargetSum[i - 1, j];
                    }
                    else
                    {
                        dpTargetSum[i, j] = dpTargetSum[i - 1, j] + dpTargetSum[i - 1, j - a[i - 1]];
                    }

                }
            }

            return dpTargetSum[n, targetSum];
        }

        private static string LCS = string.Empty;

        public static int LCSDP(string s1, string s2, int l1, int l2)
        {

            if (l1 == 0 || l2 == 0)
                return 0;

            int[,] dp = new int[l1 + 1, l2 + 1];

            for (int i = 0; i <= l1; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= l2; i++)
            {
                dp[0, i] = 0;
            }

            for (int i = 1; i <= l1; i++)
            {

                for (int j = 1; j <= l2; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        LCS += s1[i - 1];
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);

                    }


                }


            }
            return dp[l1, l2];
        }

        private static string longestString = string.Empty;

        public static string LongestPalindromicSubstring(string s)
        {
            LongestPalSubstring(s, new string(s.Reverse().ToArray()), s.Length, s.Length, string.Empty);

            return longestString;
        }

        private static string LongestPalSubstring(string s1, string s2, int n1, int n2, string longsSofar)
        {
            if (longestString.Length < longsSofar.Length)
            {
                longestString = longsSofar;
            }

            if (n1 == 0 || n2 == 0)
                return longsSofar;

            if (s1[n1 - 1] == s2[n2 - 1])
            {
                longsSofar += s1[n1 - 1];
                longsSofar = LongestPalSubstring(s1, s2, n1 - 1, n2 - 1, longsSofar);
            }
            else
            {
                var longsSofar1 = LongestPalSubstring(s1, s2, n1, n2 - 1, string.Empty);
                var longsSofar2 = LongestPalSubstring(s1, s2, n1 - 1, n2, string.Empty);

                longsSofar = longsSofar1.Length > longsSofar2.Length ? longsSofar1 : longsSofar2;
            }

            return longsSofar;
        }

        public static void MaxSubArrayOddOrEven(int[] a)
        {
            int[] dp = new int[a.Length];

            dp[0] = 1;

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] % 2 == a[i - 1] % 2)
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = 1;
                }
            }

            int max = int.MinValue;
            for (int i = 0; i < dp.Length; i++)
            {
                max = Math.Max(max, dp[i]);
            }

            Console.WriteLine(max);
        }

        public static void PrintNthFabonaci(int n)
        {

            int[] fab = new int[n];

            fab[0] = 0;
            fab[1] = 1;

            for (int i = 2; i < n; i++)
            {
                fab[i] = fab[i - 1] + fab[i - 2];
            }

            Console.WriteLine(fab[n - 1]);
        }

        public static int[,] profit;

        public static void KnapSackParent(int[] w, int[] v, int maxweight)
        {
            profit = new int[maxweight + 1, w.Length + 1];

            for (int i = 0; i <= maxweight; i++)
            {
                for (int j = 0; j <= w.Length; j++)
                {

                    profit[i, j] = -1;
                }

            }

            Console.WriteLine("Profit is " + KnapSack(w, v, maxweight, w.Length));

        }

        public static int KnapSack(int[] w, int[] v, int maxweight, int n)


        {
            if (n == 0 || maxweight == 0)
                return 0;


            if (profit[maxweight, n] != -1)
                return profit[maxweight, n];


            if (w[n - 1] > maxweight)
                return KnapSack(w, v, maxweight, n - 1);


            return profit[maxweight, n] = Math.Max(KnapSack(w, v, maxweight, n - 1), v[n - 1] + KnapSack(w, v, maxweight - w[n - 1], n - 1));

        }

        public static int MinCoin(int[] coins, int sum, int n)
        {
            if (n == 0)
                return int.MaxValue;
            if (sum == 0)
                return 0;

            if (coins[n - 1] > sum)
                return MinCoin(coins, sum, n - 1);
            else
            {
                return Math.Min(MinCoin(coins, sum, n - 1), 1 + MinCoin(coins, sum - coins[n - 1], n));
            }

        }


        public static int LCSReursive(string s1, string s2, int n1, int n2)
        {
            if (n1 == 0 || n2 == 0)
            {
                return 0;
            }

            if (s1[n1 - 1] == s2[n2 - 1])
            {
                return 1 + LCSReursive(s1, s2, n1 - 1, n2 - 1);
            }
            else
            {
                return Math.Max(LCSReursive(s1, s2, n1, n2 - 1), LCSReursive(s1, s2, n1 - 1, n2));
            }

        }

        public static int LIS(int[] ar, int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return LIS(ar, n , ar[n - 1]);
        }

            public static int LIS(int[] ar, int n, int maxVal)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;
                       
            if (ar[n - 2] < maxVal)
                return 1+ LIS(ar, n - 1, ar[n-2]);

            else

                return Math.Max(LIS(ar, n - 1, ar[n - 2]), LIS(ar, n - 2, ar[n-1]));

        }
    }

}
