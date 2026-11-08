using System;

namespace Emberbound
{
    public class Player : IPlayer
    {
        protected string name;
        protected int health;
        protected int damage;
        protected int defense;
        protected int agility;
        protected int coins;
        protected string equippedWeapon;
        protected string equippedArmor;
        protected int currentArea;

        public Player() {}

        public Player(string name, int health, int damage, int defense, int agility, int coins, string equippedWeapon, string equippedArmor, int currentArea)
        {
            //Player name is inputed by user
            Name = name;

            //Default player stats
            Health = health;
            Damage = damage;
            Defense = defense;
            Agility = agility;

            //Starting currency and inventory
            Coins = coins;
            EquippedWeapon = equippedWeapon;
            EquippedArmor = equippedWeapon;

            //Starting area number
            CurrentArea = currentArea;
        }

        public void ShowStats()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Coins: {Coins}");
            Console.WriteLine($"Weapon: {EquippedWeapon}");
            Console.WriteLine($"Armor: {EquippedArmor}");
            Console.WriteLine("==============================");
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Player name cannot be empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Health cannot be negative.");
                }
                health = value;
            }
        }

        public int Damage
        {
            get => damage;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Damage cannot be negative.");
                }
                damage = value;
            }
        }

        public int Defense
        {
            get => defense;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Defense cannot be negative.");
                }
                defense = value;
            }
        }

        public int Agility
        {
            get => agility;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Agility cannot be negative.");
                }
                agility = value;
            }
        }

        public int Coins
        {
            get => coins;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Coins cannot be negative.");
                }
                coins = value;
            }
        }

        public string EquippedWeapon
        {
            get => equippedWeapon;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Equipped weapon cannot be empty.");
                }
                equippedWeapon = value;
            }
        }

        public string EquippedArmor
        {
            get => equippedArmor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Equipped armor cannot be empty.");
                }
                equippedArmor = value;
            }
        }

        public int CurrentArea
        {
            get => currentArea;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Current area cannot be negative.");
                }
                currentArea = value;
            }
        }
    }
}
