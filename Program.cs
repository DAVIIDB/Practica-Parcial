using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica_Parcial_WaitAny
{
    class Program
    {
        static void MetodoA()
        {
            Thread.SpinWait(int.MaxValue/2);
            Console.WriteLine("Metodo A");

        }

        static void MetodoB()
        {
            Thread.SpinWait(int.MaxValue);
            Console.WriteLine("Metodo B");


        }


        static void Main(string[] args)
        {

            var t1 = new Task.Factory.StartNew(MetodoA);

            var t2 = new Task.Factory.StartNew(MetodoB);

            var tareas = new Task[] { t1, t2};

            Console.WriteLine("La tarea 1 tiene el id.:"+t1.Id);

            Console.WriteLine("La tarea 2 tiene el id.:"+t2.Id);

            int cualt = Task.WaitAny(tareas);

            Console.WriteLine("La tarea de oro es:",tareas[cualt].Id);

            Console.WriteLine("Presione enter para finalizar");

            Console.ReadLine();

        }
    }
}

namespace Task.Factory
{
    class StartNew
    {
        private Action metodoA;

        public StartNew(Action metodoA)
        {
            this.metodoA = metodoA;
        }
    }
}