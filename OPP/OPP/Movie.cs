using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    interface IMovie
    {
        string get_title();
        string compare_movie(string movieName);

    }
    internal class Movie : IMovie
    {
        public string titulo;
        public string sinopse;
        public int ano;
        public string studio;
        public string genero;
        public List<string> atores = new List<string>();

        public Movie(string titulo, string sinopse, int ano, string studio, string genero, List<string> atores) 
        {
            this.titulo = titulo;
            this.sinopse = sinopse;
            this.ano = ano;
            this.studio = studio;
            this.genero = genero;
            this.atores = atores;
        }

        public void Executar()
        {
            Console.WriteLine("Rodando filme: " + titulo);
        }

        public void Pausar()
        {
            Console.WriteLine("||");
        }

        public static void somar(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public string get_title()
        {
            return titulo;  
        }
        public string compare_movie(string movieName)
        {
            return $"O filme {titulo} esta sendo comparado com {movieName}";
        }


    }
    //class Serie : Movie
    //{

    //}
}
