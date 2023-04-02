
namespace CSharp_Concepts
{
    internal class Collections
    {
        public static void Main(string[] args)
        {
            //list 
            var myList = new List<int>();
            myList.Add(8);
            myList.Add(2);
            myList.Add(3);
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("----------------");
            myList.Sort();
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
            //hashset
            var myHashSet = new HashSet<int>() { 1, 4, 3, 2, 1, 2, 4 };

            foreach (int i in myHashSet)
            {
                Console.WriteLine(i);
            }

            //sortedSet
            var mySortedSet = new SortedSet<int>() { 1, 4, 3, 2, 1, 2, 4 };
            foreach (int i in mySortedSet)
            {
                Console.WriteLine(i);
            }

            //stack
            var myStack = new Stack<string>();
            myStack.Push("priya");
            myStack.Push("shan");
            myStack.Push("sneha");
            myStack.Push("hema");
            myStack.Push("murugan");

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            myStack.Pop();
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");

            Console.WriteLine(myStack.Peek());

            //Queue
            var myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------");
            myQueue.Dequeue();
            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }


        }
    }
}
