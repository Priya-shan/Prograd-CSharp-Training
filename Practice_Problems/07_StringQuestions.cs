using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class exchange
    {
        public static void Main(string[] args)
        {
            Console.Write("enter string : ");
            String str = Console.ReadLine();
            int n=str.Length;

            /*Write a C# Sharp program to exchange the first and last characters in a given
            string and return the new string*/
            exchangeCharacter(str, n);
            
            /*Write a C# Sharp program to create a new string with the last char added at the
            front and back of a given string of length 1 or more.*/
            AddLastCharFront(str,n);
           
            //Write a C# Sharp program to check if a string 'ok' appears in a given
            //string. If it appears return a string without 'ok' 
            removeOK(str);

            
        }

        public static void exchangeCharacter(string str,int n)
        {
            string result;
            result = str[n - 1] + "" + str.Substring(1, n - 2) + "" + str[0];
            Console.WriteLine(result);
        }

        public static void AddLastCharFront(string str,int n)
        {
            string result1 = str[n - 1] + "" + str.Substring(0, n) + "" + str[n - 1];
            Console.WriteLine(result1);
        }

        public static void removeOK(string str)
        {
            //using builtin funtion

            //while (str.Contains("ok"))
            //{
            //    str = str.Replace("ok", "");
            //}

            // without builtin function 
            string result3 = "";
            while (str.Contains("ok"))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == 'o' && str[i + 1] == 'k')
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        result3 += str[i];
                    }
                }
                str = result3;
                result3 = "";
            }

            Console.WriteLine(str);
        }

    }
}
