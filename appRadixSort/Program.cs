using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRadixSort
{
    class Program
    {
        private int[] dato;
        private IList<IList<int>> digitos = new List<IList<int>>();
        private int tamañomax = 0;
        public Program()
        {
            for (int i = 0; i < 10; i++)

            {
                digitos.Add(new List<int>());
            }
            Console.Write("Cuantos numeros quieres ingresar : ");
            int count = int.Parse(Console.ReadLine());
            dato = new int[count];
            Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Escribe valor {0}: ", i + 1);

                dato[i] = int.Parse(Console.ReadLine());

                if (tamañomax < dato[i].ToString().Length)
                    tamañomax = dato[i].ToString().Length;
            }
        }

        public void RadixSort()
        {
            for (int i = 0; i < tamañomax; i++)
            {
                for (int j = 0; j < dato.Length; j++)
                {
                    int digit = (int)((dato[j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));

                    digitos[digit].Add(dato[j]);
                }

                int index = 0;
                for (int k = 0; k < digitos.Count; k++)
                {
                    IList<int> selDigit = digitos[k];

                    for (int l = 0; l < selDigit.Count; l++)
                    {
                        dato[index++] = selDigit[l];
                    }
                }
                LimpiarDitos();
            }
            Mostrar();
        }

        private void LimpiarDitos()
        {
            for (int k = 0; k < digitos.Count; k++)
            {
                digitos[k].Clear();
            }
        }

        public void Mostrar()
        {
            Console.WriteLine("Los numeros ordenados son : " );
            for (int i = 0; i < dato.Length; i++)
            {
                Console.WriteLine(dato[i]);
            }
        }


        static void Main(string[] args)
        {
            new Program().RadixSort();

            Console.ReadLine();

        }
    
    }
}
