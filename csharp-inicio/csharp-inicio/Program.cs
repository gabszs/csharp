using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_inicio
{
    internal class Program
    {
        enum Menu { Soma, Subtracao, Divisao, Multiplicacao, Potencia, Raiz, Sair }

        static void Main(string[] args)
        {
            bool whileConditional = false;
            while (!whileConditional) 
            {
                Console.WriteLine("CALCULADORA: ");
                Console.WriteLine("1-Soma\n2-Subtracao\n3-Divisao\n4-Multiplicacao\n5-Potencia\n6-Raiz\n7-Sair\n");

                Menu opcao = (Menu)int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine(opcao);



                switch (opcao)

                {
                    case Menu.Soma:
                        Console.WriteLine($"\nO RESULTADO E: {Soma(GetNumber(), GetNumber())} \n");
                        break;

                    case Menu.Subtracao:
                        Console.WriteLine($"\nO RESULTADO E: {Subtracao(GetNumber(), GetNumber())} \n");
                        break;

                    case Menu.Divisao:
                        Console.WriteLine($"\nO RESULTADO E: {Divisao(GetNumber(), GetNumber())} \n");
                        break;

                    case Menu.Multiplicacao:
                        Console.WriteLine($"\nO RESULTADO E: {Multiplicacao(GetNumber(), GetNumber())} \n");
                        break;

                    case Menu.Potencia:
                        Console.WriteLine($"\nO RESULTADO E: {Potencia(GetNumber(), GetNumber())} \n");
                        break;

                    case Menu.Raiz:
                        Console.WriteLine($"\nO RESULTADO E: {Raiz(GetNumber())} \n");
                        break;

                    case Menu.Sair:
                        Console.WriteLine("\nO programa esta sendo finalizado");
                        whileConditional = true;
                        break;

                    default:
                        Console.WriteLine("\nDigite uma opcao valida\n");
                        break;
                }

            }

        }

        public static double GetNumber() 
        {
            Console.WriteLine("Digite um numero: ");
            return double.Parse(Console.ReadLine());
        }

        public static double Soma(double Num1, double Num2) 
        {
            return Num1 + Num2;
        }

        public static double Subtracao(double Num1, double Num2) 
        {
            return Num1 - Num2;
        }

        public static double Divisao(double Num1, double Num2) 
        {
            return Num1 / Num2;
        }

        public static double Multiplicacao(double Num1, double Num2) 
        {
            return Num1 * Num2;
        }

        public static double Potencia(double Num1, double Num2) 
        {
            return Math.Pow(Num1, Num2);
        }

        public static double Raiz(double Num1) 
        {
            return Math.Sqrt(Num1);
        }


    }
}
