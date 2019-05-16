using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace practice.DataStructure
{
    public class ListNode<T>
    {
        public T val;
        public ListNode<T> next;
        public ListNode(T x) { val = x; }
    }
    public class LinkedList<T>
    {
        public ListNode<T> current;
        public ListNode<T> head;

        public void Add(T data)
        {

            ListNode<T> n = new ListNode<T>(data);

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
            Stack<ListNode < T >> s = new Stack<ListNode<T>>();
            current = head;

            while (current != null)
            {
                s.Push(current);
                current = current.next;
            }


            current = head = s.Pop();

            while (s.Count != 0)
            {
                ListNode<T> temp = s.Pop();
                current.next = temp;
                current = temp;
            }
            current.next = null;
        }
    }

}
