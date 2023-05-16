using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetInteraction
{
    internal class Program
    {
        enum Menu { Exibir_Todos, Search_Id, Quit };
        static void Main(string[] args)
        {
            bool wannaQuit = false;

            while (!wannaQuit)
            {
                int count = 1;
                foreach (var opt in Enum.GetValues(typeof(Menu))) { Console.WriteLine($"{count}* {opt}: "); ; }
                count++;

                Console.Write("Digite a opcao: ");
                int choice_id = int.Parse(Console.ReadLine()) - 1;
                Menu option = (Menu)choice_id;

                switch (option)
                {
                    case Menu.Exibir_Todos:
                        GetAll();
                        break;
                    case Menu.Search_Id:
                        Console.Write("Digite o ID: ");
                        GetById(int.Parse(Console.ReadLine()));
                        break;
                    case Menu.Quit:
                        break;
                }
            }
        }


        static void GetById(int Id)
        {
            var request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/" + Id);
            request.Method = "get";

            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                object dados = reader.ReadToEnd();

                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());

                tarefa.show_data();
            }
        }

        static void GetAll() 
        {
            var request = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            request.Method = "get";


            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                object dados = reader.ReadToEnd();

                List<Tarefa> tarefa = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                Console.WriteLine(tarefa);
                //JsonConverter.DeserializeObject < List<Tarefa>;


                foreach (Tarefa task in tarefa)
                {
                    task.show_data();
                    Console.WriteLine("------------------");
                }


                stream.Close();
                response.Close();


            }
        }
    }
}
