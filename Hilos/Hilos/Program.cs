using System;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Hilos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Thread hilo1 = new Thread(MetodoPorEjecutar);
            Thread hilo2 = new Thread(MetodoPorEjecutar);
            Console.WriteLine("La cultura del hilo principal es: {0} ",Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("Voy a ejecutar el hilo 1");
            hilo1.Start();
            Console.WriteLine("Voy a ejecutar el hilo 2");
            hilo2.Start();
            //El hilo principal se duerme
            Thread.Sleep(1000);
            //Join junta los dos hilos al principal
            hilo1.Join();
            hilo2.Join();
            Console.WriteLine("El hilo 1 se junta");
            Console.WriteLine("El hilo 2 se junta");*/

            //CARRERA DE PERSONAS USANDO HILOS
            Thread corredor1 = new Thread(Carreras.Corredor);
            Thread corredor2 = new Thread(Carreras.Corredor);
            Thread corredor3 = new Thread(Carreras.Corredor);
            Thread corredor4 = new Thread(Carreras.Corredor);

            corredor1.Start("Pedro");
            corredor2.Start("Tito");
            corredor3.Start("Juan");
            corredor4.Start("Kevin");

            corredor1.Join();
            corredor2.Join();
            corredor3.Join();
            corredor4.Join();

        }
        static void MetodoPorEjecutar()
        {
            var hiloActual = Thread.CurrentThread;
            hiloActual.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine("Hilo Actual: {0}:", hiloActual.ManagedThreadId);
            Console.WriteLine("Mi cultura es: {0}:", hiloActual.CurrentCulture);
            var random = new Random();
            for (int i=0; i<5;i++)
            {
                Console.WriteLine("La identidad del hilo es:{0} indice {1}", hiloActual,i);
                Thread.Sleep(random.Next(100, 500));
            }
        }
    }
}
