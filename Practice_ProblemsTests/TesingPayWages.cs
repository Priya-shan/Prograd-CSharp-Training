using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_ProblemsTests
{
    [TestClass()]
    public class TesingPayWages
    {
            [TestMethod()]
            public void Testing_CalculateWages()
            {
            Console.WriteLine("Enter Start of Working Day");
            decimal start = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter End of Working Day");
            decimal end = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Hourly Wages");
            int rate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Overtime Multiplier");
            decimal multiplier = decimal.Parse(Console.ReadLine());

            decimal wages = PayWages.calculateOverTime(start, end, rate, multiplier);
            if(wages == 20) {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
            }
            
    }
}
