namespace Emberbound
{
    internal interface IEnemy
    {
        //Name of enemy
        string Name { get; set; }

        //Enemy stats
        int Health { get; set; }
        int Damage { get; set; }
        int Defense { get; set; }
        int Agility { get; set; }
    }
}
