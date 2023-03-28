using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    public class Inheritance
    {
        public void maxSpeed(int speed)
        {
            int maximum_speed=speed;
            Console.WriteLine("speed is " + maximum_speed);
        }
        public void ballon()
        {
            Console.WriteLine("Ballon is present");
        }
    }
    public class benz : Inheritance
    {
        int speed = 40;
        public void test()
        {
            Console.WriteLine("Inside Benz class");
        }
        public void ballon()
        {
            Console.WriteLine("baloon is present in benz");
        }
    }
    public class benz_sports:benz
    {
        public void sport_capacity()
        {
            Console.WriteLine("its sport capacity is 200mh");
        }
        public void ballon()
        {
            Console.WriteLine("ballon is not present in benz sports model");
        }
    }
}
