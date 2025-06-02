using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Player : personagem
    {
        public Equipamento arma {  get; set; }
        public int QuantidadePocoes { get; set; } = 3;


        public int WieldShield(bool Shield)
        {
            if (Shield) { return 2; } else return 0;
        }

        public Player(String Nome, int str, int con, int dex, int armor, bool Shield, Equipamento arma) : base(Nome, str, con, dex, armor)
        {
            AC = 14 + dex + WieldShield(Shield);
            this.arma = arma;



        }

        public void UsarPocaoDeCura()
        {
            if (QuantidadePocoes > 0)
            {
                int cura = Dice.rng.Next(2, 8) + 2;
                HP += cura;
                if (HP > HP_MAX) HP = HP_MAX;
                QuantidadePocoes--;
            }
            else
            {
                Console.WriteLine("Você não tem mais poções.");
            }
        }


        public int Attack(personagem alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 2 + arma.WeaponAttackBonus;
            Console.WriteLine($"{this.Nome} deu um ataque de {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = arma.RolarDano(this.STR);
                alvo.ReceberDano(dano);
                Console.WriteLine($"{dano} de dano causado. ");
                return dano;
            }
            else
            {
                Console.WriteLine("Errou o ataque.");
                return 0;
            }
        }






    }
}


