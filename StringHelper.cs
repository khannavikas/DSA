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
            if(s.Length ==0)
            {
                Console.WriteLine(prefix);
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                 string pre = prefix +s[i];
                var input = s.Substring(0, i) + s.Substring(i + 1);

                PrintPermutation(input, pre);

            }
        }



    }
}
