using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;


namespace Ejercicio3
{
    class Ejercicio
    {
        static int num = 0; // Creo y declaro la variable que los hilos modificarán
        static bool flag = false; // Creo y declaro el flag

        static readonly object l = new object(); // Creo el objeto del lock, porque los dos hilos están usando recursos iguales (num y flag)

        // Creo y declaro el primer hilo, con una expresión lambda como función que indica lo que debe hacer
        static Thread hiloSuma = new Thread(() =>
        {
            while (!flag)
            {
                lock (l) // Primero lo meto dentro del lock
                {
                   // Y hago las comprobaciones y acciones pertinentes
                    if (!flag) 
                    {
                        num++;
                        Console.WriteLine(num + " : Hilo Suma");
                    }

                    if (num == 100)
                    {
                        flag = true;
                    }
                }
            }
        }
        );


        // Creo y declaro el segundo hilo, con una expresión lambda como función que indica lo que debe hacer
        static Thread hiloResta = new Thread(() =>
        {
            while (!flag)
            {
                lock (l) // Primero lo meto dentro del lock
                {
                    // Y hago las comprobaciones y acciones pertinentes
                    if (!flag)
                    {
                        num--;
                        Console.WriteLine(num + " : Hilo Resta");
                    }

                    if (num == -100)
                    {
                        flag = true;
                    }
                }
            }
        }
        );


        public static void Main(string[] args)
        {
            hiloSuma.Start();
            hiloResta.Start();

            // Uso el Join para que el hilo Main se encuentre a la espera de que uno de los otros dos hilos acaben, y como acaban a la vez no importa el hilo que se debe poner en el Join
            hiloSuma.Join();

            Console.WriteLine();

            if (num == 100)
            {
                Console.WriteLine("Gana el primer hilo!");
            }
            else if (num == -100)
            {
                Console.WriteLine("Gana el segundo hilo!");
            }

            Console.ReadLine();
        }
    }
}
