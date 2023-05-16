using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Manager
{
    [System.Serializable]
    internal class RealProduct : Product , IStock
    {
        public float shipping;
        private int stock;

        public RealProduct(string name, float price, float shipping)
        {
            this.name = name;
            this.price = price;
            this.shipping = shipping;
        }

        public void AddStock()
        {
            Console.WriteLine($"Adicionando o produto {name} no estoque");
            Console.Write($"Digite a quantidade que voce deseje dar de entrada: ");
            int enter = int.Parse(Console.ReadLine());
            this.stock += enter;
            Console.WriteLine($"{enter} produto(s) foram adicionadas.");
        }

        public void RemoveStock()
        {
            Console.WriteLine($"Retirando o produto {name} no estoque");
            Console.Write($"Digite a quantidade que voce deseje retirar: ");
            int enter = int.Parse(Console.ReadLine());
            this.stock -= enter;
            Console.WriteLine($"{enter} produto(s) foram removidos.");
        }


        public void Show()
        {
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"shipping: {shipping}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Stock: {stock}");
        }
    }
}
