using System;
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
        //if main method is here itself then call a delegate by
        /*
         addition_Delegate ad = addition;
         ad+=subraction;
         ad(5,6);
         */
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
