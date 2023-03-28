using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    public class AccessSpecifiers
    {
        protected void display()
        {
            //calling nested class's method
            //var obj1 = new class2.testclass();
            Console.WriteLine("This is a deiplay method from class1");
        }
        
        protected internal class testclass
        {
            protected internal void display1()
            {
                Console.WriteLine("This is a deiplay1 method inside class1 called testclass");
            }
        }
    }
}
