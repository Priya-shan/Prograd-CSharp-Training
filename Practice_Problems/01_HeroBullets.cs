//Problem-1
/* In a game there is a hero and a villian .Both of them shoots
using gun hero shots the villian each time shots only one bullet is fired
but when villian shots he shots thrice the hero display the bullets shots*/

namespace Practice_Problems
{
    internal class HeroBullets
    {
        static void Hero_Bullets() { 
            //Hero-Villian Program

            Console.WriteLine("Welcome to BattleGround !!!!");
            Console.WriteLine("Enter No.of.Bullets to be provides to Hero");
            int bullets_for_hero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter No.of.Bullets to be provides to Villain");
            int bullets_for_villain = Convert.ToInt32(Console.ReadLine()); ;
            int heroShoot = 0;
            int VillainShoot = 0;
            int i = 1;
            while (bullets_for_hero > 0 && bullets_for_villain>2)
            {
                Console.WriteLine("Round Number - " + i);
                if (bullets_for_hero >= 1)
                {
                    heroShoot = heroShoot + 1;
                    bullets_for_hero = bullets_for_hero - 1;
                }
                if (bullets_for_villain >= 3)
                {
                    VillainShoot = VillainShoot + 3;
                    bullets_for_villain = bullets_for_villain - 3;
                }
                i++;
                Console.WriteLine("player           Score           RemainingBullets");
                Console.WriteLine("Hero                 "+heroShoot+"                   "+bullets_for_hero);
                Console.WriteLine("Hero                 "+VillainShoot+"                   "+bullets_for_villain);

                Console.WriteLine("-------------------------------------------------------");
            }
            if(bullets_for_hero > bullets_for_villain)
            {
                Console.WriteLine("Hero Wins...!");
            }
            else
            {
                Console.WriteLine("Villain Wins...!");
            }
        }
    }
}