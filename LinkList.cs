using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace CCIFinalLL
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int d)
        {
            value = d;
        }
    }

    public class LinkList
    {
        Node head;

        public void AddNode(int n, LinkList ll = null)
        {
            if (ll == null)
                ll = this;
            Node newNode = new Node(n);

            if (ll.head == null)
            {
                ll.head = newNode;
                return;
            }

            //  Node tail;
            Node header = ll.head;

            while (header.next != null)
            {
                header = header.next;
            }


            header.next = newNode;


        }

        public LinkList RemoveDuplicate()
        {
            LinkList ll = new LinkList();
            HashSet<int> hs = new HashSet<int>();
            if (head == null || head.next == null)
                return new LinkList();
            var h = head;
            while (h.next != null)
            {
                if (!hs.Contains(h.value))
                {
                    AddNode(h.value, ll);
                    hs.Add(h.value);
                }

                h = h.next;
            }

            return ll;
        }

        public void RemoveDuplicateNonewList()
        {
            if (head == null || head.next == null)
                return;

            Node run1 = head;

            while (run1 != null)
            {
                Node run2 = run1;

                while (run2.next != null)
                {
                    if (run1.value == run2.next.value)
                    {
                        run2.next = run2.next.next;
                        //  run2 = run2.next;
                    }
                    else
                    {
                        run2 = run2.next;
                    }
                }

                run1 = run1.next;
                //  run2 = run1;
            }

            return;
        }

        public void Print()
        {
            Node nextNode = head;
            while (nextNode != null)
            {
                Console.WriteLine(nextNode.value);
                nextNode = nextNode.next;

            }
        }

        public void ReverseList()
        {
            Node n = head;
            Node prev = null;
            Node newHead = null;

            while (n != null)
            {
                newHead = new Node(n.value);
                newHead.next = prev;
                prev = newHead;
                n = n.next;
            }

            head = newHead;
        }

        // Link list is palindrome
        //1) Use 2 pointers put 
        //2) Until 2nd poniter reaches null put in stack 
        //3) Based on odd increase fast one more time
        //4) Now pop stack and increment 1st pointer to check 

    }
}
