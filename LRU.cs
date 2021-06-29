using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
     class Node
    {
      public  int key;
      public  int value;
      public  Node pre;
       public Node next;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class LRUCache
    {
        private Dictionary<int, Node> map;
        private int capacity, count;
        private Node head, tail;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            map = new Dictionary<int, Node>();
          
            head = new Node(0, 0);
            tail = new Node(0, 0);
            head.next = tail;
            tail.pre = head;
            head.pre = null;
            tail.next = null;
            count = 0;
        }

        public void deleteNode(Node node)
        {
            node.pre.next = node.next;
            node.next.pre = node.pre;
        }

        public void addToHead(Node node)
        {
            node.next = head.next;
            node.next.pre = node;
            node.pre = head;
            head.next = node;
        }

        // This method works in O(1)
        public int get(int key)
        {
            if (map[key] != null)
            {
                Node node = map[key];
                int result = node.value;
                deleteNode(node);
                addToHead(node);
              
                return result;
            }
          
            return -1;
        }

        // This method works in O(1)
        public void set(int key, int value)
        {
           
            if (map[key] != null)
            {
                Node node = map[key];
                node.value = value;
                deleteNode(node);
                addToHead(node);
            }
            else
            {
                Node node = new Node(key, value);
                map.Add(key, node);
                if (count < capacity)
                {
                    count++;
                    addToHead(node);
                }
                else
                {
                    map.Remove(tail.pre.key);
                    deleteNode(tail.pre);
                    addToHead(node);
                }
            }
        }
    }


}




