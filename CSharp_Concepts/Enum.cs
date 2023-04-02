using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class Enums
    {
        public enum days { mon,tue,wed,thu,fri,sat,sun};
        public static void Main(string[] args)
        {
            int a = (int)days.mon;
            Console.WriteLine(a);

            foreach (string i in Enum.GetNames(typeof(days)))
            {
                Console.WriteLine(i);
            }
        }
    }
}
