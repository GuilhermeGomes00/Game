using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;

namespace Game
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string EscolhaArma;
            
            Chara person = new Chara(3, 1, 2);
            

            Console.WriteLine("Vc pega a espadona ou espadinha?");
            EscolhaArma = Console.ReadLine().ToLower();
            int DanoCausado = 0;

            if (EscolhaArma == "espadona")
            {
                Console.WriteLine("Brabo, vc escolheu a " + EscolhaArma);
                EscolhaArma = "teste";
                DanoCausado = person.Ataque(EscolhaArma, true);
            } else if (EscolhaArma == "espadinha")
            {
                Console.WriteLine("Brabo, vc escolheu a " + EscolhaArma);
                EscolhaArma = "teste2";
                DanoCausado = person.Ataque(EscolhaArma, true);
            }
            

            Console.WriteLine("O dano foi " + DanoCausado);


                Console.ReadKey();

        }
    }
}
