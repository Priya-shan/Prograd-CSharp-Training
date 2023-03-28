//Program - 2
//Write a program in C# Sharp to count a total number of duplicate elements in an array.

using System;

namespace Practice_Problems
{
    internal class _02_DuplicateElements
    {
        public static void DuplicateElements()
        {
            //get size of array from user
            Console.WriteLine("Enter Size of the Array");
            int n = Convert.ToInt32(Console.ReadLine());
            //initializing array
            int[] arr = new int[n];
            //get array elements from user
            Console.WriteLine($"Enter {n} Array Elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = 1 * Convert.ToInt32(Console.ReadLine());
            }
            //print the array elements
            Console.Write("Array Elements Are : [ ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.Write(" ]");
            Console.WriteLine();
            //initialize a dictionary to store array element and its count
            var myHashMap = new Dictionary<int, int>();
            int count = 0;
            foreach (int i in arr)
            {
                count = myHashMap.GetValueOrDefault(i, 0);
                if (myHashMap.TryGetValue(i, out int currentAmount))
                {
                    myHashMap[i] = count + 1; //updating the dictionary value
                }
                else
                {
                    myHashMap.Add(i, 1); //adding a key value pair in dictionary
                }

            }
            //iterate over dictionary and findout how many elements are duplicated
            int no_of_duplicateElements = 0;
            foreach (var kvp in myHashMap)
            {
                if (kvp.Value > 1)
                {
                    no_of_duplicateElements += 1;
                }
            }
            //print the result
            Console.WriteLine("Total No.of. Duplicate elements in the array : " + no_of_duplicateElements);
        }
    }
}
