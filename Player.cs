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


        public int WieldShield(bool Shield)
        {
            if (Shield) { return 2; } else return 0;
        }

        public Player(String Nome, int str, int con, int dex, int armor, bool Shield, Equipamento arma) : base(Nome, str, con, dex, armor)
        {
            AC = 14 + dex + WieldShield(Shield);
            this.arma = arma;


            //Equipamento espada = new Equipamento("Espada Curta", 1, 6);
            //Player heroi = new Player("Fulano", 3, 2, 1, 14, espada); ----> Forma pra causar dano
            // heroi.Arma.RolarDano(heroi.STR)
        }

        public int Attack(personagem alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 2;
            Console.WriteLine($"{this.Nome} deu um ataque de {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = arma.RolarDano(this.STR);
                alvo.ReceberDano(dano);
                Console.WriteLine($"{dano} de dano causado. ");
                return dano;
            } else {
                Console.WriteLine("Errou o ataque.");
                return 0;   
            }

        }

        


    }
}


