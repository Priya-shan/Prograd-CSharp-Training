using Practice_Problems;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Abstraction:

A company XYZ wants to develop an app which can predict the lucky number for a person. The name of the app is 
LuckyNumberPredictor. This app consists of a method - upon calling the person gets to know his/her lucky number.
This method calls another class —> NumberPredictor - which have the formula for predicting the lucky number of that person. This approach is done so that no-one else gets
to know the secret formula for this prediction.
LuckyNumberPredictor accepts only one argument i.e: date of birth of the person. The formula for predicting the lucky 
number is quite simple -> a person’s lucky number is calculated by rounding off the date of birth to the nearest 
Fibonacci number.Another thought that XYZ company is  having - is to predict unlucky number as well - but for this — 
for now, they don’t have any formula ready. But they want to have this idea to be stored in - in their NumberPredictor 
class. The company is asking you to develop this system.

 */
namespace Practice_Problems
{
    internal class LuckyNumberPredictor
    {
        public static void Main(string[] args)
        {
            NumberPredictor obj=new ImplementingClass();
            Console.WriteLine("Enter Your Date of Birth in the format (dd/MM/yyyy): ");
            string userInput = Console.ReadLine();

            // Convert the string to a DateTime object using DateTime.ParseExact() method
            DateTime dateTime;
            DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
            int lucky_num = obj.luckyNumber(dateTime);
            Console.WriteLine("\nYour lucky_Number is :" + lucky_num);
        }
    }
    public abstract class NumberPredictor
    {
        public abstract int luckyNumber(DateTime dt);
        public abstract int unluckyNumber(DateTime dt);
    }

    public class ImplementingClass : NumberPredictor
    {
        public override int luckyNumber(DateTime dt)
        {
            string date_ = dt.Day.ToString();
            //Console.WriteLine(date_);
            int date =Convert.ToInt32(date_);
            //need to write fibonacci logic here
            int a = 0; int b = 1;
            int c = 0;
            int prev_num=0;
            int next_num=0;
            while (c <= date)
            {
                prev_num = c;
                c = a + b;
                a = b;
                b = c;
                //Console.Write(c + " ");
            }
            prev_num = a;
            next_num = c;
            int lucky_num = date - prev_num > next_num - date ? next_num : prev_num;
            
            return lucky_num;
        }
        public override int unluckyNumber(DateTime dt)
        {
            throw new NotImplementedException();
        }
    }
}











