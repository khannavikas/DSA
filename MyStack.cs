using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class MyStack
    {
        public Stack s;
        public static Stack st = new Stack();
        public int minEle;

        // Constructor
        public MyStack()
        {
            s = new Stack();
        }

        //  Get Min in O1 space and O2 time
        // Other ways is to store custom object in stack with min so far in each node
        public void getMin()
        {
            // Get the minimum number
            // in the entire stack
            if (s.Count == 0)
                Console.WriteLine("Stack is empty");

            // variable minEle stores the minimum
            // element in the stack.
            else
                Console.WriteLine("Minimum Element in the " +
                                " stack is: " + minEle);
        }

        // prints top element of MyStack
        public void Peek()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty ");
                return;
            }

            int t = (int)s.Peek(); // Top element.

            Console.Write("Top Most Element is: ");

            // If t < minEle means minEle stores
            // value of t.
            if (t < minEle)
                Console.WriteLine(minEle);
            else
                Console.WriteLine(t);
        }

        // Removes the top element from MyStack
        public void Pop()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.Write("Top Most Element Removed: ");
            int t = (int)s.Pop();

            // Minimum will change as the minimum element
            // of the stack is being removed.
            if (t < minEle)
            {
                Console.WriteLine(minEle);
                minEle = 2 * minEle - t;
            }

            else
                Console.WriteLine(t);
        }

        // Insert new number into MyStack
        public void Push(int x)
        {
            if (s.Count == 0)
            {
                minEle = x;
                s.Push(x);
                Console.WriteLine("Number Inserted: " + x);
                return;
            }

            // If new number is less than original minEle
            if (x < minEle)
            {
                s.Push(2 * x - minEle);
                minEle = x;
            }

            else
                s.Push(x);

            Console.WriteLine("Number Inserted: " + x);
        }


        #region ReverseStack recursive

        // that inserts an element 
        // at the bottom of a stack. 
        public static void insert_at_bottom(char x)
        {

            if (st.Count == 0)
                st.Push(x);

            else
            {

                // All items are held in Function 
                // Call Stack until we reach end 
                // of the stack. When the stack becomes 
                // empty, the st.size() becomes 0, the 
                // above if part is executed and 
                // the item is inserted at the bottom 
                char a = (char)st.Peek();
                st.Pop();
                insert_at_bottom(x);

                // push allthe items held 
                // in Function Call Stack 
                // once the item is inserted 
                // at the bottom 
                st.Push(a);
            }
        }

        // Below is the function that 
        // reverses the given stack using 
        // insert_at_bottom() 
        public static void reverse()
        {
            if (st.Count > 0)
            {

                // Hold all items in Function 
                // Call Stack until we 
                // reach end of the stack 
                char x = (char)st.Peek();
                st.Pop();
                reverse();

                // Insert all the items held 
                // in Function Call Stack 
                // one by one from the bottom 
                // to top. Every item is 
                // inserted at the bottom 
                insert_at_bottom(x);
            }
        }

        #endregion


        #region Find Celebirty using stack
        // Can also use 2 pointers

//        Create two indices a and b, where a = 0 and b = n - 1
//        Run a loop until a is less than b.
//        Check if a knows b, then a can’t be celebrity.so increment a, i.e.a++
//        Else b cannot be celebrity, so decrement b, i.e.b–
//      Assign a as the celebrity
//      Run a loop from 0 to n-1 and find the count of persons who knows the celebrity and 
            //the number of people whom the celebrity knows. 
            //if the count of persons who knows the celebrity is n-1 and the
            //count of people whom the celebrity knows is 0 then return the id of celebrity else return -1.



        private static bool knows(int a, int b)
        {
            return a > b;
        }

        // Returns -1 if celebrity
        // is not present. If present,
        // returns id (value from 0 to n-1).
        static int findCelebrity(int n)
        {
            Stack<int> st = new Stack<int>();
            int c;

            // Step 1 :Push everybody
            // onto stack
            for (int i = 0; i < n; i++)
            {
                st.Push(i);
            }

            while (st.Count() > 1)
            {
                // Step 2 :Pop off top
                // two persons from the
                // stack, discard one
                // person based on return
                // status of knows(A, B).
                int a = st.Pop();
                int b = st.Pop();

                // Step 3 : Push the
                // remained person onto stack.
                if (knows(a, b))
                {
                    st.Push(b);
                }

                else
                    st.Push(a);
            }

            // If there are only two people
            // and there is no
            // potential candicate
            if (st.Count() == 0)
                return -1;

            c = st.Pop();

            // Step 5 : Check if the last
            // person is celebrity or not
            for (int i = 0; i < n; i++)
            {
                // If any person doesn't
                //  know 'c' or 'a' doesn't
                // know any person, return -1
                if (i != c && (knows(c, i) ||
                              !knows(i, c)))
                    return -1;
            }
            return c;
        }

        #endregion

    }
}
