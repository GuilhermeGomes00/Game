using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MobZOMBIE : personagem
    {
        //public Equipamento arma {  get; set; }

        public MobZOMBIE(string NAME, int str, int dex, int con, int ac) : base(NAME, str, dex, con, ac)
        {
            NAME = "Zumbi";
            str = 1;
            dex = -2;
            con = 3;
            ac = 9;

        }

        public void Slam(personagem alvo)
        {

            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 2;
            Console.WriteLine($"{this.Nome} Atacou com {RolagemAtaque} e tirou {arma.RolarDano(str)}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = arma.RolarDano(this.STR);
                alvo.ReceberDano(dano);
                Console.WriteLine($"Causou {dano} de dano. ");
            }
            else
            {
                Console.WriteLine("Errou o ataque.");
            }

        }

    }
}
