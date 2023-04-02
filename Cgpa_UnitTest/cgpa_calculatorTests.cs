using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp_Concepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts.Tests
{
    [TestClass()]
    public class cgpa_calculatorTests
    {
        [TestMethod()]
        public void MainTest()
        {
            int subject_count = 3;
            List<int> marks = new List<int>() { 90, 98, 96 };
            string grade=cgpa_calculator.calculate(subject_count, marks);
            if (grade=="O")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }
            
        }
        [TestMethod()]
        public void TestCase2()
        {
            int subject_count = 3;
            List<int> marks = new List<int>() { 10, 28, 26 };
            string grade = cgpa_calculator.calculate(subject_count, marks);
            if (grade == "O")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestMethod()]
        public void TestCase3()
        {
            int subject_count = 3;
            List<int> marks = new List<int>() { 100, 100, 100 };
            string grade = cgpa_calculator.calculate(subject_count, marks);
            if (grade == "O")
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}