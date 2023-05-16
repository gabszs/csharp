using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInteraction
{
    internal class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;


        public void show_data()
        {
            Console.WriteLine($"Object tarefa");
            Console.WriteLine($"User id: {userId}");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Titulo: {title}");
            Console.WriteLine($"Completedr? {completed}");

        }
    }
}
