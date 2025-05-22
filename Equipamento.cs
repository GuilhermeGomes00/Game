using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Equipamento() : Chara(3, 1, 2)
    {
        public int Armor { get; set; }
        public string WeaponName { get; set; }
        public int WeaponDamage { get; set; } 
        public int Shield { get; set; }


        public static int StocDamage(bool Acertou, Chara atacou)
        {

            return Dice.rng.Next(1, 9) + atacou.STR;
        }

        public static int GSdamage(bool acertou,  Chara atacou) { return Dice.rng.Next(2, 13) + atacou.STR; }
    }
}
