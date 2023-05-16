using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    internal class Property
    {
        public string description;
        public string address;
        public string number;
        public float square_size;

        public void Acender_luz()
        {
            Console.WriteLine("Luzes Acesas" + number);
        }

        public void abrir_garagem()
        {
            Console.WriteLine("A luzes estao acesa");
        }
    }
}
