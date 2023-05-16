using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Manager
{
    [System.Serializable]
    class Ebook: Product , IStock
    {
        public string autor;
        private string sales;

        public Ebook(string name, float price, string autor)
        {
            this.name = name;
            this.price = price;
            this.autor = autor; 
        }

        public void AddStock()
        {
            Console.WriteLine("Nao e possivel adicionar produtos virtuais ao estoque");
        }



        public void RemoveStock()
        {
            Console.WriteLine("Nao e possivel remover produtos virtuais ao estoque, por que produtos virtuais nao tem estoque");
        }

        public void Show()
        {
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Sales: {sales}");
        }
    }
}
