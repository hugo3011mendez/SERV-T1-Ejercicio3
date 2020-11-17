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

        static void incremento()
        {
            while (num != 1000)
            {
                num++;
                Console.WriteLine(num + " : Hilo Suma");
            }
        }
        static void decremento()
        {
            while (num != -1000)
            {
                num--;
                Console.WriteLine(num + " : Hilo Resta");
            }
        }

        public static void Main(string[] args)
        {
                Thread hiloSuma = new Thread(incremento);
                hiloSuma.Start();

                Thread hiloResta = new Thread(decremento);
                hiloResta.Start();

                Console.ReadLine();
        }
    }
}
