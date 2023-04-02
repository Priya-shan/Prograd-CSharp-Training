using System.ComponentModel;
using System.Text;
using Oops;
namespace CSharp_Concepts
{
    internal class Main_Program
    {
       
        static void Main(string[] args)
        {
            //calling a method in another .cs file if its not static
            //HelloWorld.CS_basics obj = new CS_basics();
            //obj.basics();

            //calling a method in another .cs file if its static
            //HelloWorld.StringManipulation.string_manipulations();

            //HelloWorld.ArrayBasics.array_basics();

            //HelloWorld.ExceptionHandling.exception_handling();
            //HelloWorld.Generic<int>.generic_();

            //HelloWorld.Collections.collections_();

            //HelloWorld.Constructor.checking_constructor();

            //HelloWorld.Enums.testingEnum();

            //linked list

            //dictionary


            //access specifiers

            //var obj = new class2();
            //obj.display();

            //calling nested class
            //var obj1 = new class2.testclass();
            //obj1.display1();

            //Inheritence

            //var obj = new benz_sports();
            //obj.maxSpeed(20);
            //obj.ballon();
            //obj.test();

            //var m = new marks(400, 5);
            //var stud = new student("priya", 10,21,m);

            //stud.display();

            //file handling

            //write using filestream
            //FileStream file = new FileStream("C:\\Users\\HP\\Desktop\\SamplefIles\\text1.txt",
            //                                    FileMode.OpenOrCreate,
            //                                    FileAccess.ReadWrite);
            //string str = "hello i am priya";
            //byte[] byte_array = Encoding.UTF8.GetBytes(str);
            //file.Write(byte_array);
            //file.Close();

            //write using streamwriter
            //StreamWriter writer = new StreamWriter(file);
            //writer.WriteLine("this is ashwin");
            //writer.Close();
            //file.Close();
            //using file class
            //File.WriteAllText("C:\\Users\\HP\\Desktop\\SamplefIles\\text1.txt", "hello");

            //reading a file
            //StreamReader sr = new StreamReader(file);
            //Console.WriteLine(sr.ReadToEnd());
            //sr.Close();
            //file.Close();

            //trxt writer
            //string path = "C:\\Users\\HP\\Desktop\\SamplefIles\\info.txt";
            //using (TextWriter textWriter = File.CreateText(path))
            //{
            //    textWriter.WriteLine("hello thi is file handling class");
            //}
            //FileInfo fileInfo = new(path);
            //fileInfo.Create();

            //Delegates
            //CSharp_Concepts.delegatesExample obj = new delegatesExample();
            ////all the methods added to delegates should be of same return type
            //addition_Delegate ad = obj.addition;
            //ad += obj.subraction;

            //Console.WriteLine(ad(1, 2));

            ////if return type is not void only recently added will be executed so we have to use
            ////invocation list to stack it up and loop it one by one
            //Delegate[] list = ad.GetInvocationList();
            //foreach (Delegate d in list)
            //{
            //    Console.WriteLine(d.DynamicInvoke(1, 1));
            //}

            //Console.WriteLine("-------------------");
            ////removing a function from delegate
            //ad -= obj.subraction;
            //ad(1, 2);

            //Console.WriteLine(ad.Invoke(1, 2));


            //..anonymous fnk
            //CSharp_Concepts.AnonymousFunction obj = new AnonymousFunction();
            //obj.testingAnonymousFn();

            //lambda function
            //HelloWorld.LambdaExp obj = new LambdaExp();
            //obj.testingLambda();
        }
    }
}