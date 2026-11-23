namespace Emberbound
{
    public interface IPlayer
    {
        //Name - Inputed by user at start
        string Name { get; set; }

        //Stats - Can be upgraded per run
        int MaxHealth { get; set; }
        int Damage { get; set; }
        int Defense { get; set; }
        int Agility { get; set; }
        int Exp { get; set; }

        //Current Health to change over time
        int CurrentHealth { get; set; }

        //Economy and Inventory
        int Coins { get; set; }
        string EquippedArmor { get; set; }
        string EquippedWeapon { get; set; }
        string EquippedShield { get; set; }
        string EquippedShoes { get; set; }
        int EquippedHealingPotions { get; set; }

        //Area Tracking
        int CurrentArea { get; set; }

        //Show stats
        void ShowStats();
    }
}