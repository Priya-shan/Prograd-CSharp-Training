using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class LinkedList
    {
        public static void Main(string[] args)
        {
            var myLinkedList = new LinkedList<int>();
            var myLinkedList1 = new LinkedList<int>();
            myLinkedList.AddLast(1);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddLast(4);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(5);
            myLinkedList.AddLast(6);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddLast(4);


            LinkedListNode<int> node1 = myLinkedList.Find(2);
            //myLinkedList.AddBefore(node, 10);
            //myLinkedList.AddBefore(node1, 10);


            foreach (var i in myLinkedList)
            {
                if (i == 2)
                {
                    myLinkedList1.AddLast(10);

                }
                myLinkedList1.AddLast(i);
            }

            foreach (int i in myLinkedList1)
            {
                Console.WriteLine(i);
            }

        }
    }
}
