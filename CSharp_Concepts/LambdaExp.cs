using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    delegate int DelegateForLambda(int a, int b);
    delegate void DelegateForGreet();
    internal class LambdaExp
    {
        public void testingLambda()
        {
            DelegateForLambda dl = (num1, num2) => num1 + num2;
            Console.WriteLine(dl.Invoke(20, 30));

            DelegateForGreet dg = () => Console.WriteLine("Hello World !");
            dg.Invoke();

            var mul = (int a, int b) => a * b;

            Console.WriteLine(mul(5, 10));

            Console.WriteLine("-----------------------------");
            //combining lambda funtions without delegate and using delegate
            var add = (int a, int b) => a + b;
            var sub = (int a, int b) => a - b;
            var div = (int a, int b) => a / b;
            mul += add;
            mul += sub;
            mul += div;
            Console.WriteLine("not using delgate so only last added will be implemented" + mul(10, 10));
            //to implement all the fn we need to use Delengate class and GetInvocationList method
            foreach (Delegate a in mul.GetInvocationList())
            {
                Console.WriteLine(a.DynamicInvoke(10, 10));
            }
            Console.WriteLine("-----------------------------");
            //lambda fn without delegate
            ArrayList list = new ArrayList() { 1, 2, 3, 4, 5, 6, 7 };
            var square = (int x) => { return x * x; };

            foreach (int i in list)
            {
                Console.WriteLine(square(i));
            }



            //lambda fn to find all numbers divisible bu5 in list
            List<int> list1 = new List<int>() { 1, 2, 10, 15, 3, 4, 5, 6, 7, 25 };
            List<int> divisibleBy5 = list1.FindAll(n => n % 5 == 0);
            foreach (var i in divisibleBy5)
            {
                Console.WriteLine(i);
            }

            //lambda fn to find strings with letteer a
            List<string> S1 = new List<string>() { "abc", "dfg", "asd", "qwe" };

            List<string> ContainsA = S1.FindAll(s => s.Contains("a"));

            foreach (string s in ContainsA)
            {
                Console.WriteLine(s);
            }

            //lambda fun to sort list using order by

            List<string> sortedList = S1.OrderBy(s => s).ToList();

            foreach (string s in sortedList)
            {
                Console.WriteLine(s);
            }

            //lambda fn to get key from keyvalue pair and add it to list 

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict["a"] = 1;
            dict["c"] = 2;
            dict["b"] = 3;
            dict["d"] = 4;
            //sorting in ascending order based on value
            foreach (var key_value in dict.OrderBy(x => x.Value).ToList())
            {
                Console.WriteLine(key_value);
            }
            //sorting in descending order based on value
            foreach (var key_value in dict.OrderBy(x => x.Value * -1).ToList())
            {
                Console.WriteLine(key_value);
            }
            //sorting in ascending order based on key
            foreach (var key_value in dict.OrderBy(x => x.Key).ToList())
            {
                Console.WriteLine(key_value);
            }
            //sorting in descending order based on key
            foreach (var key_value in dict.OrderByDescending(x => x.Key).ToList())
            {
                Console.WriteLine(key_value);
            }
            Console.WriteLine("************************************");
            List<user> lst = new List<user>();
            lst.Add(new user() { name = "priya", id = 10, dept = "CSE", age = 21, place = "madurai" });
            lst.Add(new user() { name = "ashwin", id = 20, dept = "ece", age = 22, place = "madurai" });
            lst.Add(new user() { name = "sneha", id = 30, dept = "IT", age = 13, place = "mumbai" });
            lst.Add(new user() { name = "hema", id = 40, dept = "CSE", age = 35, place = "chennai" });
            lst.Add(new user() { name = "murugan", id = 50, dept = "mech", age = 38, place = "coimbatore" });
            printing the list
            foreach (var v in lst)
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }
            //sort list by age in descending order
            List<user> sorted_List = lst.OrderByDescending(x => x.age).ToList();
            foreach (var v in sorted_List)
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }
            //filter age == 22
            List<user> age_22 = lst.FindAll(s => s.age == 22).ToList();
            foreach (var v in age_22)
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }
            //sort by age in ascending using sort function
            lst.Sort((s1, s2) => s1.age.CompareTo(s2.age));
            foreach (var v in lst)
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }
            filetring out with 2 criteria age > 20 and dept = cse
            adding 1 to id in all objects
            lst.ForEach(s => s.id += 1);
            sorting list without compareTo funtion
            lst.Sort((s1, s2) => s1.age - s2.age);
            foreach (var v in lst)
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }
            foreach (var v in lst.FindAll(v => v.dept.Equals("CSE") && v.age >= 20))
            {
                Console.WriteLine(v.name + " " + v.id + " " + v.dept + " " + v.age + " " + v.place);
            }

            statement lambda -bigger expresion
            var result = (int x, int y) =>
            {
                int total = x + y;
                return total;
            };
            Console.WriteLine(result(5, 5));

            //func is called as a readymade delegate
            Func<int,int,int> fk = (a, b) => { return a + b; };
            Console.WriteLine(fk(10,10));

        }

    }
    public class user
    {
        public string name { get; set; }
        public int id { get; set; }
        public string dept { get; set; }
        public int age { get; set; }
        public string place { get; set; }

    }
}
