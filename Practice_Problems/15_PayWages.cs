using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
 Working 9 to 5
Write a function that calculates overtime and pay associated with overtime.

Working 9 to 5: regular hours
After 5pm is overtime
Your function gets an array with 4 values:

Start of working day, in decimal format, (24-hour day notation)
End of working day. (Same format)
Hourly rate
Overtime multiplier
Your function should spit out:

$ + earned that day (rounded to the nearest hundreth)
Examples
OverTime([9, 17, 30, 1.5]) ➞ "$240.00"

OverTime([16, 18, 30, 1.8]) ➞ "$84.00"

OverTime([13.25, 15, 30, 1.5]) ➞ "$52.50"
2nd example explained:

From 16 to 17 is regular, so 1 * 30 = 30
From 17 to 18 is overtime, so 1 * 30 * 1.8 = 54
30 + 54 = $84.00
 */
namespace Practice_Problems
{
    public class PayWages
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Start of Working Day");
            decimal start=decimal.Parse(Console.ReadLine());  

            Console.WriteLine("Enter End of Working Day");
            decimal end = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Hourly Wages");
            int rate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Overtime Multiplier");
            decimal multiplier = decimal.Parse(Console.ReadLine()); ;

            decimal wages=calculateOverTime(start,end,rate,multiplier);
            Console.WriteLine(wages);

        }
        public static decimal calculateOverTime(decimal start, decimal end,int rate, decimal multiplier)
        {
            decimal no_of_hours_normaltime;
            decimal no_of_hours_overtime;
            decimal wages=0;
            if (end <= 17)
            {
                no_of_hours_normaltime = end - start;
                no_of_hours_overtime = 0;
            }
            else
            {
                no_of_hours_normaltime = 17 - start;
                no_of_hours_overtime = end - 17;
            }
            wages += no_of_hours_normaltime * rate;
            wages += no_of_hours_overtime * (rate*multiplier);

            return wages;
        }
    }
}
