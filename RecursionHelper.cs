using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
   public static class RecursionHelper
    {

        public static void PrintBalancedParenthesis(int open, int close, string sofar)
        {
            if (close == 0)
            {
                Console.WriteLine(sofar);
                return;
            }

            if(open >= close)
            {
                PrintBalancedParenthesis(open - 1, close, sofar + "(");                
            }
            else if(open == 0)
            {
                PrintBalancedParenthesis(open , close-1, sofar + ")");               
            }
            else
            {
                PrintBalancedParenthesis(open, close - 1, sofar + ")");
                PrintBalancedParenthesis(open -1, close , sofar + "(");
            }
        }


    }
}
