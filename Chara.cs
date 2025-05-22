using System;

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
    internal class Chara
    {
        private int _STR = 0;
        private int _DEX = 0;
        private int _CON = 0;
        private int _AC = 0;
        private int _HP = 0;
        private bool _WithShield;
        private bool _Live;

        public int STR { get => _STR; set => _STR = value; }
        public int DEX { get => _DEX; set => _DEX = value; }
        public int CON { get => _CON; set => _CON = value; }
        public int AC { get => _AC; set => _AC = value; }
        public bool WithShield { get => _WithShield; set => _WithShield = value; }
        



        public int HP
        {
            get => _HP;
            set => _HP = value;
        }

        public Chara(int str, int dex, int con)
        {
            STR = str;
            DEX = dex;
            CON = con;

            
            _HP = GerarHP();
        }

        

        private int GerarHP()
        {
            Random rand = new Random();
            return rand.Next(2, 21) + CON + 10;
        }

        public int Ataque (string Arma, bool acerto)
        {
            if (Arma == "teste") return Equipamento.StocDamage(acerto, this);
            else if (Arma == "teste2") return Equipamento.GSdamage(acerto, this);
            else return 0;
        }

        //public int Atacar()
        //{
        //    bool acerto = true;
        //    return Equipamento.StocDamage(acerto, this); 
        //}

        //public int Atacar1()
        //{
        //    bool acerto = true;
        //    return Equipamento.GSdamage(acerto, this);
        //}
    }
}
