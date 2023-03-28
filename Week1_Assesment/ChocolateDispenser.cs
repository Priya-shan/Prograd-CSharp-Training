using System.Collections;

namespace Week1_Assesment
{
    internal class ChocolateDispenser
    {
        public static void Main(string[] args)
        {
            ArrayList dispenser_ = new ArrayList();
            //var dispenser_ = new Stack<int>();
            addChocolates("green", 10, dispenser_);
            addChocolates("red", 20, dispenser_);
            addChocolates("yello", 30, dispenser_);


            foreach (chocolates item in dispenser_)
            {

                Console.WriteLine(item.color);
                Console.WriteLine(item.count);
            }

        }
        //Trail 1
        public static void addChocolates(string color, int count, ArrayList dispenser_)
        {
            chocolates choco = new chocolates(color, count);
            dispenser_.Add(choco);
        }
        //Trail 2
        public static chocolates[] removeChocolates(int no_to_be_removed)
        {
            chocolates[] removed_chocos = new chocolates[no_to_be_removed];

            return removed_chocos;
        }
        //Trail 3
        public static chocolates[] dispenseChocolates(int no_of_chocos)
        {
            chocolates[] dispensed_chocos = new chocolates[no_of_chocos];

            return dispensed_chocos;
        }

        //Trail 4
        public static chocolates[] dispenseChocolatesOfColor(int no_of_chocos, string req_color)
        {
            chocolates[] dispensed_chocos_byColor = new chocolates[no_of_chocos];

            return dispensed_chocos_byColor;
        }

        //Trail 5
        public static int noOfChocolates()
        {
            int total_chocos = 0;

            return total_chocos;
        }
        //Trial 6
        public static void sortChocolateBasedOnCount(ArrayList dispenser_)
        {

        }

        //Trial 7
        public static void changeChocolateColor(int number, string color, string finalColor)
        {

        }
    }

    public class chocolates
    {

        public string color;
        public int count;

        public chocolates(string color, int count)
        {
            this.count = count;
            this.color = color;
        }
    }
}