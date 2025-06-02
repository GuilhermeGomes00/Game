using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Mobs
    {
        public static string GerarMob()
        {
            int probabilidade = Dice.rng.Next(1, 100);
            string Monstro = "";
            if (probabilidade >= 51) return Monstro = "Morto-Vivo"; else return Monstro = "Esqueleto";
        }
    }
    class Mob1 : personagem
    {
        public Mob1(String Nome, int armor = 9, int con = 3, int str = 1, int dex = 0) : base(Nome, str, dex, con, armor)
        {
            const int Hp_Fixo = 3;
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
                Console.Write($"{Nome} Acertou o ataque, e causou: {dano}");
                return dano;
            }
            else { Console.Write(Nome + " Errou o ataque "); return 0; }  


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

    class mob2 : personagem // Esqueleto
    {
        public mob2(String Nome, int armor = 14, int con = 2, int str = 0, int dex = 2) : base(Nome, str, dex, con, armor)
        {
            const int Hp_Fixo = 2;
            this.HP = GerarMobHP(Hp_Fixo);
        }

        private int Mob2Attack(string nomeDoAtaque, int dadoDanoMax, int dadoDanoMin, Player alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.DEX + 2;
            Console.WriteLine($"{this.Nome} deu um atacou tendo um acerto de: {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = Dice.rng.Next(dadoDanoMin, dadoDanoMax) + this.DEX;
                alvo.ReceberDano(dano);
                Console.Write($"{Nome} Acertou o ataque, e causou: {dano}");
                return dano;
            }
            else { Console.Write(Nome + " Errou o ataque "); return 0; }
        }

        public int ShortSwordAttack(Player player)
        {
            return Mob2Attack("Espada curta", 6, 1, player);
        }

        public int ShieldStrikeAttack(Player player)
        {
            return Mob2Attack("Escudada", 4, 1, player);
        }
    }

    class mob3 : personagem // Mimico
    {
        public mob3(String Nome, int armor = 12, int con = 2, int str = 3, int dex = 1) : base(Nome, str, dex, con, armor)
        {
            const int Hp_Fixo = 15;
            this.HP = GerarMobHP(Hp_Fixo);
        }

        private int Mob3Attack(string nomeDoAtaque, int dadoDanoMax, int dadoDanoMin, Player alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 2;
            Console.WriteLine($"{this.Nome} deu um atacou tendo um acerto de: {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = Dice.rng.Next(dadoDanoMin, dadoDanoMax) + this.STR + Dice.rng.Next(1, 2);
                alvo.ReceberDano(dano);
                Console.Write($"{Nome} Acertou o ataque, e causou: {dano}");
                return dano;
            }
            else { Console.Write(Nome + " Errou o ataque "); return 0; }
        }

        public int BiteAttack(Player player)
        {
            return Mob3Attack("Mordida", 8, 1, player);
        }

        public int ShootAttack(Player player)
        {
            return Mob3Attack("Cuspe", 4, 12, player);
        }
    }


    class mob4 : personagem // Dragão esqueleto incompleto (DnD 5e)
    {
        public mob4(String Nome, int armor = 15, int con = 3, int str = 4, int dex = 2) : base(Nome, str, dex, con, armor)
        {
            const int Hp_Fixo = 20;
            this.HP = GerarMobHP(Hp_Fixo);
        }

        private int Mob4Attack(string nomeDoAtaque, int dadoDanoMax, int dadoDanoMin, Player alvo)
        {
            int RolagemAtaque = Dice.rng.Next(1, 21) + this.STR + 3;
            Console.WriteLine($"{this.Nome} deu um atacou tendo um acerto de: {RolagemAtaque}");

            if (RolagemAtaque >= alvo.AC)
            {
                int dano = Dice.rng.Next(dadoDanoMin, dadoDanoMax) + this.STR;
                alvo.ReceberDano(dano);
                Console.Write($"{Nome} Acertou o ataque, e causou: {dano}");
                return dano;
            }
            else { Console.Write(Nome + " Errou o ataque "); return 0; }
        }

        private int Mob4Breath(int SaveDex)
        {
            int BreathDamage = Dice.rng.Next(5, 20);
            const int DCsave = 12;
            int saveCheck = Dice.rng.Next(1, 20) + SaveDex;
            if (saveCheck >= DCsave) return BreathDamage / 2; else return BreathDamage;
        }


        public int BiteAttack(Player player)
        {
            return Mob4Attack("Mordida", 12, 2, player); 
        }

        public int HeadAttack(Player player)
        {
            return Mob4Attack("Batida com a cabeça", 8, 2, player); 
        }


        public int PutridBreath(Player player)
        {
            Console.WriteLine("insira descrição do sopro aqui");
            return Mob4Breath(1);
        }
    }
    
    }
