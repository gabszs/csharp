using lojaDominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace IntroducaoLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produto prod = new Produto();
            List<Produto> prod_list = prod.ListarFrutas();
            List<Produto> prod_lst = prod.ListarLegumes();
            List<Produto2> list_prod = new List<Produto2>()
            {
                new Produto2("iphone 12 ", 11000, "apple"),
                new Produto2("iphone11 ", 10000, "apple"),
                new Produto2("galaxy s7", 5000, "samsung"),
                new Produto2("playstation 5", 4300, "sony"),
                new Produto2("xbox one", 3900, "microsoft"),
                new Produto2("lenovo s145", 3000, "lenovo"),
                new Produto2("iphone", 2000, "apple"),
            };
            
            List<Produto> produtos = new List<Produto>();
            produtos.AddRange(prod_lst);
            produtos.AddRange(prod_list);
            
            produtos.ForEach(x =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(x));
            });
            

            Console.ReadLine();

        }
    }
}
