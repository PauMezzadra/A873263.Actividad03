using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A873263.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            Diario unNuevoDiario = new Diario();
            unNuevoDiario.LevantarArchivo();
            unNuevoDiario.Iniciar();
            unNuevoDiario.Continuar();
            Console.ReadKey();
        }
    }
}
