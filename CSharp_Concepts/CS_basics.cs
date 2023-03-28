using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    public class CS_basics
    {
        public void Main(string[] args)
        {
            //integer
            int a = 10;
            //typecast
            int b = (int)20.1;
            Console.WriteLine(a + b);
            //for loop
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(i);
            }
            //float means no div by 0 exception

            //string handling
            string str = "hello";
            char[] strArray = str.ToCharArray();
            Console.WriteLine(str);
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
            }
            //if else
            for (int i = 0; i < a; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("mid");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            int j = 0;
            while (j <= 3)
            {
                Console.WriteLine(j);
                j++;
            }

            //do while
            int k = 0;
            do
            {
                Console.WriteLine(k);
                k++;
            }
            while (k > 0 && k < 10);

        //goto (not much useful)
        loopp:
            for (int i = 0; i < 7; i++)
            {
                if (i == 3)
                {
                    goto warning;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        warning:
            Console.WriteLine("reached 3");

            //getting user input
            Console.WriteLine("enter age");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age < 18)
            {
                goto loopp;
            }

            //call be value
            Console.WriteLine("call by value");
            int aa = 1;
            callbyval(aa);
            Console.WriteLine("after fn call " + aa);

            //call by reference
            Console.WriteLine("call by reference");
            int bb = 1;
            callbyref(ref bb);
            Console.WriteLine("after fn call " + bb);

        }
        public static void callbyval(int aa)
        {
            aa = 20;
            Console.WriteLine("inside fn call " + aa);
        }
        public static void callbyref(ref int bb)
        {
            bb = 20;
            Console.WriteLine("inside fn call " + bb);
        }
    }
}
