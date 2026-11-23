using System;

namespace Emberbound
{
    public class Player : IPlayer
    {
        protected string name;
        protected int maxHealth;
        protected int damage;
        protected int defense;
        protected int agility;
        protected int exp;
        protected int coins;
        protected int currentHealth;
        protected string equippedWeapon;
        protected string equippedArmor;
        protected string equippedShield;
        protected string equippedShoes;
        protected int equippedHealingPotions;
        protected int currentArea;

        public Player() {}

        public Player(string name, int maxHealth, int damage, int defense, int agility, int exp, int currentHealth, int coins, string equippedArmor, string equippedWeapon, string equippedShield, string equippedShoes, int equippedHealingPotions, int currentArea)
        {
            //Player name is inputed by user
            Name = name;

            //Default player stats
            MaxHealth = maxHealth;
            Damage = damage;
            Defense = defense;
            Agility = agility;
            Exp = exp;

            //Current Tracking Health
            CurrentHealth = currentHealth;

            //Starting currency and inventory
            Coins = coins;
            EquippedArmor = equippedArmor;
            EquippedWeapon = equippedWeapon;
            EquippedShield = equippedShield;
            EquippedShoes = equippedShoes;

            //Amount of healing potions
            EquippedHealingPotions = equippedHealingPotions;

            //Starting area number
            CurrentArea = currentArea;
        }

        public void ShowStats()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Max Health: {MaxHealth}");
            Console.WriteLine($"Damage: {Damage}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Agility: {Agility}");
            Console.WriteLine($"Coins: {Coins}");
            Console.WriteLine($"Armor: {EquippedArmor}");
            Console.WriteLine($"Weapon: {EquippedWeapon}");
            Console.WriteLine($"Shield: {EquippedShield}");
            Console.WriteLine($"Shoes: {EquippedShoes}");
            Console.WriteLine($"Healing Potions: {EquippedHealingPotions}");
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

        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Player max health cannot be negative.");
                }
                maxHealth = value;
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

        public int Exp
        {
            get => exp;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("EXP cannot be negative.");
                }
                exp = value;
            }
        }

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
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

        public string EquippedShield
        {
            get => equippedShield;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Equipped shield cannot be empty.");
                }
                equippedShield = value;
            }
        }

        public string EquippedShoes
        {
            get => equippedShoes;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.Exception("Equipped shoes cannot be empty.");
                }
                equippedShoes = value;
            }
        }

        public int EquippedHealingPotions
        {
            get => equippedHealingPotions;
            set
            {
                if (value < 0)
                {
                    throw new System.Exception("Equipped healing potions cannot be negative.");
                }
                equippedHealingPotions = value;
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