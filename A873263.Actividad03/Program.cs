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
            unNuevoDiario.Iniciar();
            Console.ReadKey();
            /*const string opcionDebe = "D";
            const string opcionHaber = "H";
            const string opcionSalir = "S";

            string opcionMenu = "";
            int nroAsiento;
            DateTime laFecha;
            int codigoCuenta;
            decimal elMonto;
            decimal totalDebe = 0;
            decimal totalHaber = 0;
            Diario nuevoDiario = new Diario() ;
            List<Diario> unDiario = new List<Diario>();
            PlanDeCuenta unPlan = new PlanDeCuenta();
            unPlan.Levantar();
            nuevoDiario.LevantarArchivo();

            Console.WriteLine("********************\nINGRESO DE ASIENTOS:\n********************\n");
            laFecha = Validaciones.PedirFecha("Ingrese la fecha del asiento que desea cargar:");
            do
            {
                opcionMenu = Validaciones.PedirStrNoVac("Presione:\n\tD - Para cargar en el DEBE" +
                                                        "\n\tH - Para cargar en el HABER" +
                                                        "\n\tS - Para Salir de la carga de datos");

                switch (opcionMenu)
                {
                    case opcionDebe:
                        unPlan.ListarPlan();
                        Console.WriteLine();
                        do
                        {
                            codigoCuenta = Validaciones.PedirInt("Ingrese el Código de la cuenta en la que desea cargar:");
                            if (!unPlan.BuscarCodigo(codigoCuenta))
                            {
                                Console.WriteLine("El código ingresado no se encuentra en el Plan de Cuentas");
                            }
                        } while (!unPlan.BuscarCodigo(codigoCuenta));
                        elMonto = Validaciones.PedirDecimal("Ingrese el monto que desea cargar:");
                        nroAsiento = nuevoDiario.BuscarAsiento(1);
                        nuevoDiario = new Diario(nroAsiento, laFecha, codigoCuenta, elMonto, 0);
                        unDiario.Add(nuevoDiario);

                        break;

                    case opcionHaber:
                        unPlan.ListarPlan();
                        Console.WriteLine();
                        do
                        {
                            codigoCuenta = Validaciones.PedirInt("Ingrese el Código de la cuenta en la que desea cargar:");
                            if (!unPlan.BuscarCodigo(codigoCuenta))
                            {
                                Console.WriteLine("El código ingresado no se encuentra en el Plan de Cuentas");
                            }
                        } while (!unPlan.BuscarCodigo(codigoCuenta));
                        elMonto = Validaciones.PedirDecimal("Ingrese el monto que desea cargar:");
                        nroAsiento = nuevoDiario.BuscarAsiento(1); ;
                        nuevoDiario = new Diario(nroAsiento, laFecha, codigoCuenta, 0, elMonto);
                        unDiario.Add(nuevoDiario);

                        break;

                        case opcionSalir:

                        foreach (Diario dia in unDiario)
                        {
                            totalDebe = totalDebe + dia.Debe;
                        }

                        foreach (Diario dia in unDiario)
                        {
                            totalHaber = totalHaber + dia.Haber;
                        }

                        if (totalDebe != totalHaber)
                        {
                            if (totalDebe > totalHaber)
                            {
                                Console.WriteLine($"El DEBE tiene cargados ${totalDebe - totalHaber} más que el Haber.");
                            }
                            else
                            {
                                Console.WriteLine($"El HABER tiene cargados ${totalHaber - totalDebe} más que el Debe.");
                            }
                            Console.WriteLine("Este Asiento no puede guardarse.");
                        }
                        else
                        {
                            nuevoDiario.Grabar();
                            Console.WriteLine("El Asiento ha sido grabado con éxito");

                            foreach (Diario diar in unDiario)
                            {
                                Console.WriteLine($"Nro Asiento: {diar.NroAsiento} - Fecha: {diar.Fecha} - Código Cuenta: {diar.CodigoCuenta} " +
                                                    $"- Debe: {diar.Debe} - Haber: {diar.Haber}");
                            }
                            Console.WriteLine($"Total Debe: {totalDebe}");
                            Console.WriteLine($"Total Haber: {totalHaber}");
                        }

                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }


            } while (opcionMenu != opcionSalir);*/

        }
    }
}
