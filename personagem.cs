using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class Dice
    {
        public static Random rng = new Random();

        public static int Roll(int min, int max)
        {
            return rng.Next(min, max + 1);
        }
    }
    class personagem
    {
        public string Nome { get; }
        public int STR { get; set; }
        public int DEX { get; set; }
        public int CON{ get; set; }
        public int AC { get; set; }
        public int HP { get; set;}
        public bool WithShield { get; set; }
        public bool Live { get; set; }

        // -----------------------------------------------------------
        
        internal int GerarPlayerHP()
        {
            return Dice.rng.Next(2, 21) + CON + 10;
        }

        internal int GerarMobHP(int HPfixo)
        {
            return Dice.rng.Next(1, 7) + HPfixo;
        }

        public void ReceberDano(int dano)
        {
            this.HP -= dano;
            if (HP <= 0)
            {
                Console.WriteLine($"{Nome} foi derrotado!");
            }
            else
            {
                Console.WriteLine($"{Nome} ainda está de pé ");
            }
        }

        public bool IsLivePlayer(int DanoRecebidoPlayer)
        {

            HP -= DanoRecebidoPlayer;
            if (HP > 0)
            {
                Console.WriteLine("Você permanece de pé. " + HP + " HP restante...");
                return true;
            }
            else
            {
                Console.WriteLine("Acaba aqui... ");
                return false;
            }
        }

        /* public bool IsLiveMob(int DanoRecebidoMob) 
        {
            hp do monstro = GerarMobHP();
            hp do monstro -= DanoRecebidoMob;
            if (hp do monstro >= 1) { Console.WriteLine("Ele resiste"); return true; }
            else if (hp do monstro <= 0} { Console.WriteLine("O monstro morreu"); return false;}

        }
         */
        public personagem(string NAME, int str, int dex, int con, int ac)
        {
            Nome = NAME;
            STR = str;
            DEX = dex;
            CON = con;
            AC = ac;
            HP = GerarPlayerHP();
        }

    }
}
