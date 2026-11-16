namespace Emberbound
{
    public class Enemy : IEnemy
    {
        protected string name;
        protected int health;
        protected int damage;
        protected int defense;
        protected int agility;
        protected int coins;

        public Enemy(string name, int health, int damage, int defense, int agility, int coins)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Defense = defense;
            Agility = agility;
            Coins = coins;
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
    }
}