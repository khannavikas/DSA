using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCIFinalLL;

namespace CCIFinal
{

    public class MyQueue
    {
        public CCIFinalLL.Node head;
        public CCIFinalLL.Node tail;

        public void enQueue(int a)
        {
            if (head == null)
            {
                head = new CCIFinalLL.Node(a);
                tail = head;
                return;
            }

            var newTail = new CCIFinalLL.Node(a);
            tail.next = newTail;
            tail = newTail;

        }

        public int? deQueue()
        {
            if (head == null)
            {
                return null;
            }

            int val = head.value;
            head = head.next;

            // If front becomes NULL,
            // then change rear also as NULL
            if (this.head == null)
                this.tail = null;

            return val;

        }

        public void Print()
        {
            var h = head;

            while(h != null)
            {
                Console.WriteLine(h.value);
                h = h.next;
            }

        }

        public void Reverse()
        {
            if (head == null)
                return;

            var h = head;
            CCIFinalLL.Node prev = null;

            while(h != null)
            {
                CCIFinalLL.Node newhead = new CCIFinalLL.Node(h.value);
                newhead.next = prev;
                prev = newhead;

                if (newhead.next == null)
                    tail = newhead;

                h = h.next;
            }

            head = prev;
        }

        public void Sort()
        {

            var pointer1 = head;
            var pointer2 = pointer1.next;


            while (pointer1 != null)
            {
               
                if (pointer2 != null && pointer2.value < pointer1.value)
                {
                    int tem = pointer1.value;
                    pointer1.value = pointer2.value;
                    pointer2.value = tem;
                    pointer2 = pointer2.next;
                }
                else if (pointer2 != null && pointer2.value > pointer1.value)
                {
                    pointer2 = pointer2.next;
                }
                else
                {
                    pointer1 = pointer1.next;
                }


            }
        }

    }
}
