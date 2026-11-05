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
                    player.CreatePlayer(input);
                    isValidName = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Error]: {e.Message} Please try again.");
                }
            }

            Console.WriteLine($"\nGreetings {player.Name}, your jouney awaits...");
            player.ShowStats();
        }
    }
}
