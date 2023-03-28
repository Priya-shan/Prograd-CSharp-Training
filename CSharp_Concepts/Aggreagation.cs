using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Concepts
{
    internal class Aggreagation
    {
    }
    public class student
    {
        public int id;
        public string name;
        public int age;
        marks m;
        public student(string name, int id,int age,marks m) { 
            this.name = name;
            this.id = id;
            this.age = age;
            this.m = m;
        }
        public void display()
        {
            Console.WriteLine(name+" "+id+" "+age+" "+m.total_marks+" ");
            m.calculate_percentage();
        }

    }
    public class marks
    {
        public int total_marks;
        float percentage;
        string grade;
        public int no_of_subj;
        public marks(int total_marks,int no_of_subj)
        {
            this.total_marks = total_marks;
            this.no_of_subj = no_of_subj;
        }
        public void calculate_percentage()
        {
            percentage = total_marks / no_of_subj;
            Console.WriteLine(percentage);      
        }
    }
}
