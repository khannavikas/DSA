using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Design
{
    public class HitCount
    {
        // Can use queues also
        Dictionary<int, int> countdic = new Dictionary<int, int>();
        List<int> lst = new List<int>();
        public void Hit(int timestamp)
        {
            if (countdic.Keys.Contains(timestamp))
            {
                countdic[timestamp]++;

            }
            else
            {
                countdic.Add(timestamp, 1);
                lst.Add(timestamp);
            }

            foreach (var key in countdic)
            {
                if (timestamp - key.Key >= 300)
                {
                    countdic.Remove(key.Key);
                }
            }

        }


        public int getHits(int x)
        {
            int total = 0;
            foreach (var key in countdic)
            {
                if(x - key.Key >= 300)
                {
                    countdic.Remove(key.Key);
                }
                else
                {
                    total += countdic[key.Key];
                }

            }

            return total;
        }

    }


}

