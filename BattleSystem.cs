using System;
using System.Threading;

namespace Emberbound
{
    public class BattleSystem
    {
        private BattleState state;
        private Player player;
        private Enemy enemy;

        //Add chance to player and enemy attacks
        private static readonly Random _random = new Random();

        //Track temporary defense boost
        private int temporaryDefenseBoost = 0;

        private AreaNames area; 

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

        public void SetUpBattle(Player playerInstance, Enemy enemyInstance)
        {
            //Set up player and enemy
            player = playerInstance;
            enemy = enemyInstance;

            //Set battle state to start
            state = BattleState.Start;

            //Enemy appears
            TypeText($"\nA {enemy.Name} appeared!");

            //Determine who goes first based on agility
            DetermineTurnOrder();
        }

        private void DetermineTurnOrder()
        {
            //Loop until either player or enemy dies, or player retreats
            while (player.CurrentHealth > 0 && enemy.Health > 0 && state != BattleState.Loss)
            {
                if (player.Agility >= enemy.Agility)
                {
                    //If player's agility is greater than or equal to enemy, go first
                    PlayerTurnPrompt();
                    if (CheckBattleOver()) break;

                    EnemyTurn();
                    if (CheckBattleOver()) break;
                }

                else
                {
                    //If enemy's agility is greate than the player, go first
                    EnemyTurn();
                    if (CheckBattleOver()) break;

                    PlayerTurnPrompt();
                    if (CheckBattleOver()) break;
                }
            }
        }

        private bool CheckBattleOver()
        {
            //Player dies
            if (player.CurrentHealth <= 0)
            {
                state = BattleState.Loss;
                TypeText("\nYou have been defeated...");
                return true;
            }

            //Enemy dies
            if (enemy.Health <= 0)
            {
                state = BattleState.Won;
                TypeText($"\nThe {enemy.Name} has been defeated!");

                //Determine random amount of coins given to player randomized from enemy coins - 5 to enemy coins + 5
                int coinsGiven = _random.Next(enemy.Coins - 5, enemy.Coins + 5);
                player.Coins += coinsGiven;
                TypeText($"\nYou received {coinsGiven} coins!");

                TypeText($"\nYou traverse further in the {area}.");
                return true;
            }

            if (state == BattleState.Loss)
            {
                return true;
            }
            return false;
        }

        private void PlayerTurnPrompt()
        {
           //Check for both player and enemy health
            if (player.CurrentHealth <= 0 || enemy.Health <= 0) return;

            state = BattleState.PlayerTurn;

            //Player actions
            TypeText("\nChoose your action:");
            Console.WriteLine("\n====================");
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Defend");
            Console.WriteLine("3: Use Healing Potion");
            Console.WriteLine("4: Scan");
            Console.WriteLine("5: Retreat");
            Console.WriteLine("====================");

            int playerDecision = 0;

            //Input must be an int and be 1-5
            while (playerDecision < 1 || playerDecision > 5)
            {
                try
                {
                    playerDecision = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    TypeText($"[Error]: {e.Message} Please try again.");
                }
            }

            PlayerDecision(playerDecision);
        }

        private void PlayerDecision(int playerDecision)
        {
            //Casting integer input to PlayerAction enum
            PlayerAction action = (PlayerAction)(playerDecision - 1);

            //Call each action method in switch statement
            switch (action)
            {
                case PlayerAction.Attack:
                    OnPlayerAttack();
                    break;
                case PlayerAction.Defend:
                    OnPlayerDefend();
                    break;
                case PlayerAction.UseHealingPotion:
                    OnPlayerUseHealingPotion();
                    break;
                case PlayerAction.Scan:
                    OnPlayerScan();
                    break;
                case PlayerAction.Retreat:
                    OnPlayerRetreat();
                    break;
                default:
                    TypeText("Unsupported action selected.");
                    PlayerTurnPrompt(); //Prompt again for unsupported selection
                    break;
            }
        }

        private void EnemyTurn()
        {
            //Check for both player and enemy health
            if (player.CurrentHealth <= 0 || enemy.Health <= 0) return;

            state = BattleState.EnemyTurn;

            TypeText($"\nThe {enemy.Name} attacked!");

            //10% chance for the enemy to miss their attack
            if (_random.Next(0, 100) < 10)
            {
                TypeText($"\nThe {enemy.Name}'s attack missed!");
                CleanUpDefenseBoost();
                return;
            }

            //Enemy damage to player based on damage stat, 10% for a critical hit (2x Damage)
            if (_random.Next(0, 100) < 10)
            {
                int damageTaken = Math.Max(1, (enemy.Damage * 2) - (player.Defense / 2));
                player.CurrentHealth -= damageTaken;
                TypeText("\nCritical Hit!");
                TypeText($"\nThe {enemy.Name} hit you for {damageTaken} damage!");
            }
            else
            {
                int damageTaken = Math.Max(1, enemy.Damage - (player.Defense / 2));
                player.CurrentHealth -= damageTaken;
                TypeText($"\nThe {enemy.Name} hit you for {damageTaken} damage!");
            }

            //Revert tmeperary defense boost if player choose to defend
            CleanUpDefenseBoost();
        }

        private void OnPlayerAttack()
        {
            //Console out player attack
            TypeText($"\n{player.Name} attacked with the {player.EquippedWeapon}!");

            //10% chance for the player to miss their attack
            if(_random.Next(0, 100) <  10)
            {
                TypeText($"\nYou swung at the {enemy.Name}, but missed!");
                return;
            }

            //Do damage to enemy based on damage stat, 10% for a critical hit (2x Damage)
            if (_random.Next(0, 100) < 10)
            {
                int damageDealt = Math.Max(1, (player.Damage * 2) - (enemy.Defense / 2));
                enemy.Health -= damageDealt;
                TypeText("\nCritical Hit!");
                TypeText($"\nYou hit the {enemy.Name} for {damageDealt} damage!");
            }
            else
            {
                int damageDealt = Math.Max(1, player.Damage - (enemy.Defense / 2));
                enemy.Health -= damageDealt;
                TypeText($"\nYou hit the {enemy.Name} for {damageDealt} damage!");
            }
        }

        private void OnPlayerDefend()
        {
            TypeText($"\nYou raised the {player.EquippedShield}, increasing your defense.");

            //Increase player defense by 50%
            temporaryDefenseBoost = (int)(player.Defense * .50);
            player.Defense += temporaryDefenseBoost;
        }

        private void CleanUpDefenseBoost()
        {
            if (temporaryDefenseBoost > 0)
            {
                player.Defense -= temporaryDefenseBoost;
                temporaryDefenseBoost = 0;
            }
        }

        private void OnPlayerUseHealingPotion()
        {
            //Player has no healing potions
            if (player.EquippedHealingPotions == 0)
            {
                TypeText($"\nYou have no healing potions equipped, you did nothing!");
            }
            //Player is at max health
            else if(player.MaxHealth == player.CurrentHealth)
            {
                TypeText($"\nYou are at max health, you did nothing!");
            }
            else
            {
                //Player uses a healing potion, checks so that it does not go above max health
                TypeText($"\nYou drank a healing potion!");
                if (player.MaxHealth - player.CurrentHealth < 10)
                {
                    int smallHealthGained = player.MaxHealth - player.CurrentHealth;
                    player.CurrentHealth += smallHealthGained;
                    TypeText($"\nRestored {smallHealthGained} Health! Current Health: {player.CurrentHealth}");
                }
                else
                {
                    player.CurrentHealth += 10;
                    TypeText($"\nRestored 10 Health! Current Health: {player.CurrentHealth}");
                }
                
                player.EquippedHealingPotions--;
            }
        }

        private void OnPlayerScan()
        {
            //See enemy stats
            TypeText($"\nScanning {enemy.Name}...");

            Console.WriteLine("\n==============================");
            Console.WriteLine($"Health: {enemy.Health}");
            Console.WriteLine($"Damage: {enemy.Damage}");
            Console.WriteLine($"Defense: {enemy.Defense}");
            Console.WriteLine($"Agility: {enemy.Agility}");
            Console.WriteLine("==============================");
        }

        private void OnPlayerRetreat()
        {
            //50% to flee from battle
            if (_random.Next(0, 100) < 50)
            {
                TypeText($"\nYou successfully fleed from the {enemy.Name}.");
                state = BattleState.Loss;
            }
            else
            {
                TypeText($"\nYou were unable to get away.");
            }
        }
    }
}