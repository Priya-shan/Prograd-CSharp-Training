using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class Dictionary
    {
        public static void dictionary_()
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(1, "priya");
            d.Add(2, "shan");
            d.Add(3, "sneha");
            d.Add(4, "hema");
            d.Add(5, "murugan");
            d.Add(6, "ashwin");
            d.Add(7, "");

            foreach (KeyValuePair<int, string> kvp in d)

            {
                if (kvp.Value.Equals("shan"))
                {
                    d[kvp.Key] = "SHAN";

                }
            }

            foreach (KeyValuePair<int, string> kvp in d)

            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
        }
    }
}
