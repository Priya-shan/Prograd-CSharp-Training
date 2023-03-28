using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    delegate int DelegateForMath(int a, int b);
    delegate void DelegateForPrint();
    internal class AnonymousFunction
    {
        public void testingAnonymousFn()
        {
            DelegateForMath dm = delegate (int a, int b) { int c = a + b; return c; };
            Console.WriteLine(dm(10, 16));

            DelegateForPrint print = delegate () { Console.WriteLine("Helloo World !"); };
            print.Invoke();
        }

    }
}
