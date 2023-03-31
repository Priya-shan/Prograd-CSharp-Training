using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_Assessment
{
/*
You have to get a new driver's license. You show up at the office at the same time as four other people.
The office says they will see everyone in alphabetical order and it takes 20 minutes for them to process each new license.
All of the agents are available now, and they can each see one customer at a time. How long will it take for you to walk 
out with your new license?
Your input will be a string of your name me, an integer of the number of available agents, and a string of the other four 
names separated by spaces others.
Return the number of minutes it will take to get your license.
Examples
License("Eric", 2, "Adam Caroline Rebecca Frank") ➞ 40
// As you are in the second group of people.

License("Zebediah", 1, "Bob Jim Becky Pat") ➞ 100
// As you are the last person.

License("Aaron", 3, "Jane Max Olivia Sam") ➞ 20
// As you are the first.
*/
    internal class DriversLicense
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name=Console.ReadLine();
            Console.WriteLine("ENter number of Agents");
            int no_of_agents=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENter other customers name with space separated");
            string customers = Console.ReadLine();

            string[] otherPeoples = customers.Split(" ");

            //finding eligible peoples i.e, peoples before me in alphabetical order 
            ArrayList eligiblePeoples=new ArrayList();
            foreach (string s in otherPeoples)
            {
                if((int)s[0] < (int)name[0])
                {
                    eligiblePeoples.Add(s);
                }
            }
            //Calculating the Wait time
            int count_of_eligible = eligiblePeoples.Count;
            int result = (count_of_eligible / no_of_agents)*20;
            result = result + 20;
            Console.WriteLine("Time Taken :"+result);
        }
    }
}
