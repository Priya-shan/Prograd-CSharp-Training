using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class AsyncProgramming
    {
        static async Task Main(string[] args)
        {
            /* Example 1 */

            Console.WriteLine("in here");
            Task t1 = AsyncWaitAll.a();
            Task t2 = AsyncWaitAll.b();
            Task.WaitAll(t1, t2);
            AsyncWaitAll.c();
            Console.ReadKey();

            Console.WriteLine("**********************************");

            /* Example 2 */

            Async2 obj = new Async2();
            var task1 = obj.a();
            var task2 = obj.b();
            int number = await task1;
            var task3 = obj.c(number);
            Console.ReadKey();

            Console.WriteLine("**********************************");

            /* Example 3 */

            Async obj2 = new Async();
            obj2.a();
            obj2.c();
            Console.ReadKey();
        }

    }
    public class AsyncWaitAll
    {
        public static async Task a()
        {
            Console.WriteLine("Start A");
            await Task.Delay(3000);
            Console.WriteLine("End A");
        }

        public static async Task b()
        {
            Console.WriteLine("Start B");
            await Task.Delay(1000);
            Console.WriteLine("End B");
        }

        public static void c()
        {
            Console.WriteLine("In C");
        }
    }

    public class Async2
    {
        public async Task<int> a()
        {
            int number = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Executing method(a)");
                    number++;
                }
            });

            Console.WriteLine("In a");
            // await Task.Delay(3000);
            Console.WriteLine("End a");
            return number;
        }

        public async Task b()
        {
            Console.WriteLine("In b");
            // await Task.Delay(5000);
            Console.WriteLine("End b");
        }

        public async Task c(int number)
        {
            Console.WriteLine("Number from method(A): " + number);
            Console.WriteLine("In c");
            await Task.Delay(5000);
            Console.WriteLine("End c");
        }


        
    }

    public class Async
    {
        public async void a()
        {
            Console.WriteLine("In A");
            Console.WriteLine(await new Async().b());
            Console.WriteLine("Ended A");
        }

        public async Task<string> b()
        {
            Console.WriteLine("In b");
            await Task.Delay(3000);
            Console.WriteLine("End b");
            return "from b to a";
        }

        public void c()
        {
            Console.WriteLine("in c");
        }
    }

}
