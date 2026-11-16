using System;
using System.Threading;

namespace Emberbound
{
    public class GameLoop
    {
        private Player player;
        private BattleSystem battleSystem;
        private const int totalAreas = 3;
        private const int encountersPerArea = 5;

        public GameLoop(Player playerInstance)
        {
            player = playerInstance;
            battleSystem = new BattleSystem();
        }

        //Allow slow text output
        private static void TypeText(string text, int delayMilliseconds = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }
            Console.WriteLine();
        }

        public void StartJourney()
        {
            //Loop for total amount of areas
            for (int i = 1; i <= totalAreas; i++)
            {
                player.CurrentArea = i;
                //Announce area name
                AnnounceArea(i);

                //Number of encounters per area
                for (int j = 1; j <= encountersPerArea; j++)
                {
                    //Determine if boss enemy or not
                    Enemy enemy = GenerateEnemyForArea(i, j);
                }
            }
        }

        private void AnnounceArea(int currentArea)
        {
            AreaNames area = (AreaNames)currentArea;
            TypeText($"\nEntering the {area}");
        }

        private void GenerateEnemyForArea(int area, int encounter) //EDIT MORE HERE
        {
            //Make last encounter of each area a mini boss
            bool isAreaBoss = (encounter == encountersPerArea);

            if (area == 1)
            {

            }
        }
    }
}