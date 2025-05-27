using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    
    internal class Equipamento
    {
        public int Armor { get; set; }
        public string WeaponName { get; set; }
        public int WeaponDamageMax { get; set; } 
        public int WeaponDamageMin { get; set; }
        public int Shield { get; set; }

        public Equipamento(string NomeArma, int DanoMin, int DanoMax) {
            NomeArma = WeaponName;
            DanoMin = WeaponDamageMin;
            DanoMax = WeaponDamageMax;
        }
        
        public int RolarDano(int Força)
        {
            return Dice.rng.Next(WeaponDamageMin, WeaponDamageMax) + Força;
        }

    }
}
