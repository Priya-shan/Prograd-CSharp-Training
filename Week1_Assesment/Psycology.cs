using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_Assesment
{
    internal class Psycology
    {
        public static void psycology()
        {

            Console.WriteLine("Welcome to Sara's Psycology...!!");
            Console.WriteLine("Enter your Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your DOB");
            string dob = Console.ReadLine();
            Console.WriteLine("ENter you Zodiac Sign");
            string zodiac = Console.ReadLine();

            Console.WriteLine("Lets start with Questions");
            Console.WriteLine("Do you see yourself as a confident person.. if yes enter 1 or 0");
            int confident = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Do you see yourself as a honest person.. if yes enter 1 or 0");
            int honest = Convert.ToInt32(Console.ReadLine());

            int score = confident + honest;

            if (score == 2)
            {
                Console.WriteLine("Congrats..! You passed the Be a Mentalist Phase");
            }

           
        }
    }
}