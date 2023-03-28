using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems
{
    internal class ChocolateDispenser
    {
        public static Stack<string> chocolate_dispenser = new Stack<string>();
        public static void ChocolateDispenser_()
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
                Console.WriteLine("Welcome to Cait's Automatic Chocolate Dispenser..!!" +
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
                        //display_dispenser();
                        break;
                    case 2:
                        Console.WriteLine("Okkayyy..!! Removing Chocolates...!");
                        Console.Write("Eneter the Number of chocolates to be removed : ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        string[] result=removeChocolates(number);
                        foreach (string s in result)
                        {
                            Console.Write(s + " ");
                        }
                        display_dispenser();
                        break;

                    default:
                        Console.WriteLine("default");
                        break;
                }
            } while (opt != 0);
            
            


            

        }
        public static void display_dispenser()
        {
            while (chocolate_dispenser.Count != 0)
            {
                Console.WriteLine(chocolate_dispenser.Pop());
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
                if (count == 3)
                {
                    break;
                }
                removed_chocolaetes[idx++]=chocolate_dispenser.Pop();
                count++;
                no_to_be_removed--;
            }
            return removed_chocolaetes;
        }
        //    //Trail 3
        //    public static chocolates[] dispenseChocolates(int no_of_chocos)
        //    {
        //        chocolates[] dispensed_chocos = new chocolates[no_of_chocos];

        //        return dispensed_chocos;
        //    }

        //    //Trail 4
        //    public static chocolates[] dispenseChocolatesOfColor(int no_of_chocos, string req_color)
        //    {
        //        chocolates[] dispensed_chocos_byColor = new chocolates[no_of_chocos];

        //        return dispensed_chocos_byColor;
        //    }

        //    //Trail 5
        //    public static int noOfChocolates()
        //    {
        //        int total_chocos = 0;

        //        return total_chocos;
        //    }
        //    //Trial 6
        //    public static void sortChocolateBasedOnCount(ArrayList dispenser_)
        //    {

        //    }

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