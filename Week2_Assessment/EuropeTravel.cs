namespace Week2_Assessment
{
    /*
Travelling through Europe one needs to pay attention to how the license plate in the given country is 
displayed.When crossing the border you need to park on the shoulder,
unscrew the plate, re-group the characters according to
the local regulations, attach it back and proceed with the journey.

Create a solution that can format the dmv number
into a plate number with correct grouping.
The function input consists of string s and group length n.
 The output has to be upper case characters and digits.
The new groups are made from right to left and connected by -.
 The original order of the dmv number is preserved.

Examples
LicensePlate("5F3Z-2e-9-w", 4) ➞ "5F3Z-2E9W"

LicensePlate("2-5g-3-J", 2) ➞ "2-5G-3J"

LicensePlate("2-4A0r7-4k", 3) ➞ "24-A0R-74K"

LicensePlate("nlj-206-fv", 3) ➞ "NL-J20-6FV"
     */
    internal class EuropeTravel
    {
        public static void Main(string[] args)
        {
            //Getting User input
            Console.WriteLine("Enter Your Liscence Plate DMV Number");
            String DMV_Number = Console.ReadLine();
            Console.WriteLine("Enter the length acoording to which we have to Group");
            int group_length=Convert.ToInt32(Console.ReadLine());

            //Removing Dashes from DMV_Number
            DMV_Number = removeDashes(DMV_Number);

            //Generating LicensePlate
            string LicensePlate = GenerateLicensePlate(DMV_Number, group_length);
            Console.WriteLine("Result :"+LicensePlate);

        }
        public static string removeDashes(String DMV_Number)
        {
            string[] arr = DMV_Number.Split("-");
            string result = "";
            foreach(String s in arr)
            {
                result += s;
            }
            return result;
        }
        public static string GenerateLicensePlate(String DMV_Number, int group_length)
        {
            string LicensePlate = "";
            int counter = 0;
            //looping thro string in backwards
            //change i
            for(int i= DMV_Number.Length - 1; i >= 0; i--)
            {
                if (counter == group_length)
                {
                    LicensePlate = "-"+ LicensePlate;
                    i++;
                    counter = 0;
                }
                else
                {
                    LicensePlate = DMV_Number[i] + LicensePlate;
                    counter++;
                }
            }
            
            return LicensePlate.ToUpper();
        }
    }
}