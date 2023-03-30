using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Polymorphism

A friend of yours wants to create a special calculator. He only wants two operations to be handled by that calculator
i.e. : addition and subtraction.
The calculator can only accept either 2 numbers or 3 numbers.

There are two functionalities for this calculator -
1. Normal -> in this role - the calculator works normally- where upon adding the numbers are added,
while upon subtracting the numbers are subtracted.

2. Opposite -> in this role - the calculator works opposite to the normal role - where upon adding the numbers are 
subtracted, while upon subtracting the numbers are added. That friend have approached you for the help, in creating
such a calculator.
 */
namespace Practice_Problems
{
    internal class polymorphicCalci
    {
        static bool normal_mode;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Special Calculator !");
            Console.WriteLine("Select your Mode of Working : \n 1 -> Normal \n 2 -> Opposite");
            int mode = Convert.ToInt32(Console.ReadLine());
            if (mode == 1)
            {
                normal_mode = true;
            }
            else
            {
                normal_mode = false;
            }
            Console.WriteLine("Enter the Number of Inputs");
            int no_of_inputs=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter values");
            int[] arr=new int[no_of_inputs];
            for(int i = 0; i < no_of_inputs; i++)
            {
                arr[i]= Convert.ToInt32(Console.ReadLine());
            }
            if (arr.Length == 2)
            {
                special_calculator(arr[0], arr[1]);
            }
            else if(arr.Length == 3)
            {
                special_calculator(arr[0], arr[1], arr[2]);
            }
            else
            {
                Console.WriteLine("For now this special character can only take 2 or 3 values at max");
            }

        }
        public static void special_calculator(int x, int y)
        {

            Console.WriteLine("x : "+x + " y : " +y);
            if (normal_mode)
            {
                Console.WriteLine("Addition : " + (x + y));
                Console.WriteLine("Subraction : " + (x - y));
            }
            else
            {
                Console.WriteLine("Addition : " + (x - y));
                Console.WriteLine("Subraction : " + (x + y));
            }
        }
        public static void special_calculator(int x, int y, int z)
        {
            Console.WriteLine("x : " + x + " y : " + y + " z : " + z);
            if (normal_mode)
            {
                Console.WriteLine("Addition : " + (x + y + z));
                Console.WriteLine("Subraction : " + (x - y - z));
            }
            else
            {
                Console.WriteLine("Addition : " + (x - y - z));
                Console.WriteLine("Subraction : " + (x + y + z));
            }
        }
       
    }
}
