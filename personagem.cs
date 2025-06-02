using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private int _hpMax;
        public int HP_MAX => _hpMax;


        public bool WithShield { get; set; }
        

        // -----------------------------------------------------------
        
        internal int GerarPlayerHP()
        {
            return Dice.rng.Next(5, 21) + CON + 10;
        }

        internal int GerarMobHP(int HPfixo)
        {
            return Dice.rng.Next(1, 7) + HPfixo + 9;
        }

        public int ReceberDano(int dano)
        {
            return this.HP -= dano;
        }

        public bool IsLive()
        {
            if (this.HP >= 1) return true; else  return false; 
        }

        

        public personagem(string NAME, int str, int dex, int con, int ac)
        {
            Nome = NAME;
            STR = str;
            DEX = dex;
            CON = con;
            AC = ac;
            HP = GerarPlayerHP();
            _hpMax = HP;
        }



    }
}
