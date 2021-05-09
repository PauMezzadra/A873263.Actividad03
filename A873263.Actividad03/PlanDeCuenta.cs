using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A873263.Actividad03
{
    class PlanDeCuenta
    {
        const string planDeCuenta = "PlanDeCuentas.txt";
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        List<PlanDeCuenta> planes = new List<PlanDeCuenta>();

        public PlanDeCuenta(string linea)
        {
            var datos = linea.Split('|');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
            Tipo = datos[2];
        }

        public PlanDeCuenta()
        {
        }

        public void Levantar()
        {
            if (File.Exists(planDeCuenta))
            {
                using (var reader = new StreamReader(planDeCuenta))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Codigo|Nombre|Tipo")
                        {
                            continue;
                        }
                        else
                        {
                            var unPlan = new PlanDeCuenta(linea);
                            planes.Add(unPlan);
                        }
                    }
                }
            }
        }

        public void ListarPlan()
        {
            Console.WriteLine("****************\nPLAN DE CUENTAS:\n****************");
            foreach (PlanDeCuenta plan in planes)
            {
                Console.WriteLine($"Código = {plan.Codigo} - {plan.Nombre}");
            }
        }

        public bool BuscarCodigo(int unCodigo)
        {
            int posicion = 0;
            bool encontrado = false;
            while (posicion < planes.Count && !encontrado)
            {
                if (planes[posicion].Codigo == unCodigo)
                {
                    encontrado = true;
                }
                else
                {
                    posicion++;
                }
            }
            return encontrado;
        }
    }
}
