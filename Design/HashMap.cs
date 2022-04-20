using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal.Design
{

    //Hashmap is a common data structure that is implemented in various forms in different programming languages, e.g.dict in Python and HashMap in Java.The most distinguish characteristic about hashmap is that it provides a fast access to a value that is associated with a given key.

    //There are two main issues that we should tackle, in order to design an efficient hashmap data structure:
    //1). hash function design and 2). collision handling.

    //1). hash function design: the purpose of hash function is to map a key value to an address in the storage space,
    //similarly to the system that we assign a postcode to each mail address.As one can image, for a good hash function, it should map different keys evenly across the storage space, so that we don't end up with the case that the majority of the keys are concentrated in a few spaces.

    //2). collision handling: essentially the hash function reduces the vast key space into a limited address space.
    //As a result, there could be the case where two different keys are mapped to the same address, which is what we call 'collision'. Since the collision is inevitable, it is important that we have a strategy to handle the collision.

    //Depending on how we deal with each of the above two issues, we could have various implementation of hashmap data structure.


    // As one of the most intuitive implementations, we could adopt the modulo operator as the hash function, 
    //since the key value is of integer type.In addition, in order to minimize the potential collisions, it is advisable to use a prime number as the base of modulo, e.g. 2069.



    public class HashMap
    {

        List<int[]>[] lookup = new List<int[]>[6];
      
        public HashMap()
        {
            List<int> lst = new List<int>();
          
            for (int i = 0; i < 6; i++)
            {
                lookup[i] = new List<int[]>();
            }
        }

        public void Add(int key, int value)
        {
            int mod = 0;

            mod = key % 6;

            lookup[mod].Add(new int[] { key, value });
        }

        public int Get(int key, int value)
        {
            int mod = 0;
            mod = key % 6;

            foreach (var item in lookup[mod])
            {
                if (item[0] == key)
                    return item[1];
            }

            return -1;
        }


    }
}
