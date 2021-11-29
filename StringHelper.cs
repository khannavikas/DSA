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
                        s = swap(s, i, p1);
                        count++;
                        p1++;
                        p2--;

                    }
                }

            }

            return count;
        }


        public static bool areAnagram(char[] str1,
                        char[] str2)
        {

            // Create a count array and initialize
            // all values as 0
            int[] count = new int[256];
            int i;

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < str1.Length; i++)
            {
                count[str1[i] - 'a']++;
                count[str2[i] - 'a']--;
            }

            // If both strings are of different
            // Length. Removing this condition
            // will make the program fail for
            // strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;

            // See if there is any non-zero
            // value in count array
            for (i = 0; i < 256; i++)
                if (count[i] != 0)
                {
                    return false;
                }

            return true;
        }


        public static int KMPSearch(String pat, String txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            // create lps[] that will hold the longest
            // prefix suffix values for pattern
            int[] lps = new int[M];
            int j = 0; // index for pat[]

            // Preprocess the pattern (calculate lps[]
            // array)
            computeLPSArray(pat, M, lps);

            int i = 0; // index for txt[]
            int res = 0;
            int next_i = 0;

            while (i < N)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    // When we find pattern first time,
                    // we iterate again to check if there
                    // exists more pattern
                    j = lps[j - 1];
                    res++;

                    // We start i to check for more than once
                    // appearance of pattern, we will reset i
                    // to previous start+1
                    if (lps[j] != 0)
                        i = ++next_i;
                    j = 0;
                }

                // mismatch after j matches
                else if (i < N && pat[j] != txt[i])
                {
                    // Do not match lps[0..lps[j-1]] characters,
                    // they will match anyway
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }
            return res;
        }

        private static void computeLPSArray(String pat, int M, int[] lps)
        {
            // length of the previous longest prefix suffix
            int len = 0;
            int i = 1;
            lps[0] = 0; // lps[0] is always 0

            // the loop calculates lps[i] for i = 1 to M-1
            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else // (pat[i] != pat[len])
                {
                    // This is tricky. Consider the example.
                    // AAACAAAA and i = 7. The idea is similar
                    // to search step.
                    if (len != 0)
                    {
                        len = lps[len - 1];

                        // Also, note that we do not increment
                        // i here
                    }
                    else // if (len == 0)
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }

        private static HashSet<string> tempS = new HashSet<string>();
        public static HashSet<string> PrintWithSpace(string prefix, string s)
        {

            if (s.Length == 0)
                return null;

            if (s.Length > 1)
            {
                tempS.Add(prefix + s[0] + " " + s.Substring(1));
                tempS.Add(prefix + s[0] + s.Substring(1));
                PrintWithSpace(prefix + s[0] + " ", s.Substring(1));
                PrintWithSpace(prefix + s[0].ToString(), s.Substring(1));

            }
            else
            {
                tempS.Add(prefix + s[0] + s.Substring(1));
            }

            return tempS;
        }
    }
}
