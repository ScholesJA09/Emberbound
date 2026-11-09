using System;

namespace Emberbound
{
    class Emberbound
    {
        static void Main()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          WELCOME TO EMBERBOUND         ");
            Console.WriteLine("========================================");

            Player player = new Player();
            bool isValidName = false;

            //Loop until user gives valid name
            while (!isValidName)
            {
                Console.Write("Enter your name, traveler: ");
                string input = Console.ReadLine();

                try
                {
                    player = new Player(input, 25, 5, 5, 5, 0, "Leather Tunic", "Rusty Dagger", "Wooden Shield", "Leather Boots", "None", 1);
                    isValidName = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Error]: {e.Message} Please try again.");
                }
            }

            Console.WriteLine($"\nGreetings {player.Name}, your jouney awaits...");

            //Temperary showing stats
            player.ShowStats();

            //Temporary battle
            Enemy goblin = new Enemy("Goblin", 10, 3, 2, 3);

            BattleSystem battle = new BattleSystem();

            battle.SetUpBattle(player, goblin);
        }
    }
}
