using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 An event is organized and the following has to happen. 


The chief guest needs to be picked up from the airport. 
The stage has to be decorated. 
The catering team needs to start preparing food
The transport team needs to drop the food raw materials to the venue before the cooking needs to start. 
The chief guest's speech needs to be reviewed by the PA
The venue needs to be checked for security features like bomb threat, etc
Prize distribution is set to happen at the end of the event so all the prizes that need to be presented 
should be brought to the venue. 
The chief guest needs to give the speech. 
Prizes need to be distributed. 
Food has to be provided to all participants. 

Please write a C# program to make use of the Async Programming concepts and write the program so that all of the above happen in a correct order.
 */
namespace Practice_Problems
{
    internal class ChiefGuest
    {
        public static void Main(string[] args)
        {
            Task pickupCG = EventMAnagement.pickUpChiefGuest();
            Task decorate = EventMAnagement.decorateStage();
            Task foodMaterial = EventMAnagement.dropRawFoodMaterial();
            Task reviewSpeech = EventMAnagement.reviewSpeech();
            Task venueCheck = EventMAnagement.venueCheck();
            Task bringPrizes = EventMAnagement.bringPrizes();

            Task.WaitAll(foodMaterial);
            Task prepareFood = EventMAnagement.prepareFood();

            Task.WaitAll(pickupCG, decorate, reviewSpeech, venueCheck);
            Task ChiefGuestSpeech = EventMAnagement.ChiefGuestSpeech();

            Task.WaitAll(bringPrizes,ChiefGuestSpeech);
            Task distributePrizes = EventMAnagement.distributePrizes();

            Task.WaitAll(prepareFood,ChiefGuestSpeech);
            Task distributeFood = EventMAnagement.distributeFood();


        }
        


    }
    public class EventMAnagement
    {
        public static async Task pickUpChiefGuest()
        {
            Console.WriteLine("Pickup CheifGuest Started");
            await Task.Delay(10000);
            Console.WriteLine("---Chief Guuest Arrived---");

        }
        public static async Task decorateStage()
        {
            Console.WriteLine("Decorate Stage Started");
            await Task.Delay(2000);
            Console.WriteLine("Decorate Stage Ended");

        }
        public static async Task dropRawFoodMaterial()
        {
            Console.WriteLine("Droping Raw Food Started");
            await Task.Delay(3000);
            Console.WriteLine("Delivered all Raw Foods");

        }
        public static async Task prepareFood()
        {
            Console.WriteLine("Prepare Food Started");
            await Task.Delay(8000);
            Console.WriteLine("Prepare Food Ended");

        }

        public static async Task reviewSpeech()
        {
            Console.WriteLine("Review Speech Started");
            await Task.Delay(3000);
            Console.WriteLine("Review Speech Ended");

        }

        public static async Task venueCheck()
        {
            Console.WriteLine("CHecking venue Started");
            await Task.Delay(5000);
            Console.WriteLine("CHecking venue Ended");

        }
        public static async Task bringPrizes()
        {
            Console.WriteLine("Bring Prizes Started");
            await Task.Delay(10000);
            Console.WriteLine("Bring Prizes Ended");

        }
        public static async Task ChiefGuestSpeech()
        {
            Console.WriteLine("ChiefGuest Speech Started");
            await Task.Delay(15000);
            Console.WriteLine("ChiefGuest Speech Ended");


        }
        public static async Task distributePrizes()
        {
            Console.WriteLine("Prize distribution Started");
            await Task.Delay(2000);
            Console.WriteLine("Prize distribution Ended");

        }
        public static async Task distributeFood()
        {
            Console.WriteLine("FOod distribution Started");
            await Task.Delay(3000);
            Console.WriteLine("Food distribution Ended");

        }
    }
}
