using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class StringHelper
    {
        public static void Permumation(string a)
        {

        }

        public static void PrintPermutation(string s, string prefix)
        {
            if (s.Length == 0)
            {
                Console.WriteLine(prefix);
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                string pre = prefix + s[i];
                var input = s.Substring(0, i) + s.Substring(i + 1);

                PrintPermutation(input, pre);

            }
        }


        private static void permute(string str,
                                int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        private static String swap(string a,
                            int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }



        //  StringHelper.MinSwapToPalindrome("aabcb ");
        public static int MinSwapToPalindrome(string s)
        {
            if (s.Length <= 1)
                return 0;

            int p1 = 0;
            int p2 = s.Length - 1;
            int count = 0;

            while (p1 < p2)
            {
                if (s[p1] == s[p2])
                {
                    p1++;
                    p2--;
                }
                else
                {
                    int i = p1;
                    while (s[i] != s[p2])
                    {
                        i++;
                        if (i > p2)
                        {
                            return -1;
                        }
                    }

                    if (s[i] == s[p2])
                    {
                      s =  swap(s, i, p1);
                        count++;
                        p1++;
                        p2--;

                    }
                }

            }

            return count;
        }

    }
}
