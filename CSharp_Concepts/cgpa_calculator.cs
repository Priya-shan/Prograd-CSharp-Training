using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    public class cgpa_calculator
    {
        enum gradeEnum
        {
            O, A, B, C, D, F
        }
        public static void Main()
        {
            int subject_count = Convert.ToInt32(Console.ReadLine());
            List<int> marks = new List<int>();
            for (int i = 0; i < subject_count; i++)
            {
                marks.Add(Convert.ToInt32(Console.ReadLine()));
            }
            calculate(subject_count,marks);
        }
        public static string calculate(int subject_count, List<int> marks)
        {
            
            float total = marks.Sum();
            Console.WriteLine("total :"+total);
            float avg = total / subject_count;
            Console.WriteLine("avg :"+avg);
            float cgpa = avg / 10.0f;
            return assignGrade(cgpa);
        }
       
        public static string assignGrade(float cgpa)
        {
            string grade;
            Console.WriteLine("Cgpa :"+cgpa);
            if (cgpa > 9f)
            {
                grade=gradeEnum.O.ToString();
            }
            else if(cgpa > 8f)
            {
                grade = gradeEnum.A.ToString();
            }
            else if (cgpa > 7f)
            {
                grade = gradeEnum.B.ToString();
            }
            else
            {
                grade = gradeEnum.F.ToString();
            }
            Console.WriteLine("Grade :" + grade);
            return grade;
        }
    }
}
