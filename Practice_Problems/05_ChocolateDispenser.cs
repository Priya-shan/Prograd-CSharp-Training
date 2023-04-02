using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class ChocolateDispenser
    {
        public static Stack<string> chocolate_dispenser = new Stack<string>();
        public static void Main(string[] args)
        {
            chocolate_dispenser.Push("green");
            chocolate_dispenser.Push("pink");
            chocolate_dispenser.Push("silver");
            chocolate_dispenser.Push("pink");
            chocolate_dispenser.Push("silver");
            chocolate_dispenser.Push("purple");
            chocolate_dispenser.Push("pink");
            chocolate_dispenser.Push("silver");
            chocolate_dispenser.Push("blue");
            chocolate_dispenser.Push("crimson");
            chocolate_dispenser.Push("crimson");
            chocolate_dispenser.Push("crimson");
            chocolate_dispenser.Push("crimson");
            chocolate_dispenser.Push("crimson");
            chocolate_dispenser.Push("purple");
            chocolate_dispenser.Push("red");
            chocolate_dispenser.Push("purple");
            chocolate_dispenser.Push("pink");

            display_dispenser();
            int opt;
            do
            {
                Console.WriteLine("\nWelcome to Cait's Automatic Chocolate Dispenser..!!" +
                "\n Press 1 to Add Chocolates" +
                "\n Press 2 to Remove Chocolates from Top" +
                "\n Press 3 to Dispense Chocolates from Bottom" +
                "\n Press 4 to Dispense Chocolates of Favorite Color" +
                "\n Press 5 to get no_of_chocolates in the Dispenser" +
                "\n Press 6 to Sort Chocolates" +
                "\n Press 7 to Change Chocolate Color" +
                "\n Press 8 to change Chocolate color of all 'X' " +
                "\n Press 9 to Fresh Pick Chocolates of Color" +
                "\n Press 10 to Dispense Rainbow Chocolates");
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Okkayyy..!! Adding Chocolates...!");
                        Console.WriteLine("Eneter the Color and Number of chocolates to be added");
                        Console.Write("Color : ");
                        string color= Console.ReadLine();
                        Console.Write("Count : ");
                        int count=Convert.ToInt32(Console.ReadLine());
                        addChocolates(color,count);
                        break;
                    case 2:
                        Console.WriteLine("Okkayyy..!! Removing Chocolates...!");
                        Console.Write("Eneter the Number of chocolates to be removed : ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        string[] result=removeChocolates(number);
                        Console.Write("Removed Array of Chocolates : ");
                        foreach (string s in result)
                        {
                            Console.Write(s + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Okkayyy..!! Dispensing Chocolates...!");
                        Console.Write("Eneter the Number of chocolates to be dispensed from the Bottom : ");
                        number = Convert.ToInt32(Console.ReadLine());
                        result = dispenseChocolates(number);
                        Console.Write("Dispensed Array of Chocolates : ");
                        foreach (string s in result)
                        {
                            Console.Write(s + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Okkayyy..!! Dispensing Chocolates of Favourite Color...!");
                        Console.Write("Eneter the Number of chocolates to be dispensed from the Bottom : ");
                        number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter your favorite color : ");
                        color = Console.ReadLine();
                        result = dispenseChocolatesOfColor(number,color);
                        Console.Write("Dispensed Array of Chocolates : ");
                        foreach (string s in result)
                        {
                            Console.Write(s + " ");
                        }
                        Console.WriteLine();
                        display_dispenser();
                        break;
                    case 5:
                        Console.WriteLine("Okkayyy..!! I am giving you the count of each chocolate");
                        noOfChocolates();
                        break;
                    case 6:
                        Console.WriteLine("Okkayyy..!! Sorting in Descending order");
                        sortChocolateBasedOnCount();
                        break;


                    default:
                        Console.WriteLine("default");
                        break;
                }
            } while (opt != 0);
            
            


            

        }
        public static void display_dispenser()
        {
            Stack<string> temp=new Stack<string>();
            
            while (chocolate_dispenser.Count != 0)
            {
                temp.Push(chocolate_dispenser.Peek());
                Console.WriteLine(chocolate_dispenser.Pop());
            }
            while (temp.Count != 0)
            {
                chocolate_dispenser.Push(temp.Pop());
            }

        }
        //Trail 1
        public static void addChocolates(string color, int count)
        {
           while(count > 0)
            {
                chocolate_dispenser.Push(color);
                count--;
            }
        }
        //Trail 2
        public static string[] removeChocolates(int no_to_be_removed)
        {
            int idx = 0;
            int count = 0;
            string[] removed_chocolaetes = new string[no_to_be_removed];
            while (chocolate_dispenser.Count!=0)
            {
                if (no_to_be_removed==0)
                {
                    return removed_chocolaetes;
                }
                removed_chocolaetes[idx]=chocolate_dispenser.Pop();
                idx++;
                no_to_be_removed--;
            }
            return removed_chocolaetes;


        }
        //Trail 3
        public static string[] dispenseChocolates(int no_to_be_dispensed)
        {
            Stack<string> temp = new Stack<string>();
            string[] dispensed_chocolaetes = new string[no_to_be_dispensed];
            int idx = 0;

            while (chocolate_dispenser.Count != 0)
            {
                temp.Push(chocolate_dispenser.Pop());
            }
            while (temp.Count != 0)
            {
                if (no_to_be_dispensed == 0)
                {
                    while (temp.Count != 0)
                    {
                        chocolate_dispenser.Push(temp.Pop());
                    }

                    //Console.WriteLine("display dispeneer");
                    //display_dispenser();
                    return dispensed_chocolaetes;
                }
                dispensed_chocolaetes[idx] = temp.Pop();
                idx++;
                no_to_be_dispensed--;
            }
            while (temp.Count != 0)
            {
                chocolate_dispenser.Push(temp.Pop());
            }
            return dispensed_chocolaetes;
        }

        //Trail 4
        public static string[] dispenseChocolatesOfColor(int no_to_be_dispensed, string req_color)
        {
            Stack<string> temp = new Stack<string>();
            string[] dispensed_chocos_byColor = new string[no_to_be_dispensed];
            int idx = 0;
            Console.WriteLine("enteerd fn");
            while (chocolate_dispenser.Count != 0)
            {
                Console.WriteLine("enteerd 1st while");
                temp.Push(chocolate_dispenser.Pop());
            }
            while (temp.Count != 0)
            {
                Console.WriteLine("enteerd main while");
                string el = temp.Peek();
                Console.WriteLine(el);
                if (el.Equals(req_color) && no_to_be_dispensed!=0)
                {
                    Console.WriteLine("enteerd equals condn");
                    dispensed_chocos_byColor[idx] = temp.Pop();
                    idx++;
                    no_to_be_dispensed--;
                }
                else
                {
                    chocolate_dispenser.Push(temp.Pop());
                }
                
            }
            while (temp.Count != 0)
            {
                chocolate_dispenser.Push(temp.Pop());
            }
            return dispensed_chocos_byColor;
        }

        //Trail 5
        public static void noOfChocolates()
        {
            Dictionary<string,int> dict = new Dictionary<string,int>();
            int count = 0;
            while (chocolate_dispenser.Count != 0)
            {
                string el = chocolate_dispenser.Pop();
                    count = dict.GetValueOrDefault(el, 0);
                    if (dict.TryGetValue(el, out int currentAmount))
                    {
                        dict[el] = count + 1; //updating the dictionary value
                    }
                    else
                    {
                        dict.Add(el, 1); //adding a key value pair in dictionary
                    }
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

        }
        
        //Trial 6
        public static void sortChocolateBasedOnCount()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int count = 0;
            while (chocolate_dispenser.Count != 0)
            {
                string el = chocolate_dispenser.Pop();
                count = dict.GetValueOrDefault(el, 0);
                if (dict.TryGetValue(el, out int currentAmount))
                {
                    dict[el] = count + 1; //updating the dictionary value
                }
                else
                {
                    dict.Add(el, 1); //adding a key value pair in dictionary
                }
            }
            foreach (var key_value in dict.OrderByDescending(x => x.Value).ToList())
            {
                Console.WriteLine(key_value);
            }
        }

        //    //Trial 7
        //    public static void changeChocolateColor(int number, string color, string finalColor)
        //    {

        //    }
    }

}


/*
     
            public class chocolates
    {

        public string color;
        public int count;

        public chocolates(string color,int count)
        {
            this.count = count;
            this.color = color;
        }
    }

foreach (chocolates item in dispenser_)
            {

                Console.WriteLine(item.color);
                Console.WriteLine(item.count);
            }
 */