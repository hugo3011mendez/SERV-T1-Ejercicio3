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
        // a) Crea dos hilos compitiendo que traten de incrementar (el primer hilo) o decrementar (el segundo hilo) en 1 unidad una variable que comienza en 0.
        // Funcionarán de forma continua hasta que a llegue a 1000 (primer hilo) o a -1000 (segundo hilo).
        // Además se mostrará en pantalla la variable a cada vez que cambie indicando quién la ha cambiado(thread 1 o thread 2).
        // Ambos hilos deben parar en cuanto uno consiga su objetivo.

        // b) Las funciones de hilos serán expresiones lambda (si quieres y los ves claro haz ya directamente este apartado).

        static int num = 0; // Creo y declaro la variable que los hilos modificarán
        static bool flag = false; // Creo y declaro el flag

        static readonly object l = new object(); // Creo el objeto del lock, porque los dos hilos están usando recursos iguales (num y flag)

        // Creo y declaro el primer hilo, con una expresión lambda como función que indica lo que debe hacer
        static Thread hiloSuma = new Thread(() =>
        {
            lock (l)
            {
                if (!flag)
                {
                    while (num != 10)
                    {
                        num++;
                        Console.WriteLine(num + " : Hilo Suma");
                    }

                    if (num == 10)
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
            lock (l)
            {
                if (!flag)
                {
                    while (num != -10)
                    {
                        num--;
                        Console.WriteLine(num + " : Hilo Resta");
                    }

                    if (num == -10)
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

            if (num == 10)
            {
                Console.WriteLine("Gana el primer hilo!");
            }
            else if (num == -10)
            {
                Console.WriteLine("Gana el segundo hilo!");
            }

            Console.ReadLine();
        }
    }
}
