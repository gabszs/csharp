using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using static Structs.Program;
using System.Runtime.InteropServices.ComTypes;

namespace Structs
{
    internal class Program
    {
        public enum Menu { Listagem, Adicionar, Remover, Sair }
        public enum ListagemEnum { Pesquisar, MostrarTodos, Sair }

        [System.Serializable]
        public struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
            public int id;

            public Cliente (string nome, string email, string cpf, int id)
            {
                this.nome = nome;
                this.email = email;
                this.cpf = cpf;
                this.id = id;
            }

            public string displayInfo()
            {
                string texto = ($"As informacoes sao, o ID: {this.id}, Nome: {this.nome}, Email: {this.email}, CPF: {this.cpf}");
                return texto;
            }
        }

        public static List<Cliente> list_clientes = new List<Cliente>();

        

        public static void Main(string[] args) 
        {
            list_clientes = Carregar();

            //Cliente cliente1 = new Cliente("Gabriel", "gabrielizaac2020@gmail.com", "3680056230", 01);
            //Cliente cliente2 = new Cliente("evalon", "evealonm@gmail.com", "595641052", 02);
            //Cliente cliente3 = new Cliente("eve", "taeig@gmail.com", "27022002", 03);
            //Cliente cliente4 = new Cliente("hads", "hadas@gmail.com", "07062020", 04);

            //list_clientes.Add(cliente1); list_clientes.Add(cliente2); list_clientes.Add(cliente3); list_clientes.Add(cliente4);


            bool loopWhile = false;
            while (!loopWhile)
            {
                Console.WriteLine("MENU");
                foreach (int item in Enum.GetValues(typeof(Menu)))
                {
                    Console.WriteLine($"{item + 1}* {(Menu)item}:");
                }
                Console.Write("Digite sua opcao: ");
                int intMenu = int.Parse(Console.ReadLine()) - 1;
                Menu opcao = (Menu)intMenu;

                switch (opcao)
                {
                    case Menu.Listagem:
                        Listagem(list_clientes);
                        break;

                    case Menu.Adicionar:
                        list_clientes = Adicionar(list_clientes);
                        break;

                    case Menu.Remover:
                        if (list_clientes.Count > 0)
                        {
                            Console.WriteLine($"ha {list_clientes.Count()} posicoes na lista");
                            Console.Write($"Digite a posicao que deseja remover: ");
                            int position = int.Parse(Console.ReadLine()) - 1;
                            list_clientes = Delete(list_clientes, position);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nao ha clientes na lista");
                            Console.ReadLine();
                            break;
                        }



                    case Menu.Sair:
                        loopWhile = true;
                        Console.WriteLine("O pragrama esta sendo finalizado!!");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
        }

        public static void Save(List<Cliente> list_clientes)
        {
            FileStream stream = new FileStream("clients.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, list_clientes);

            stream.Close();
        }

        public static List<Cliente> Carregar()
        {
            FileStream stream = new FileStream("clients.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter enconder = new BinaryFormatter();

                list_clientes = (List<Cliente>)enconder.Deserialize(stream);

                if (list_clientes == null)
                {
                    list_clientes = new List<Cliente>();
                }
            }
            catch (Exception ex)
            {
                list_clientes = new List<Cliente>();
            }

            stream.Close();
            return list_clientes;


        }

        public static List<Cliente> Adicionar(List<Cliente> list_clientes)
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o email do cliente: ");
            string email = Console.ReadLine();
            Console.Write("Digite o cpf do cliente: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite o id do cliente: ");
            int id = int.Parse(Console.ReadLine());


            Cliente cliente = new Cliente(nome, email, cpf, id);
            list_clientes.Add(cliente);
            Save(list_clientes);

            return list_clientes;
        }

        public static List<Cliente> Delete(List<Cliente> list_clientes, int position) 
        {
            if (list_clientes.Count() == 0)
            {
                Console.WriteLine($"Nao ha cliente na lista, a lista esta vazia");
                Console.ReadLine();
            }
            else if (position < 0 && position > list_clientes.Count)
            {
                Console.WriteLine("O id digitado esta errado");
            }
            else
            {
                try
                {
                    Console.WriteLine(list_clientes);
                    list_clientes.RemoveAt(position);
                    Save(list_clientes);
                }
                catch (Exception)
                {   
                    Console.WriteLine($"A posicao informada nao existe");
                    Console.ReadLine();
                }
            }
            return list_clientes;

        }

        public static void Listagem(List<Cliente> list_cliente)
        {
            Console.WriteLine("Digite 1 para listar todos os CLiente cadastrados ou 2 se deseje procurar por id: ");
            int intChoice = int.Parse(Console.ReadLine());

            if (intChoice == 1)
            {
                showAll(list_clientes);
            }
            else if ( intChoice == 2) 
            {
                Console.Write("digite o ID: ");
                int id_number = int.Parse(Console.ReadLine());
                var cliente_rtn = findById(list_clientes, id_number);
                string conditional = cliente_rtn[0].ToString();

                if (conditional == "False")
                {
                    Console.WriteLine("O id nao existe");
                }
                else
                {
                    Console.WriteLine(cliente_rtn[1]);
                }
                Console.ReadLine();
            }
        }

        public static void showAll (List<Cliente> list_clientes)
        {
            for (int count = 0; count < list_clientes.Count; count++)
            {
                Cliente cliente = list_clientes[count];
                Console.WriteLine($"O {count + 1}* cliente cadastrado e:");
                Console.WriteLine($"Id: {cliente.id}, Nome: {cliente.nome}, Email: {cliente.email}, CPF: {cliente.cpf}");
            }
            Console.ReadLine();
        }

        public static ArrayList findById(List<Cliente> list_clientes, int id_number)
        {
            Cliente clienteF = new Cliente();
            bool found = false;
            ArrayList list = new ArrayList() { false};
            
            foreach (Cliente cliente in list_clientes)
            {
                if (cliente.id == id_number)
                {
                    clienteF =  cliente;
                    found = true; 
                    break;

                }
            }

            if (!found)
            {
                //Console.WriteLine("false na func");
                return list;
            }
            else 
            {
                //Console.WriteLine($"{clienteF.displayInfo()}");
                list[0] = true;
                list.Add(clienteF.displayInfo());
                return list;
            }
        }



    }
}
