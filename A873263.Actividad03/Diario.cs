using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace A873263.Actividad03
{
    class Diario
    {
        const string diario = "Diario.txt";
        public int NroAsiento { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoCuenta { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }

        List<Diario> unDiario = new List<Diario>();
        List<Diario> asiento = new List<Diario>();

        public Diario()
        {
        }

        public Diario(int elNro, DateTime laFecha, int elCodigoCuenta, decimal elDebe, decimal elHaber)
        {
            NroAsiento = elNro;
            Fecha = laFecha;
            CodigoCuenta = elCodigoCuenta;
            Debe = elDebe;
            Haber = elHaber;
        }

        public void LevantarArchivo()
        {
            if (File.Exists(diario))
            {
                using (var reader = new StreamReader(diario))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        if (linea == "NroAsiento|Fecha|CodigoCuenta|Debe|Haber")
                        {
                            continue;
                        }
                        else
                        {
                            var elDiario = new Diario(linea);
                            unDiario.Add(elDiario);
                        }
                    }
                }
            }
        }

        public Diario(string linea)
        {
            var datos = linea.Split('|');
            NroAsiento = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            CodigoCuenta = int.Parse(datos[2]);
            Debe = decimal.Parse(datos[3]);
            Haber = decimal.Parse(datos[4]);
        }

        public void Grabar()
        {
           
            using (var writer = new StreamWriter(diario, append: false))
            {
                writer.WriteLine("NroAsiento|Fecha|CodigoCuenta|Debe|Haber");
                foreach (var diar in unDiario)
                {
                    var linea = diar.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }
            }
        }
        private object ObtenerLineaDatos() => $"{NroAsiento}|{Fecha}|{CodigoCuenta}|{Debe}|{Haber}";

        public int ProximoNroAsiento()
        {
            int proximoAsiento;
            if (unDiario.Count == 0)
            {
                proximoAsiento = 1;
            }
            else
            {
                proximoAsiento = (unDiario[unDiario.Count - 1].NroAsiento) + 1;
            }
            return proximoAsiento;
        }

        public void Iniciar()
        {
            const string opcionDebe = "D";
            const string opcionHaber = "H";
            const string opcionSalir = "F";

            string opcionMenu = "";
            int nroAsiento;
            DateTime laFecha;
            int codigoCuenta;
            decimal elMonto;
            decimal totalDebe = 0;
            decimal totalHaber = 0;
            Diario nuevoDiario;
            PlanDeCuenta unPlan = new PlanDeCuenta();
            unPlan.Levantar();

            Console.WriteLine("********************\nINGRESO DE ASIENTOS:\n********************\n");
            laFecha = Validaciones.PedirFecha("Ingrese la fecha del asiento que desea cargar:");
            nroAsiento = ProximoNroAsiento();
            do
            {
                opcionMenu = Validaciones.PedirStrNoVac("Presione:\n\tD - Para cargar en el DEBE" +
                                                        "\n\tH - Para cargar en el HABER" +
                                                        "\n\tF - Para finalizar la carga del asiento actual\n");

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
                        nuevoDiario = new Diario(nroAsiento, laFecha, codigoCuenta, elMonto, 0);
                        asiento.Add(nuevoDiario);

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
                        nuevoDiario = new Diario(nroAsiento, laFecha, codigoCuenta, 0, elMonto);
                        asiento.Add(nuevoDiario);

                        break;

                    case opcionSalir:

                        foreach (Diario dia in asiento)
                        {
                            if (dia.NroAsiento == nroAsiento)
                            {
                                totalDebe = totalDebe + dia.Debe;
                            }
                        }

                        foreach (Diario dia in asiento)
                        {
                            if (dia.NroAsiento == nroAsiento)
                            {
                                totalHaber = totalHaber + dia.Haber;
                            }
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
                            Console.WriteLine("\nEste Asiento no puede guardarse.");

                            asiento.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ud. ha cargado el siguiente asiento diario:\n");
                            Console.WriteLine("NroAsiento |       Fecha         |CodigoCuenta |    Debe    |     Haber    |\n");
                            foreach (Diario d in asiento)
                            {
                                if (d.Fecha == laFecha)
                                {
                                    Console.WriteLine($" {d.NroAsiento}         | {d.Fecha} |     {d.CodigoCuenta}       |      {d.Debe}     |   {d.Haber}");
                                }
                            }
                            Console.WriteLine();
                            foreach (Diario d in asiento)
                            {
                                unDiario.Add(d);
                            }
                            asiento.Clear();
                        }
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            } while (opcionMenu != opcionSalir);
        }

        public void Continuar()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Desea seguir cargando asientos? S / N\n");
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.N)
                {
                    Grabar();
                    Console.WriteLine("Aplicación finalizada. Presione cualquier tecla para salir.");
                }
                else if (key.Key == ConsoleKey.S)
                {
                    asiento.Clear();
                    Iniciar();
                }

            } while (key.Key == ConsoleKey.S);
        }
    }
}
