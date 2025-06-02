namespace ConsoleApp2
{
    internal class Equipamento
    {
        public int Armor { get; set; }
        public string WeaponName { get; set; }
        public int WeaponDamageMax { get; set; }
        public int WeaponDamageMin { get; set; }
        public int Shield { get; set; }
        public int WeaponAttackBonus { get; set; }  

        public Equipamento(string nomeArma, int danoMin, int danoMax, int bonusAtaque = 0, int escudo = 0)
        {
            WeaponName = nomeArma;
            WeaponDamageMin = danoMin;
            WeaponDamageMax = danoMax;
            WeaponAttackBonus = bonusAtaque;
            Shield = escudo;
        }

        public int RolarDano(int forca, int bonus = 0)
        {
            return Dice.rng.Next(WeaponDamageMin, WeaponDamageMax + 1) + forca + bonus;
        }
    }
}