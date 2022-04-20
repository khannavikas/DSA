using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCIFinal
{
    public class LFUCache
    {
        public class Node
        {
            public int key, val, cnt;
            public Node prev, next;
            public Node(int key, int val)
            {
                this.key = key;
                this.val = val;
                cnt = 1;
            }
        }

        public class DLList
        {
            public Node head, tail;
            public int size;
            public DLList()
            {
                head = new Node(0, 0);
                tail = new Node(0, 0);
                head.next = tail;
                tail.prev = head;
            }

            public void add(Node node)
            {
                head.next.prev = node;
                node.next = head.next;
                node.prev = head;
                head.next = node;
                size++;
            }

            public void remove(Node node)
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
                size--;
            }

            public Node removeLast()
            {
                if (size > 0)
                {
                    Node node = tail.prev;
                    remove(node);
                    return node;
                }
                else return null;
            }
        }

        public int capacity, leastFrequenyCount;

        // consists of keys vs nodes [with keys and values]
        public Dictionary<int, Node> nodeMap;
        // consists of frequency vs doubly linked list of items
        // if key 1, key 2 and key 3 are occuring only once then,  map would like below
        // 1 -> head -> node key1 -> node key2 -> node key3

        // lets say with key 1 was updated again, then map would update as below
        // 1 -> head -> node key1 -> node key3
        // 2 -> head -> node key1
        public Dictionary<int, DLList> countMap;

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            nodeMap = new Dictionary<int, Node>();
            countMap = new Dictionary<int, DLList>();
        }

        public int get(int key)
        {
            if (!nodeMap.Keys.Contains(key))
                return -1;
            Node node = nodeMap[key];

            update(node);
            return node.val;
        }

        public void put(int key, int value)
        {
            if (capacity == 0) return;
            Node node;
            // possibility 1 - Node already exists
            if (nodeMap.Keys.Contains(key))
            {
                // get current node status- use same node in count map doubly linkedlist
                node = nodeMap[key];
                node.val = value;
                // if exists already then there will direct impact on frequency aka count map
                // update count map. Move the node from old frequency key and associate it with new frequency key 
                // new frequency key may or may not exists already
                update(node);
            }
            else // 
            {
                // possibility 2 - Cache is full 
                if (nodeMap.Keys.Count == capacity)
                {
                    // Find least freq list
                    DLList lastList = countMap[leastFrequenyCount];

                    //Remove last node from nodemap and last list
                    nodeMap.Remove(lastList.removeLast().key);
                }
                // possibility 3
                node = new Node(key, value);
                nodeMap.Add(key, node);
                leastFrequenyCount = 1;

                DLList newList = null;

                if (!countMap.Keys.Contains(node.cnt))
                    countMap.Add(node.cnt, new DLList());

                newList = countMap[node.cnt];
                newList.add(node);
                // countMap.Add(node.cnt, newList);
            }
        }

        // consists of frequency vs doubly linked list of items
        // if key 1, key 2 and key 3 are occurring only once then,  map would like below
        // 1 -> head -> node key1 -> node key2 -> node key3

        // lets say with key 1 was updated again, then map would update as below
        // 1 -> head -> node key1 -> node key3
        // 2 -> head -> node key1

        private void update(Node node)
        {
            DLList oldList = countMap[node.cnt];
            oldList.remove(node);
            // keep track of lowest frequency. One of the indicators of lowest frequency is, oldList size becoming zero
            // it indicates that one count level has gone completely empty and lowest frequency count needs to be updated 
            if (node.cnt == leastFrequenyCount && oldList.size == 0)
            {
                leastFrequenyCount++;
            }
            node.cnt++;
            DLList newList = null;
            if (!countMap.Keys.Contains(node.cnt))
                countMap.Add(node.cnt, new DLList());

            newList = countMap[node.cnt];
            newList.add(node);
        }
    }
}
