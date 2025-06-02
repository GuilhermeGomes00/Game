using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;
using Microsoft.SqlServer.Server;

namespace Game
{



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Prologo();
            


            Console.ReadKey();            
        }


        

        static void Prologo()
        {
            Console.WriteLine("=== Dungeon do Destino ===\n");
            Console.WriteLine("Você é um aventureiro solitário em busca de glória e relíquias antigas.");
            Console.WriteLine("Dizem que uma dungeon esquecida surgiu nos arredores de uma vila abandonada...");
            Console.WriteLine("Reza a lenda que uma criatura poderosa guarda um tesouro há muito perdido.");
            Console.WriteLine("Você entra na escuridão, prestes a enfrentar o desconhecido.\n");

            Console.WriteLine("Qual o seu nome, aventureiro?");
            string nome = Console.ReadLine();

            Console.WriteLine("\nEscolha seu equipamento inicial:");
            Console.WriteLine("1. Espada larga");
            Console.WriteLine("2. Espada longa e escudo");
            Console.Write("Sua escolha (1 ou 2): ");

            string escolha = Console.ReadLine();
            Equipamento equipamentoEscolhido;
            bool comEscudo = false;

            while (true)
            {
                if (escolha == "1")
                {
                    equipamentoEscolhido = new Equipamento("Espada larga", 2, 10); 
                    comEscudo = false;
                    Console.WriteLine("\nVocê empunha uma espada larga, pesada, mas mortal.");
                    break;
                }
                else 
                {
                    equipamentoEscolhido = new Equipamento("Espada longa", 1, 8); // - Dano, +def
                    comEscudo = true;
                    Console.WriteLine("\nVocê empunha uma espada longa e segura um escudo firme.");
                    break;
                } 
            }

            Player p = new Player(nome, str: 3, con: 2, dex: 1, armor: 0, Shield: comEscudo, arma: equipamentoEscolhido);

            Console.WriteLine($"\nBoa sorte, {p.Nome}. A dungeon aguarda...\n");

            // ---------------------------------------------------------------------------------------------------


            Console.Clear();
            Console.WriteLine("=== Entrada da Dungeon ===\n");

            Console.WriteLine("Você caminha por trilhas esquecidas, os pés afundando na terra úmida da floresta.");
            Console.WriteLine("Após horas de viagem, avista entre as árvores a entrada de pedra escura de uma estrutura ancestral.");
            Console.WriteLine("A brisa fria que sopra de dentro da caverna parece sussurrar nomes esquecidos...");
            Console.WriteLine("Com a arma em punho, você acende uma tocha e desce as escadas esculpidas na rocha.\n");

            Console.WriteLine("O ar lá dentro é denso, abafado e repleto do cheiro de mofo e sangue seco.");
            Console.WriteLine("Você sente seus instintos gritarem quando uma silhueta se move nas sombras.\n");

            Console.WriteLine("Algo se aproxima rapidamente...");
            Console.WriteLine("Prepare-se para lutar!\n");

            Console.ReadKey();
            Console.Clear();
            Combate1(p);
        }

        // -----------------------------------------------------------------------------------------------------------------------------
        static void Combate1(Player p)
        {
            string monstro = Mobs.GerarMob();
            personagem inimigo;

            if (monstro == "Morto-Vivo")
            {
                inimigo = new Mob1("Zumbi");
                Console.WriteLine("Das sombras surge um zumbi fétido e faminto!");
            }
            else
            {
                inimigo = new mob2("Esqueleto");
                Console.WriteLine("Um esqueleto de olhos ocos se ergue do chão, empunhando uma arma enferrujada!");
            }

            while (p.IsLive() && inimigo.IsLive())
            {
                Console.WriteLine("\n============== COMBATE ==============");
                Console.WriteLine($"{p.Nome} - HP: {p.HP}/{p.HP_MAX} | AC: {p.AC} | Poções: {p.QuantidadePocoes}");
                Console.WriteLine($"{inimigo.Nome} - HP: {inimigo.HP}");
                Console.WriteLine("\nEscolha sua ação:");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar poção");
                Console.WriteLine("3 - Fugir");
                Console.WriteLine("\n=====================================");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"\n{p.Nome} parte para o ataque!");
                        Console.WriteLine();
                        p.Attack(inimigo);
                        break;

                    case "2":
                        Console.WriteLine($"\n{p.Nome} tenta se recuperar com uma poção...");
                        p.UsarPocaoDeCura();
                        break;

                    case "3":

                        Console.WriteLine("Você tenta fugir...");
                        int chance = Dice.rng.Next(1, 100);
                        if (chance >= 65)
                        {
                            Console.WriteLine("Você consegue fugir...");
                            inimigo.ReceberDano(100);
                        }
                        else
                        {
                            Console.WriteLine("Você não é rapido o suficiente...");
                        }
                        break;

                    default:
                        Console.WriteLine("Ação inválida.");
                        continue;
                }

                Console.ReadKey();
                Console.Clear();
                // Aquela verificada fera
                if (inimigo.IsLive())
                {
                    Console.WriteLine($"\n{inimigo.Nome} contra-ataca!");

                    
                    if (inimigo is Mob1 mob1)
                    {
                        int prob = Dice.rng.Next(1, 2);
                        if (prob == 1) mob1.BiteAttack(p); else mob1.ClawAttack(p);
                    }
                    else if (inimigo is mob2 mob2)
                    {
                        int prob = Dice.rng.Next(1, 2);
                        if (prob == 1) mob2.ShortSwordAttack(p); else mob2.ShieldStrikeAttack(p);
                    }
                }

                Console.WriteLine("\n--- Fim do turno ---");
                Console.ReadKey();
                Console.Clear();
            }

            if (p.IsLive())
            {
                Console.WriteLine($"\n{p.Nome} sobreviveu ao combate!");
            }
            else
            {
                Console.WriteLine($"\n{p.Nome} foi derrotado na dungeon...");
            }
            if (p.IsLive()) EventoDoBau(p);
        }
        // -------------------------------------------------------------------------------------------------------

        static void EventoDoBau(Player p)
        {
            Console.Clear();
            Console.WriteLine("O combate chegou ao fim. Sua respiração é pesada, mas você segue em frente...");
            Console.WriteLine("Caminhando pelo corredor escuro e úmido, você percebe um brilho estranho no fim do salão.");

            Console.WriteLine("\nAo se aproximar com cautela, percebe que é um baú de madeira antiga, parcialmente coberto de musgo.");
            Console.WriteLine("Histórias antigas falam sobre baús encantados... e sobre mímicos traiçoeiros.");
            Console.WriteLine("Você sente que precisa tomar uma decisão.\n");

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir o baú");
            Console.WriteLine("2 - Ignorar e continuar a dungeon");

            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                Console.WriteLine("\nVocê respira fundo e abre o baú...");

                int chance = Dice.rng.Next(1, 100);
                if (chance >= 75)
                {
                    Console.WriteLine("\nVocê sente o baú respirando... Baús não respiram...");
                    Console.WriteLine("\nEnormes dentes e braços desproporcinalmente cumpridos saem do baú...");
                    Console.WriteLine("\nPrepara-se para mais uma luta!");
                    Console.ReadKey();
                    Console.Clear();
                    Combate2(p);
                }
                else
                {
                    Console.WriteLine("\nUma recompensa o aguarda!!");
                    int frascos = Dice.rng.Next(1, 3);
                    p.QuantidadePocoes += frascos;
                    int bonusAtaque = Dice.rng.Next(1, 6) + 1;
                    p.arma = new Equipamento("Espada mágica", 2, 10, bonusAtaque, 1);
                    Console.WriteLine("\nDentro do baú você encontra uma espada reluzente e mais " + frascos + " de poção");
                    Console.WriteLine("\nVocê sente um imenso poder vindo da sua nova conquista!!");
                    Console.WriteLine("\nVocê continua pela dungeon, atento ao que pode estar adiante.");
                }
            }
            else
            {
                Console.WriteLine("\nVocê decide não arriscar e continua seu caminho, deixando o baú para trás...");
            }

            Console.ReadKey();
            Console.Clear();
            CombateFinal(p);
        }

        // -------------------------------------------------------------------------------------------------------

        static void Combate2(Player p)
        {
            personagem inimigo;
            inimigo = new mob3("Mimico");
            

            while (p.IsLive() && inimigo.IsLive())
            {
                Console.WriteLine("\n============== COMBATE ==============");
                Console.WriteLine($"{p.Nome} - HP: {p.HP}/{p.HP_MAX} | AC: {p.AC} | Poções: {p.QuantidadePocoes}");
                Console.WriteLine($"{inimigo.Nome} - HP: {inimigo.HP}");
                Console.WriteLine("\nEscolha sua ação:");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar poção");
                Console.WriteLine("3 - Fugir");
                Console.WriteLine("\n=====================================");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"\n{p.Nome} parte para o ataque!");
                        Console.WriteLine();
                        p.Attack(inimigo);
                        break;

                    case "2":
                        Console.WriteLine($"\n{p.Nome} tenta se recuperar com uma poção...");
                        p.UsarPocaoDeCura();
                        break;

                    case "3":

                        Console.WriteLine("Você tenta fugir...");
                        int chance = Dice.rng.Next(1, 100);
                        if (chance >= 65)
                        {
                            Console.WriteLine("Você consegue fugir...");
                            inimigo.ReceberDano(100);                            
                        }else
                        {
                            Console.WriteLine("Você não é rapido o suficiente...");
                        }
                        break;

                    default:
                        Console.WriteLine("Ação inválida.");
                        continue; 
                }

                Console.ReadKey();
                Console.Clear();
                // Aquela verificada fera 2
                if (inimigo.IsLive())
                {
                    Console.WriteLine($"\n{inimigo.Nome} contra-ataca!");


                    int prob = Dice.rng.Next(1, 2);
                    if (inimigo is mob3 mob3)
                    {
                        if (prob == 1) mob3.BiteAttack(p); else mob3.ShootAttack(p);
                    }
                }

                Console.WriteLine("\n--- Fim do turno ---");
                Console.ReadKey();
                Console.Clear();
            }

            if (p.IsLive())
            {
                Console.WriteLine($"\n{p.Nome} sobreviveu ao combate!");
            }
            else
            {
                Console.WriteLine($"\n{p.Nome} foi derrotado na dungeon...");
            }
        }

        static void CombateFinal(Player p)
        {
            personagem boss = new mob4("Dragão Esqueleto");

            Console.Clear();
            Console.WriteLine("Você entra em um grande salão tomado por ossos e poeira.");
            Console.WriteLine("Uma estrutura dracônica desperta, movida por necromancia antiga...");
            Console.WriteLine("Um rugido seco ecoa, sacudindo a estrutura ao seu redor.");
            Console.WriteLine("Você encara o Dragão Esqueleto. A batalha final começa!\n");

            while (p.IsLive() && boss.IsLive())
            {
                Console.WriteLine("\n============== BATALHA FINAL ==============");
                Console.WriteLine($"{p.Nome} - HP: {p.HP}/{p.HP_MAX} | AC: {p.AC} | Poções: {p.QuantidadePocoes}");
                Console.WriteLine($"{boss.Nome} - HP: {boss.HP}");
                Console.WriteLine("\nEscolha sua ação:");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar poção");
                Console.WriteLine("3 - Fugir");
                Console.WriteLine("\n===========================================");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.WriteLine($"\n{p.Nome} parte para o ataque!");
                        p.Attack(boss);
                        break;

                    case "2":
                        Console.WriteLine($"\n{p.Nome} tenta se recuperar com uma poção...");
                        p.UsarPocaoDeCura();
                        break;

                    case "3":
                        Console.WriteLine("Você tenta fugir...");
                        Console.WriteLine("Isso não é um simples combate... ");
                        Console.WriteLine("\nNão é possível fugir.");
                        break;

                    default:
                        Console.WriteLine("Ação inválida.");
                        continue;
                }

                Console.ReadKey();
                Console.Clear();

                if (boss.IsLive())
                {
                    Console.WriteLine($"\n{boss.Nome} prepara seu próximo ataque...");

                    if (boss is mob4 dragao)
                    {
                        int prob = Dice.rng.Next(1, 4);

                        if (prob == 1) dragao.BiteAttack(p);
                        else if (prob == 2 || prob == 3) dragao.HeadAttack(p);
                        else dragao.PutridBreath(p);
                    }
                }

                Console.WriteLine("\n--- Fim do turno ---");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();
            if (p.IsLive())
            {
                Console.WriteLine("=== VITÓRIA ===");
                Console.WriteLine($"{p.Nome} derrotou o Ancestral Dragão Esqueleto!");
                Console.WriteLine("A dungeon silencia. Você sobreviveu para contar a história...");
            }
            else
            {
                Console.WriteLine("=== DERROTA ===");
                Console.WriteLine($"{p.Nome} foi derrotado pela criatura ancestral...");
                Console.WriteLine("Seu nome será esquecido entre as pedras frias desta tumba.");
            }

            Console.WriteLine("\n--- FIM DA AVENTURA ---");
            Console.ReadKey();
        }



        


    }

}
