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
                    //Set up enemy encounter
                    battleSystem.SetUpBattle(player, enemy);

                    //Game Over Screen if player is defeated
                    if (player.CurrentHealth <= 0)
                    {
                        TypeText("\n=== GAME OVER ===");
                        return;
                    }
                }

                //Player completes area
                AreaNames area = (AreaNames)i;
                TypeText($"\nYou make it past the {area - 1} and find a camp.");

                //Player goes to shop
                OpenShop(i);

                //Player rests, gaining small amount of health before going to next area
                //Checks to make sure restHeal doesn't go above maxHealth
                int restHeal = 10;
                if (player.MaxHealth - player.CurrentHealth < 10)
                {
                    int restSmallerHeal = player.MaxHealth - player.CurrentHealth;
                    TypeText($"\nYou settle in for the night, recovering {restSmallerHeal} Health.");
                    player.CurrentHealth += restSmallerHeal;

                }
                else
                {
                    TypeText($"\nYou settle in for the night, recovering {restHeal} Health.");
                    player.CurrentHealth += restHeal;
                }
            }
        }

        private void AnnounceArea(int currentArea)
        {
            AreaNames area = (AreaNames)currentArea;
            TypeText($"\nEntering the {area - 1}");
        }

        private Enemy GenerateEnemyForArea(int area, int encounter)
        {
            //Make last encounter of each area a mini boss
            bool isAreaBoss = (encounter == encountersPerArea);

            //Whispering Woods
            if (area == 1)
            {
                if (isAreaBoss)
                {
                    return new Enemy("Forest Troll", 1, 6, 4, 7, 25); //Health=20
                }
                return new Enemy("Goblin Scout", 1, 3, 2, 3, 10); //Health=5
            }

            //Misty Mountains
            else if (area == 2)
            {
                if (isAreaBoss)
                {
                    return new Enemy("Magma Golem", 42, 11, 8, 9, 40);
                }
                return new Enemy("Cinder Skeleton", 22, 8, 4, 6, 15);
            }

            //Frozen Fortress
            else
            {
                if (isAreaBoss)
                {
                    return new Enemy("Glacial Sentinal", 65, 15, 10, 10, 70);
                }
                return new Enemy("Frozen Knight", 38, 12, 8, 9, 20);
            }
        }

        private void OpenShop(int area)
        {
            bool shopping = true;

            //Loop until player selects to stop shopping
            while(shopping)
            {
                Console.WriteLine($"\n--- WANDERING MERCHANT (Coins: {player.Coins}) ---");
                Console.WriteLine("1: Consume Vitality Pill (+10 Max Health) - 20 Coins");
                Console.WriteLine("2: Sharpen Weapon (+3 Damage) - 15 Coins");
                Console.WriteLine("3: Reinforce Shield (+2 Defense) - 15 Coins");
                Console.WriteLine("4: Enchant Boots (+2 Agility) - 10 Coins");
                Console.WriteLine("5: Buy Healing Potion (3 Max) - 10 Coins");
                Console.WriteLine("6: Leave Shop and Continue Journey");

                //Loop until user selects valid number
                int choice = 0;
                while(choice < 1 || choice > 6)
                {
                    string input = Console.ReadLine();
                    try
                    {
                        choice = int.Parse(input);
                    }
                    catch (Exception e)
                    {
                        TypeText($"\n[Error]: {e.Message} Please try again.");
                    }
                }

                //Effects for each shop decision
                switch (choice)
                {
                    //Upgradeing Max Health
                    case 1:
                        if (player.Coins >= 20)
                        {
                            player.MaxHealth += 10;
                            player.Coins -= 20;
                            TypeText($"\nYou took the pill! Your max health is now {player.MaxHealth}!");
                        }
                        else
                        {
                            TypeText("\nNot enough coins!");
                        }
                        break;
                    //Upgrading Damage
                    case 2:
                        if (player.Coins >= 15)
                        {
                            player.Damage += 3;
                            player.Coins -= 15;
                            TypeText($"\nWeapon Upgraded! Your damage is now {player.Damage}!");
                        }
                        else
                        {
                            TypeText("\nNot enough coins!");
                        }
                        break;
                    //Upgrading Defense
                    case 3:
                        if (player.Coins >= 15)
                        {
                            player.Defense += 2;
                            player.Coins -= 15;
                            TypeText($"\nShield Upgraded! Your defense is now {player.Defense}!");
                        }
                        else
                        {
                            TypeText("\nNot enough coins!");
                        }
                        break;
                    //Upgrading Agility
                    case 4:
                        if (player.Coins >= 10)
                        {
                            player.Agility += 2;
                            player.Coins -= 10;
                            TypeText($"\nBoots Enchanted! Your agility is now {player.Agility}!");
                        }
                        else
                        {
                            TypeText("\nNot enough coins!");
                        }
                        break;
                    //Purchasing Healing Potion
                    case 5:
                        if (player.EquippedHealingPotions >= 3)
                        {
                            TypeText("\nYou already have the maxxed amount of healing potions!");
                            break;
                        }

                        if (player.Coins >= 10)
                        {
                            player.EquippedHealingPotions++;
                            player.Coins -= 10;
                            TypeText("\nYou purchased a healing potion!");
                        }
                        else
                        {
                            TypeText("\nNot enough coins!");
                        }
                        break;
                    //Leaving Shop
                    case 6:
                        TypeText("\nYou pack your gear and leave the merchant.");
                        shopping = false;
                        break;
                }
            }
        }
    }
}