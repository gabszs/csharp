using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> character = new List<string>() { "ryan gosling", "crianca mexicana", "mulher mexicana", "marido agressivo da mulher mexicana"};
            Movie filme = new Movie("Driver", "Ryan gosling apenas", 2012, "Paramount", "ryan gosling movies", character);

            Console.WriteLine(filme);
            Console.WriteLine(filme.atores[0]);
            Console.WriteLine(filme.ano);

            Console.ReadLine();
        }
    }
}

