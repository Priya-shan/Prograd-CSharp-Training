using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    //declaring a delegate
    delegate int addition_Delegate(int a, int b);
    internal class delegatesExample
    {
        //if main method is here itself then call a delegate by (not static methiod)
        /*
         addition_Delegate ad = addition;
         ad+=subraction;
         ad(5,6);
         */
        public int num = 100;
        public static void Main(string[] args)
        {
            //we need an object if methid is static
            delegatesExample obj = new delegatesExample();
            addition_Delegate ad = obj.addition;
            ad += obj.subraction;
            ad(5, 6);

            //Action Type builtin delegate (when we want to )
            Action<string> consolingDelegate =(msg)=>Console.WriteLine("From Builtin Delegate "+ msg);
            consolingDelegate("priya");

            //Func readymade delegate (when u want to return any type inclusing bool)
            Func<int, int,string, int> fk = (a, b,s) => { 
                Console.WriteLine(s);
                int c = a + b;
                return c; };
            Console.WriteLine(fk(10, 10,"hello"));


            delegatesExample obj1 = new delegatesExample();
            Func<delegatesExample,int> fk1 = (o) => {
                int a=o.num = 200;
                return a;
            };
            Console.WriteLine(fk(10, 10, "hello"));
            Console.WriteLine(fk1(obj1));


            //Predicate (when we need bool return type)
            Predicate<int> pd = (a) => { return a > 5; };
            Console.WriteLine(pd(10));

            List<int> lst = new List<int>() { 10,2,30,40};

            //Predicate<List<int>> al = (a) => { return a > 5; };
            //Console.WriteLine(lst.All(al));

            Predicate<List<int>> checkifGreaterThanFive = (list) => list.All((a) => a > 5);

            Console.WriteLine(checkifGreaterThanFive.Invoke(lst));

        }
        public int addition(int a,int b)
        {
            //Console.WriteLine(a + b);
           return a+ b;
        }

        public int subraction(int a,int b)
        {
            //Console.WriteLine(a - b);
            return a - b;
        }
    }
}
