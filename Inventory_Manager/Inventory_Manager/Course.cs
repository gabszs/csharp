using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Manager
{
    [System.Serializable]
    class Course : Product, IStock
    {
        public string autor;
        private int seat_available;

        public Course(string name, float price, string autor)
        {
            this.name = name;
            this.price = price;
            this.autor = autor;
        }

        public void AddStock()
        {
            Console.WriteLine($"Adicionando vagas no {name}");
            Console.Write($"Digite a quantidade que voce deseje dar de entrada: ");
            int enter = int.Parse(Console.ReadLine());
            this.seat_available += enter;
            Console.WriteLine($"{enter} produto(s) foram adicionadas.");
        }

        public void RemoveStock()
        {
            Console.WriteLine($"Removendo vagas no {name}");
            Console.Write($"Digite a quantidade que voce deseje remover: ");
            int enter = int.Parse(Console.ReadLine());
            this.seat_available -= enter;
            Console.WriteLine($"{enter} produto(s) foram removidos.");
        }



        public void Show()
        {
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Seats available: {seat_available}");
        }
    }
}
