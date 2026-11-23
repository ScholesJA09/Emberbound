using System;
using System.Threading;

//NOTES
//Instead of Spell Book, you have healing potions that heal you a certain amount
//3 at most, get more from shop (DONE)
//When stats go above a certain limit, you change clothing name (DONE)
//Shield to have 50% to stun enemy for next turn
//XP, gain a certain stat when level up.

namespace Emberbound
{
    class Emberbound
    {
        //Allow slow text output
        private static void TypeText(string text, int delayMilliseconds = 50)
        {
            foreach(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Console.WriteLine("========================================");
            TypeText("          WELCOME TO EMBERBOUND         ");
            Console.WriteLine("========================================");

            Player player = new Player();
            bool isValidName = false;

            //Loop until user gives valid name
            while (!isValidName)
            {
                TypeText("\nEnter your name, traveler: ");
                string input = Console.ReadLine();

                try
                {
                    player = new Player(input, 30, 5, 5, 5, 25, 0, "Leather Tunic", "Rusty Dagger", "Wooden Shield", "Leather Boots", 3, 1);
                    isValidName = true;
                }
                catch (Exception e)
                {
                    TypeText($"[Error]: {e.Message} Please try again.");
                }
            }

            TypeText($"\nGreetings {player.Name}, your jouney awaits...");

            //Temperary showing stats
            //player.ShowStats();

            //Temporary battle
            //Enemy goblin = new Enemy("Goblin", 10, 5, 2, 3, 10);

            //BattleSystem battle = new BattleSystem();

            //battle.SetUpBattle(player, goblin);

            //Create GameLoop
            GameLoop gameLoop = new GameLoop(player);

            //Start Game
            gameLoop.StartJourney();
        }
    }
}