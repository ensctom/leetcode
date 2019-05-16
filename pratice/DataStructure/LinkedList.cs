using System;
using System.Collections.Generic;
using System.Text;

namespace practice.DataStructure
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class LinkedList
    {
        private ListNode current;
        private ListNode head;

        public LinkedList()
        {
        }

        public LinkedList(int[] listArray)
        {
            foreach(int item in listArray)
            {
                Add(item);
            }
        }
        public void Add(int data)
        {

            ListNode n = new ListNode(data);

            if (head == null)
            {
                head = current = n;
            }
            else
            {
                current.next = n;
                current = n;
            }

        }
        public void PrintList()
        {
            var currentNode = head;
            if (currentNode != null)
            {
                while (currentNode != null)
                {
                    Console.WriteLine(currentNode.val);
                    currentNode = currentNode.next;

                }
            }
            else
            {
                Console.WriteLine("The list is empty");
            }


        }
        public void ReverseList()
        {
            Stack<ListNode> s = new Stack<ListNode>();
            current = head;

            while (current != null)
            {
                s.Push(current);
                current = current.next;
            }

            current = head = s.Pop();

            while (s.Count != 0)
            {
                ListNode temp = s.Pop();
                current.next = temp;
                current = temp;
            }
            current.next = null;
        }
        public ListNode Head() { return head; }
    }
}
