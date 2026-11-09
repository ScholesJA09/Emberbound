using System;

namespace Emberbound
{
    public class BattleSystem
    {
        private BattleState state;
        private Player player;
        private Enemy enemy;
        //Add chance to player and enemy attacks
        private static readonly Random _random = new Random();
        bool isDefending = false;

        public void SetUpBattle(Player playerInstance, Enemy enemyInstance)
        {
            //Set up player and enemy
            player = playerInstance;
            enemy = enemyInstance;

            //Set battle state to start
            state = BattleState.Start;

            //Enemy appears
            Console.WriteLine($"A {enemy.Name} appeared!");

            //Determine who goes first based on agility
            DetermineFirst();
        }

        private void DetermineFirst()
        {
            //If player's agility is greater than or equal to enemy, go first
            if (player.Agility >= enemy.Agility)
            {
                state = BattleState.PlayerTurn;
                PlayerTurnPrompt();
            }
            else
            {
                EnemyTurn();
            }
        }

        private void PlayerTurnPrompt()
        {
            //Checks if Battle State is the player's turn
            if (state != BattleState.PlayerTurn)
            {
                return;
            }

            //Player actions
            Console.WriteLine("\nChoose your action:");
            Console.WriteLine("\n====================");
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Defend");
            Console.WriteLine("3: Use Item");
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
                    Console.WriteLine($"[Error]: {e.Message} Please try again.");
                }
            }

            PlayerDecision(playerDecision);
        }

        private void PlayerDecision(int playerDecision) //Start editing here
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
                case PlayerAction.UseSpell:
                    OnPlayerUseSpell();
                    break;
                case PlayerAction.Scan:
                    OnPlayerScan();
                    break;
                case PlayerAction.Retreat:
                    OnPlayerRetreat();
                    break;
                default:
                    Console.WriteLine("Unsupported action selected.");
                    break;
            }

            //Do enemy turn based on agility
            if (player.Agility >= enemy.Agility)
            {
                EnemyTurn();
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine($"The {enemy.Name} attacked!");

            //10% chance for the enemy to miss their attack
            if (_random.Next(0, 100) < 10)
            {
                Console.WriteLine($"The {enemy.Name}'s attack missed!");
                return;
            }

            //Enemy damage to player based on damage stat
            player.Health -= Math.Max(1, enemy.Damage - (player.Defense / 2));
            Console.WriteLine($"The {enemy.Name} hit you for {player.Damage} damage!");

            //Check if player is defeated
            if (player.Health <= 0)
            {
                Console.WriteLine($"You have been defeated!");
                state = BattleState.Loss;
            }

            //Do player turn based on agility
            if (player.Agility <= enemy.Agility)
            {
                PlayerTurnPrompt();
            }
        }

        private void OnPlayerAttack()
        {
            //Console out player attack
            Console.WriteLine($"{player.Name} attacked with the {player.EquippedWeapon}!");

            //10% chance for the player to miss their attack
            if(_random.Next(0, 100) <  10)
            {
                Console.WriteLine($"You swung at the {enemy.Name}, but missed!");
                return;
            }

            //Do damage to enemy based on damage stat
            enemy.Health -= Math.Max(1, player.Damage - (enemy.Defense / 2));
            Console.WriteLine($"You hit the {enemy.Name} for {player.Damage} damage!");

            //Check if eneny is defeated
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"The {enemy.Name} is defeated!");
                state = BattleState.Won;
            }
        }

        private void OnPlayerDefend()
        {
            Console.WriteLine($"You raised the {player.EquippedShield}.");

            //Increases players defense by 50%
            player.Defense += (int)(player.Defense * .50);
            isDefending = true;
        }

        private void OnPlayerUseSpell()
        {
            //If no spell is equipped, attack fails
            if (player.EquippedSpell == "None")
            {
                Console.WriteLine($"You have no spells, you casted nothing!");
            }
            //else if player has specific spell
        }

        private void OnPlayerScan()
        {
            //See enemy stats
            Console.WriteLine($"Scanning {enemy.Name}...");

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
                Console.WriteLine($"You flee from the {enemy.Name}");
                return;
            }
            else
            {
                Console.WriteLine($"You were unable to get away.");
            }
        }
    }
}