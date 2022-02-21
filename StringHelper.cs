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


        public static int MinSwapsToPalindrome(string s)

        {

            int stPtr = 0;
            int endPtr = s.Length - 1;
            int swaps = 0;

            while (stPtr < endPtr)
            {

                if (s[stPtr] == s[endPtr])
                {
                    stPtr++;
                    endPtr--;

                }
                else
                {

                    int tempPtr = endPtr;

                    while (stPtr < tempPtr && s[tempPtr] != s[stPtr])
                    {
                        tempPtr--;

                    }

                    if (tempPtr <= stPtr)
                        return -1;


                    while (tempPtr < endPtr)
                    {

                        swap(tempPtr, tempPtr + 1, ref s);
                        swaps++;
                        tempPtr++;

                    }


                    endPtr--;
                    stPtr++;

                }



            }


            return swaps;



        }


        private static void swap(int i, int b, ref string s)
        {
            char[] sa = s.ToCharArray();
            char temp = sa[i];
            sa[i] = s[b];
            sa[b] = temp;

            s = new string(sa);

        }

        public static void PrintAllSubsequence(string s, string prefix)
        {

            if (s.Length == 0)
            {
                Console.WriteLine(prefix);

                return;
            }

            PrintAllSubsequence(s.Substring(1), prefix + s[0]);

            PrintAllSubsequence(s.Substring(1), prefix);

        }

        public static List<string> Subsequnece(string s)
        {
            if (s.Length == 0)
                return new List<string>() { "" };

            char prefix = s[0];

            var lst = Subsequnece(s.Substring(1));
            var newLst = new List<string>();

            foreach (var item in lst)
            {
                newLst.Add(prefix + item);
            }

            newLst.AddRange(lst);

            return newLst;
        }

        public static string Merge(string A, string B)
        {
            string mergedWord = "";

            int ptrA = 0;
            int ptrB = 0;

            while (ptrA < A.Length && ptrB < B.Length)
            {

                if (A[ptrA] > B[ptrB])
                {
                    mergedWord += A[ptrA];
                    ptrA++;

                }
                else
                {
                    mergedWord += B[ptrB];
                    ptrB++;
                }


            }

            while (ptrA < A.Length)
            {
                mergedWord += A[ptrA];
                ptrA++;
            }

            while (ptrB < B.Length)
            {
                mergedWord += B[ptrB];
                ptrB++;
            }

            return mergedWord;

        }


        public static string wordA = "";
        public static string wordB = "";

        // Google question

        public static List<string> lst = new List<string>() { "VK", "NZM" };

        public static void UnMerge(string A, string B, string restofString, string orginal)
        {

            if (restofString.Length == 0)
            {
                if (Merge(A, B) == orginal && lst.Contains(A) && lst.Contains(B))
                {

                    wordA = A;
                    wordB = B;

                }
                return;
            }

            if (string.IsNullOrEmpty(wordA) || string.IsNullOrEmpty(wordB))
            {

                UnMerge(A + restofString[0], B, restofString.Substring(1), orginal);

                UnMerge(A, B + restofString[0], restofString.Substring(1), orginal);
            }
        }

        public static bool ValidPalindrome(string s)
        {

            int strPtr = 0;
            int endPtr = s.Length - 1;

            while (strPtr < endPtr)
            {
                if (s[strPtr] == s[endPtr])
                {
                    strPtr++;
                    endPtr--;
                }
                else
                {
                    break;
                }

            }

            if (strPtr >= endPtr)
                return true;

            return IsPalindrome(s.Substring(strPtr, endPtr - strPtr)) || IsPalindrome(s.Substring(strPtr + 1, endPtr - strPtr));

        }

        public static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                    return false;
            }

            return true;
        }

        public static void Perm(string pre, string s)
        {
            if (s.Length == 0)
            {
                Console.WriteLine(pre);

                return;
            }

            for (int i = 0; i < s.Length; i++)
            {
                Perm(pre + s[i], s.Substring(0, i) + s.Substring(i + 1));

            }

        }

        public static void PremutationBackTracking(string s, string perm, List<char> used)
        {
            // Goal is length is same
            if (s.Length == perm.Length)
            {
                Console.WriteLine(perm);
                return;
            }

            //Choice
            // For each char in string, try each one of them
            for (int i = 0; i < s.Length; i++)
            {
                // Valid choice Char not used already
                if (!used.Contains(s[i]))
                {
                    // Make a choice
                    used.Add(s[i]);

                    // Recurse againg
                    PremutationBackTracking(s, perm + s[i], used);

                    // Undo choice
                    used.Remove(s[i]);
                }

            }

        }


        // Google question 
        // Find all words that we can make 
        // Constraint chracter cannot occur more than x times consecutively 

        public static void AllCombination(char[] array, int times, string word, int len, Dictionary<char, int> dic)
        {
            if (word.Length == len)
            {
                Console.WriteLine(word);
                return;
            }

            foreach (var item in array)
            {
                if (CanUseChar(dic, times, item, word))
                {
                    if (!dic.ContainsKey(item))
                    {
                        dic.Add(item, 1);
                    }

                    AllCombination(array, times, word + item, len, dic);
                    dic.Remove(item);
                }

            }


        }

        private static bool CanUseChar(Dictionary<char, int> dic, int times, char c, string word)
        {

            int i = word.Length - 1;
            while (i >= 0 && times > 0)
            {
                if (word[i] == c)
                {
                    times--;
                }
                else
                {
                    break;
                }

                i--;
            }

            if (times > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


            // return true;
        }



        public static void PrintAllStringsKLength(List<char> lst, string s, int k)
        {
            if (s.Length == k)
            {
                Console.WriteLine(s);
                total++;
                return;
            }

            foreach (var item in lst)
            {
                PrintAllStringsKLength(lst, s + item, k);
            }

        }

        public static int total = 0;
        public static void PrintAllStringsKLengthWithoutRepetion(List<char> lst, string s, int k, List<char> used)
        {
            if (s.Length == k)
            {
                total++;
                Console.WriteLine(s);
                return;
            }

            foreach (var item in lst)
            {
                if (!used.Contains(item))
                {
                    used.Add(item);
                    PrintAllStringsKLengthWithoutRepetion(lst, s + item, k, used);
                    used.Remove(item);
                }

            }

        }

        public static void PrintStringWithSpaces(string s, string final, bool lastspace)
        {
            if (s.Length == 0 && final.Length > 0)
            {
                Console.WriteLine(final);
                return;
            }

            if (final.Length == 0 && s.Length > 0)
            {
                PrintStringWithSpaces(s.Substring(1), final + s[0], false);
                return;
            }

            if (!lastspace)
            {
                PrintStringWithSpaces(s, final + " ", true);
            }

            PrintStringWithSpaces(s.Substring(1), final + s[0], false);

        }




        public static string DiverseString(int a, int b, int c, string s, int len)
        {
            string one = "";
            string two = "";
            string three = "";

            if (a > 0 && isValid('a', s))
            {
                one = DiverseString(a - 1, b, c, s + "a", len);
            }

            if (b > 0 && isValid('b', s))
            {
                two = DiverseString(a, b - 1, c, s + "b", len);

            }

            if (c > 0 && isValid('c', s))
            {
                three = DiverseString(a, b, c - 1, s + "c", len);

            }

            if (one.Length > s.Length)
            {
                s = one;
            }

            if (two.Length > s.Length)
            {
                s = two;
            }

            if (three.Length > s.Length)
            {
                s = three;
            }

            return s;
        }

        private static bool isValid(char a, string s)
        {
            int len = s.Length;

            if (len >= 2 && s[len - 1] == a && s[len - 2] == a)
                return false;

            return true;
        }


        public static string MinRemoveToMakeValid(string s)
        {
            int open = 0;

            string valid = "";
            List<int> index = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    open++;
                }
                else if (s[i] == ')')
                {
                    open--;
                }

                if (open < 0)
                {
                    index.Add(i);
                    open = 0;
                }

            }

            int i1 = s.Length - 1;
            while (open > 0 && i1 >= 0)
            {

                if (s[i1] == '(')
                {
                    index.Add(i1);
                    open--;

                }

                i1--;
            }


            for (int i = 0; i < s.Length; i++)
            {
                if (!index.Contains(i))
                {
                    valid = valid + s[i];
                }
            }

            return valid;

        }

        public class Emp
        {
            public int Age;
        }


        public class EmpComparer : IComparer<Emp>
        {
            public int Compare(Emp x, Emp y)
            {
                if (x.Age == y.Age)
                    return 0;

                //-1 means no change, first number x will come first, based on > or <
                if (x.Age > y.Age)
                    return -1;
                else
                    return 1;
            }
        }

        public static bool ValidWordAbbreviation(string word, string abbr)
        {

            int i = 0;
            int j = 0;


            while (j < abbr.Length && i < word.Length)
            {
                if (word[i] == abbr[j])
                {
                    i++;
                    j++;
                }

                if (j < abbr.Length && abbr[j] == '0')
                    return false;

                string sub = "";
                while (j < abbr.Length && abbr[j] >= '0' && abbr[j] <= '9')
                {
                    sub += abbr[j];
                    j++;

                }

                if (sub != "")
                {
                    int x = Convert.ToInt32(sub);

                    i += x;
                    // i--;
                }

            }

            if (i == word.Length && j == abbr.Length)
                return true;

            return false;
        }

        public static string CustomSortString(string order, string s)
        {

            StringBuilder sb = new StringBuilder();

            int[] count = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                count[s[i] - 'a']++;
            }

            foreach (char c in order)
            {
                for (int j = 0; j < count[c - 'a']; j++)
                {
                    sb.Append(c);
                }

                count[c - 'a'] = 0;
            }

            for (int m = 0; m < 26; m++)
            {
                if (count[m] > 0)
                {
                    for (int j = 0; j < count[m]; j++)
                    {
                        sb.Append((char)(m + 'a'));
                    }
                }
            }

            return sb.ToString();
        }

        public static int GetNumber(string s)
        {

            // Initialize a variable 
            int num = 0;
            int n = s.Length;

            // Iterate till length of the string 
            for (int i = 0; i < n; i++)

                // Subtract 48 from the current digit 
                num = num * 10 + ((int)s[i] - 48);

            return num;
        }

        public static string AddStrings(string num1, string num2)
        {
            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;
            int carry = 0;
            StringBuilder sb = new StringBuilder();


            while (p1 >= 0 || p2 >= 0)
            {
                int n1 = p1 >= 0 ? num1[p1] - 48 : 0;
                int n2 = p2 >= 0 ? num2[p2] - 48 : 0;
                int sum = n1 + n2 + carry;
                carry = sum / 10;

                sb.Append(sum % 10);

                p1--;
                p2--;


            }

            if (carry != 0)
            {
                sb.Append(carry);
            }


            string s = sb.ToString();

            return new String(s.Reverse().ToArray());
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                int[] a = new int[26];
                foreach (char c in s)
                {
                    a[c - 97]++;
                }

                StringBuilder sb = new StringBuilder();
                for (int p = 0; p < 26; p++)
                {
                    sb.Append(a[p]);
                    sb.Append("#");
                }


                if (!dic.Keys.Contains(sb.ToString()))
                {
                    dic.Add(sb.ToString(), new List<string>() { s });
                }
                else
                {
                    dic[sb.ToString()].Add(s);
                }

            }

            IList<IList<string>> ls = new List<IList<string>>();

            foreach (var key in dic.Keys)
            {
                ls.Add(dic[key]);
            }

            return ls;
        }




        public static bool IsPalindromeSenetence(string s)
        {

            if (s.Length <= 0)
                return true;

            int start = 0;
            int end = s.Length - 1;


            while (start < end)
            {

                while (!isAplhaNumeric(s[start]) && start < end)
                    start++;


                while (!isAplhaNumeric(s[end]) && start < end)
                    end--;

                if (start >= end)
                    return true;

                if (!AreEqual(s[start], s[end]))
                    return false;


                start++;
                end--;
            }

            return true;
        }




        private static bool isAplhaNumeric(char c)
        {

            if (c >= 97 && c <= 122)
                return true;

            if (c >= 48 && c <= 57)
                return true;

            if (c >= 65 && c <= 90)
                return true;

            return false;

            //    StringBuilder sb = new StringBuilder();
            //  sb.Remove(        }
        }

        private static bool AreEqual(char c1, char c2)
        {
            if (c1 == c2)
                return true;

            if (c1 >= 48 && c1 <= 57)
                return false;

            if (c2 >= 48 && c2 <= 57)
                return false;

            if ((char)(c1 + 32) == c2)
                return true;

            if (c1 == (char)(c2 + 32))
                return true;

            return false;


        }



        public static string RemoveDuplicates(string s, int k)
        {

            if (s.Length == 0 || k == 0)
                return s;

            return RemoveDuplicateRec(s, k);
        }


        //1209. Remove All Adjacent Duplicates in String II
        private static string RemoveDuplicateRec(string s, int k)
        {

            if (s.Length == 0 || k == 0)
                return s;

            if (s.Length == 1 && k == 1)
                return "";

            Stack<int> stcont = new Stack<int>();

            StringBuilder sb = new StringBuilder(s);


            for (int i = 0; i < sb.Length; i++)
            {

                if (i == 0)
                {
                    stcont.Push(1);
                    continue;
                }

                if (sb[i] != sb[i - 1])
                {
                    stcont.Push(1);
                    continue;
                }

                if (sb[i] == sb[i - 1] && stcont.Count > 0 && stcont.Peek() == k - 1)
                {
                    for (int m = 0; m < k; m++)
                    {
                        sb.Remove(i - m, 1);
                    }

                    // Important subtract K not k-1 as i will increase in loop by 1
                    i = i - (k);
                    stcont.Pop();
                }
                else if (sb[i] == sb[i - 1])
                {
                    int topcount = stcont.Pop();
                    stcont.Push(topcount + 1);
                }
            }



            return sb.ToString();





        }


        public static string RemoveOccurrences(string s, string part)
        {

            if (s.Length == 0 || part.Length == 0)
                return s;

            if (part.Length > s.Length)
                return s;

            return Remove(s, part);

        }


        private static string Remove(string s, string p)
        {
            StringBuilder sb = new StringBuilder(s);

            int p1 = 0;
            int p2 = 0;

            while (p1 < sb.Length && sb.Length > 0)
            {
                if (p1 < 0)
                {
                    p1 = 0;
                }

                if (sb[p1] == p[p2])
                {
                    p1++;
                    p2++;

                    if (p2 == p.Length)
                    {

                        for (int i = 0; i < p.Length; i++)
                        {
                            sb.Remove(p1-1, 1);
                            p1--;
                        }

                        p1 = p1 - p.Length;
                        p2 = 0;
                        continue;
                    }
                }
                else if (sb[p1] != p[p2])
                {
                    if (p2 == 0)
                    {
                        p1++;
                    }
                    
                    p2 = 0;

                }
            }

            return sb.ToString();


        }


    }
}

