using System;

namespace Emberbound
{
    public class BattleSystem
    {
        private BattleState state;
        private Player player;
        private Enemy enemy;

        public void SetUpBattle(Player playerInstance, Enemy enemyInstance)
        {
            //Set up player and enemy
            player = playerInstance;
            enemy = enemyInstance;

            //Set battle state to start
            state = BattleState.Start;

            //Transition to player's turn
            state = BattleState.PlayerTurn;
            PlayerTurnPrompt();
        }

        private void PlayerTurnPrompt()
        {
            //Checks if Battle State is the player's turn
            if (state != BattleState.PlayerTurn)
            {
                return;
            }

            //Player actions
            Console.WriteLine("Choose your action:");
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
                    //OnPlayerAttack();
                    break;
                case PlayerAction.Defend:
                    //OnPlayerDefend();
                    break;
                case PlayerAction.UseItem:
                    //OnPlayerUseItem();
                    break;
                case PlayerAction.Scan:
                    //OnPlayerScan()
                    break;
                case PlayerAction.Retreat:
                    //OnPlayerRetreat();
                    break;
                default:
                    Console.WriteLine("Unsupported action selected.");
                    break;
            } 
        }
    }
}