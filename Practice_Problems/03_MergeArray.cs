//Program - 3
// Write a program in C# Sharp to merge two arrays of same size sorted in ascending order.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class MergeArray
    {
        public static void Main(string[] args) 
        {
            int[] arr1 = new int[]{ 22, 11, 23, 10, 3 };
            int[] arr2 = new int[] { 9, 15, 25, 19, 1 };

            sortArray(arr1);
            sortArray(arr2);

            Console.Write("Array 1:");
            printArray(arr1);
            Console.Write("Array 2:");
            printArray(arr2);

            int[] result=new int[arr1.Length*2];
            int i = 0,j=0,k=0;
            while(i< arr1.Length && j<arr2.Length)
            {
                if (arr1[i] < arr2[j])
                {
                    result[k++] = arr1[i];
                    i++;
                }
                else
                {
                    result[k++] = arr2[j];
                    j++;
                }
            }

            while(i< arr1.Length)
            {
                result[k++] = arr1[i++];
            }
            while (j < arr2.Length)
            {
                result[k++] = arr2[j++];
            }
            Console.Write("Merged Array :");
            printArray(result);
        }
        public static void sortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for(int j=0; j < arr.Length - i-1; j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j + 1] = temp;
                    }
                }            
            }

            
        }


        public static void printArray(int[] arr)
        {
            Console.Write("[ ");
            foreach (int i in arr)
            {
                Console.Write(i+" ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
