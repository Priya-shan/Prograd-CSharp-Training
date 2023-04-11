using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class _19_Generate_Paranthesis
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Number : ");
            int number=Convert.ToInt32(Console.ReadLine());
            List<string> result=new List<string>();
            _19_Generate_Paranthesis obj=new _19_Generate_Paranthesis();
            string temp = "";
            obj.Generate(result, number, number,temp);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
        }
        public void Generate(List<string> result,int open,int close,string temp)
        {
            if(open == 0 && close == 0)
            {
                result.Add(temp);
                temp = "";
                return;
            }
            if(open>0)
            {
                Generate(result, open-1, close, temp+"(");
            }
            if (open != close)
            {
                Generate(result, open, close-1, temp + ")");
            }
            
        }
    }
}
