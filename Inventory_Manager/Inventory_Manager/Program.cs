

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Inventory_Manager
{
    internal class Program
    {
        static List<IStock> products = new List<IStock>();
        enum Menu {  Listar, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Load();

            bool wannaQuit = false;
            while (!wannaQuit)
            {
                Console.WriteLine("Inventory Manager");

                int count = 1;
                foreach (string name in Enum.GetNames(typeof(Menu)))
                {
                    Console.WriteLine($"{count}° {name}: ");
                    count++;
                }

                Console.WriteLine("qual opcao deseja selecionar: ");
                int choice = int.Parse(Console.ReadLine()) - 1 ;
                Menu option = (Menu)choice;

                if (!(choice > -1 && choice < 6))
                {
                    Console.WriteLine("A opcao digitada esta errada");
                    Console.Read();
                    continue;
                }

                switch (option)
                {
                    case Menu.Listar:
                        List_ALL();
                        break;
                    case Menu.Adicionar:
                        Registration();
                        break;
                    case Menu.Remover:
                        Delete();
                        break;
                    case Menu.Entrada:
                        Enter();
                        break;
                    case Menu.Saida:
                        Quit();
                        break;
                    case Menu.Sair:
                        wannaQuit = true;
                        break;
                }
                        
                Console.ReadLine();
            }
        }

        static void Registration()
        {
            Console.WriteLine("\nCadastro de produtos");
            Console.WriteLine("1°- Produto Fisico: \n2°- Ebook: \n3°- Curso: ");

            int choice = int.Parse(Console.ReadLine()) - 1;   

            switch (choice) 
            {
                case 0:
                    RealProduct_Registration();
                    break;
                case 1:
                    Ebook_Registration();
                    break;
                case 2:
                    Course_Registration();
                    break;
            }
        }

        static void RealProduct_Registration()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            float price = float.Parse(Console.ReadLine());

            Console.Write("Shipping: ");
            float shipping = float.Parse(Console.ReadLine());

            RealProduct produto1 = new RealProduct(name, price, shipping);

            products.Add(produto1);
            Save();
        }

        static void Ebook_Registration()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            float price = float.Parse(Console.ReadLine());

            Console.Write("Shipping: ");
            string autor = Console.ReadLine();

            Ebook produto1 = new Ebook(name, price, autor);

            products.Add(produto1);
            Save();
        }


        static void Course_Registration() 
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            float price = float.Parse(Console.ReadLine());

            Console.Write("Shipping: ");
            string autor = Console.ReadLine();

            Course produto1 = new Course(name, price, autor);

            products.Add(produto1);
            Save();
        }


        static void Save()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, products);
            stream.Close();
        }


        static void Load()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);

        
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                products = ((List<IStock>)encoder.Deserialize(stream));

                if (products == null)
                {
                    products = new List<IStock>();
                }
            }
            catch (Exception ex)
            {
                products = new List<IStock>();
            }

            stream.Close();
        }


        static void List_ALL()
        {
            Console.WriteLine("Lista de produtos");
            for (int i = 0; i < products.Count; i++) 
            {
                Console.WriteLine($"id: {i}");
                products[i].Show();
            }
            Console.ReadLine();
        }

        static void Delete()
        {
            if (products != null)
            {

                Console.WriteLine($"IDs disponiveis: {products.Count}");

                Console.Write("Digite o id: ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < products.Count)
                {
                    products.RemoveAt(choice);
                    Save();
                }
            }
        }

        static void Enter()
        {
            if (products != null)
            {

                Console.WriteLine($"IDs disponiveis: {products.Count}");

                Console.Write("Digite o id: ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < products.Count)
                {
                    products[choice].AddStock();
                    Save();
                }
            }
        }

        static void Quit()
        {
            if (products != null)
            {

                Console.WriteLine($"IDs disponiveis: {products.Count}");

                Console.Write("Digite o id: ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < products.Count)
                {
                    products[choice].RemoveStock();
                    Save();
                }
            }
        }
    }
}
