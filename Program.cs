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
            Mob zumbi = new Mob("zumbi");
            Console.WriteLine("O zumbi tem ac de: " + zumbi.AC);

            Console.ReadKey();

        }
    }
}
