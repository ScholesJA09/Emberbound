using System;
using System.Threading;

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
                    player = new Player(input, 25, 5, 5, 5, 0, "Leather Tunic", "Rusty Dagger", "Wooden Shield", "Leather Boots", "None", 1);
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
            Enemy goblin = new Enemy("Goblin", 10, 5, 2, 3);

            BattleSystem battle = new BattleSystem();

            battle.SetUpBattle(player, goblin);
        }
    }
}
