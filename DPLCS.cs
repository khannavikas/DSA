using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class DPLCS
    {

        public static int LCSRecusrsive(string s1, string s2, int m, int n)
        {           
            if (m == 0 || n == 0)
                return 0;

            if (s1[m - 1] == s2[n - 1])
                return 1 + LCSRecusrsive(s1, s2, m - 1, n - 1);

            return Math.Max(LCSRecusrsive(s1, s2, m - 1, n), LCSRecusrsive(s1, s2, m, n - 1));
        }


        public static int[,] mem = null;

        public static int LCSMemMain(string s1, string s2, int m, int n)
        {

            mem = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    mem[i, j] = -1;
                }
            }

            return LCSMemonisation(s1, s2, m, n);
        }

        private static int LCSMemonisation(string s1, string s2, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            if (mem[m, n] != -1)
                return mem[m, n];

            if (s1[m - 1] == s2[n - 1])
            {
                mem[m, n] = 1 + LCSMemonisation(s1, s1, m - 1, n - 1);

                return mem[m, n];
            }


            return mem[m, n] = Math.Max(LCSRecusrsive(s1, s2, m - 1, n), LCSRecusrsive(s1, s2, m, n - 1));

        }

        public static int LCSDP(string s1, string s2, int m, int n)
        {
            mem = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        mem[i, j] = 0;

                    }

                    else if (s1[i - 1] == s2[j - 1])
                    {
                        mem[i, j] = 1 + mem[i - 1, j - 1];
                    }

                    else
                    {
                        mem[i, j] = Math.Max(mem[i - 1, j], mem[i, j - 1]);
                    }
                }
            }


            return mem[m, n];
        }

        private static int result = 0;

        public static int LongestSubstringRecursive(string s1, string s2, int m, int n, int lcount)
        {
            int lcount1 = 0; ;
            int lcount2;
            int lcount3;

            if (m == 0 || n == 0)
                return lcount;

            lcount1 = lcount;
            if (s1[m - 1] == s2[n - 1])
            {
                lcount1 = LongestSubstringRecursive(s1, s2, m - 1, n - 1, lcount + 1);
            }

            lcount2 = LongestSubstringRecursive(s1, s2, m - 1, n, 0);

            lcount3 = LongestSubstringRecursive(s1, s2, m, n - 1, 0);

            return Math.Max(Math.Max(lcount1, lcount2), lcount3);
        }


    }
}
