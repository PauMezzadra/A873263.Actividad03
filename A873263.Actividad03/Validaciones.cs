using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace A873263.Actividad03
{
    static class Validaciones
    {
        public static string PedirStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("No puede ser vacío");
                }
                valor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(valor.ToLower());
            } while (valor == "");

            return valor;
        }

        public static int PedirInt(string mensaje)
        {
            int valor;
            bool valido = false;
            string mensError = "Debe ingresar un número";

            do
            {
                Console.WriteLine(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            return valor;
        }

        public static decimal PedirDecimal(string mensaje)
        {
            decimal valor;
            bool valido = false;
            string mensError = "Debe ingresar un número";

            do
            {
                Console.WriteLine(mensaje);
                if (!decimal.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else if (valor < 1)
                {
                    Console.WriteLine("El valor a ingresar no debe ser menor a 1");
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            return valor;
        }

        public static DateTime PedirFecha(string mensaje)
        {
            DateTime valor;
            bool valido = false;
            string mensError = "Debe ingresar una fecha con formato dd/mm/aaaa";

            do
            {
                Console.WriteLine(mensaje);
                if (!DateTime.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine(mensError);
                }
                else if (valor > DateTime.Now)
                {
                    Console.WriteLine("La fecha no puede ser posterior al día de hoy");
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            return valor;
        }
    }
}
