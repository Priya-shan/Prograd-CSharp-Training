using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class Generic<T>    {
        public Generic(T message) {
            Console.WriteLine(message);
        }
        public static void Main(string[] args)
        {
            Generic<int> g=new Generic<int>(1);
        }
    }
}
