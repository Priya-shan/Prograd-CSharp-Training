//Program - 4
//Write a program in C# Sharp to separate odd and even integers in separate arrays
namespace Practice_Problems
{
    internal class _04_SeperateOddEven
    {
        public static void Main(string[] args)
        {
            int[] arr = { 12, 22, 11, 6, 23, 10, 2, 3 };
            int EventCount = 0, OddCount = 0;
            foreach (int i in arr)
            {
                if(i%2 == 0)
                {
                    EventCount++;
                }
                else
                {
                    OddCount++;
                }
            }
            int[] EvenArr=new int[EventCount];

            int[] OddArr=new int[OddCount];

            int EvenIdx = 0,OddIdx = 0;

            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    EvenArr[EvenIdx++] = i;
                }
                else
                {
                    OddArr[OddIdx++] = i;
                }
            }

            Console.Write("Original Array :");
            printArray(arr);
            Console.Write("Even Array :");
            printArray(EvenArr);
            Console.Write("Odd Array :");
            printArray(OddArr);


        }
        public static void printArray(int[] arr)
        {
            Console.Write("[ ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
