//COnstructor, this keyword & static keyword are explained in here

namespace CSharp_Concepts
{
    internal class Constructor
    {
        public static void checking_constructor()
        {
            class1 obj = new class1();


            employee e1 = new employee(107,"priya");
            employee e2 = new employee(106, "sneha");

            e1.displayData();
            e2.displayData();
        }
        
    }
    public class class1
    {
        //default constructor
        //invoked automatically when object is created for this class
        public class1()
        {
            Console.WriteLine("Default Constructor is invoked");
        }

        //even if we dont call destructor garbage collectore automatically destroys objects
        ~class1()
        {
            Console.WriteLine("Object is being destroyed");
        }
    }

    public class employee
    {
        int roll;
        string name;
        public employee(int roll,string name)
        {
            Console.WriteLine("Parameterized Constructor is invoked");
            this.roll = roll;
            this.name = name;
        }
        public void displayData()
        {
            Console.WriteLine($"User Roll : {roll} , User Name : {name} ");
            this.show();
        }
        //to understand this keyword
        // this -> refers to current instance of the class 
        // it is used oonly if we have 2 variables with same name
        public void show()
        {
            Console.WriteLine("This methods is invoked using this.show() ");
        }
    }
}
