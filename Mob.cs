using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Mob : personagem
    {
        public Mob(String Nome, int armor = 9, int con = 3, int str = 1, int dex = 0) : base(Nome, str, dex, con, armor)
        {
            const int Hp_Fixo = 9;
            this.HP = GerarMobHP(Hp_Fixo);
            

        }

        
        private int MobAttack(string nomeDoAtaque, int dadoDanoMax, int dadoDanoMin, Player alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 2;
            Console.WriteLine($"{this.Nome} deu um ataque de mordida, tendo um acerto de: {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = Dice.rng.Next(dadoDanoMin, dadoDanoMax) + this.STR;
                alvo.ReceberDano(dano);
                Console.WriteLine($"{dano} de dano causado. ");
                return dano;
            }
            else { Console.WriteLine(Nome + " Errou o ataque"); return 0; }  


        }


        public int ClawAttack(Player player)
        {
            return MobAttack("garra", 8, 1, player);
        }

        public int BiteAttack(Player player)
        {
            return MobAttack("mordida", 6, 1, player);
        }


    }
}
