// See https://aka.ms/new-console-template for more information

   using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace ServiciosPublicos
{
    class Program
    {

        int numeropagos = 0;
        int[] numPago = new int[10];
        string[] fecha = new string[10];
        string[] hora = new string[10];
        string[] cedula = new string[10];
        string[] nombre = new string[10];
        string[] apellido1 = new string[10];
        string[] apellido2 = new string[10];
        int[] numCaja = new int[10];
        int[] tipoServicio = new int[10];
        string[] numFactura = new string[10];
        double[] montoPagar = new double[10];
        double[] montoComision = new double[10];
        double[] montoDeducido = new double[10];
        double[] montoPagaCliente = new double[10];
        double[] vuelto = new double[10];

        void InicializarVectores()
        {
            numeropagos = 0;
            Console.WriteLine("Vectores inicializados.");
        }


        void RealizarPagos()
        {
                if (numeropagos < 10)
                {
                
                  Boolean validar = false;
                    do
                    {
                        try
                        {
                        Console.Write("Ingrese la fecha (dd/mm/yyyy): ");
                        fecha[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese la hora (hh:mm:ss): ");
                        hora[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese la cédula: ");
                        cedula[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese el nombre: ");
                        nombre[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese el apellido 1: ");
                        apellido1[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese el apellido 2: ");
                        apellido2[numeropagos] = Console.ReadLine();
                        numCaja[numeropagos] = new Random().Next(1, 3);
                        Console.Write("Ingrese el tipo de servicio (1=Luz, 2=Teléfono, 3=Agua): ");
                        tipoServicio[numeropagos] = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese el número de factura: ");
                        numFactura[numeropagos] = Console.ReadLine();
                        Console.Write("Ingrese el monto a pagar: ");
                        montoPagar[numeropagos] = Convert.ToDouble(Console.ReadLine());
                        validar = false;
                        double comision;
                        switch (tipoServicio[numeropagos])
                        {
                            case 1:
                                comision = montoPagar[numeropagos] * 0.04;
                                break;
                            case 2:
                                comision = montoPagar[numeropagos] * 0.055;
                                break;
                            default:
                                comision = montoPagar[numeropagos] * 0.065;
                                break;
                        }

                        montoComision[numeropagos] = comision;
                        montoDeducido[numeropagos] = montoPagar[numeropagos] - comision;

                        Console.Write("Ingrese el monto pagado por el cliente: ");
                        montoPagaCliente[numeropagos] = Convert.ToDouble(Console.ReadLine());

                        while (montoPagaCliente[numeropagos] < montoPagar[numeropagos])
                        {
                            Console.Write("El monto pagado por el cliente debe ser mayor o igual al monto a pagar. Ingrese nuevamente: ");
                            montoPagaCliente[numeropagos] = Convert.ToDouble(Console.ReadLine());
                        }

                        vuelto[numeropagos] = montoPagaCliente[numeropagos] - montoPagar[numeropagos];
                        numeropagos++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;
                        
                    }

                    } while (validar);

                }
            else
                {
                    Console.WriteLine("Vectores llenos.");
                }

        }

        void ConsultarPagos()
        {
            Boolean Continuar = true;
            do
            {
                Boolean validar = false;
                do
                {
                    try
                    {



                        Console.Write("Ingrese el número de pago: ");
                        numeropagos = int.Parse(Console.ReadLine());
                        validar = false;

                        if (numeropagos > 0 && numeropagos <= numPago.Length && numeropagos <= fecha.Length && numeropagos
                      <= hora.Length && numeropagos <= cedula.Length && numeropagos <= nombre.Length && numeropagos <= apellido1.Length
                      && numeropagos <= apellido2.Length && numeropagos <= numCaja.Length && numeropagos <= tipoServicio.Length
                      && numeropagos <= numFactura.Length && numeropagos <= montoPagar.Length && numeropagos <= montoComision.Length
                      && numeropagos <= montoDeducido.Length && numeropagos <= montoPagaCliente.Length && numeropagos <= vuelto.Length)
                        {
                    // Limpia la consola y imprime lo que se pide
                    Console.Clear();
                    Console.WriteLine($"Numero de Pago : {numPago[numeropagos - 1]}");
                    Console.WriteLine($"Fecha : {fecha[numeropagos - 1]}");
                    Console.WriteLine($"Hora : {hora[numeropagos - 1]}");
                    Console.WriteLine($"Cedula : {cedula[numeropagos - 1]}");
                    Console.WriteLine($"Nombre : {nombre[numeropagos - 1]}");
                    Console.WriteLine($"Apellido1 : {apellido1[numeropagos - 1]}");
                    Console.WriteLine($"Apellido1 : {apellido2[numeropagos - 1]}");
                    Console.WriteLine($"numero de caja : {numCaja[numeropagos - 1]}");
                    Console.WriteLine($"Tipo de servicio : {tipoServicio[numeropagos - 1]}");
                    Console.WriteLine($"Numero de factura: {numFactura[numeropagos - 1]}");
                    Console.WriteLine($"Monto a pagar : {montoPagar[numeropagos - 1]}");
                    Console.WriteLine($"Monto de comision : {montoComision[numeropagos - 1]}");
                    Console.WriteLine($"Deduccion : {montoDeducido[numeropagos - 1]}");
                    Console.WriteLine($"Monto a pagado por el cliente : {montoPagaCliente[numeropagos - 1]}");
                    Console.WriteLine($"Vuelto : {vuelto[numeropagos - 1]}");
                }

                else if (numeropagos != 0)
                {
                    // Mensaje de error
                    Console.WriteLine("Número de pago no válido. Inténtelo de nuevo.");
                }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);
                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);
            } while (Continuar);
           
        }

        void ModificarPagos()
        {
            Boolean Continuar = true;
            do
            {
                                Boolean validar = false;
                do
                {
                    try
                    {
                Console.Clear();
                if (numeropagos == 0)
                {
                    Console.WriteLine("No hay pagos registrados.");
                }
                else
                {
                            Console.Write("Ingrese el número de pago a modificar: ");
                    int numPagoModificar = Convert.ToInt32(Console.ReadLine());
                    bool encontrado = false;
                    for (int i = 0; i < numeropagos; i++)
                    {
                        //inicia en 0
                        if (numPago[i] == numPagoModificar)
                        {
                            Console.Clear();
                            Console.Write("Ingrese la nueva fecha (dd/mm/yyyy): ");
                            fecha[i] = Console.ReadLine();
                            Console.Write("Ingrese la nueva hora (hh:mm:ss): ");
                            hora[i] = Console.ReadLine();
                            Console.Write("Ingrese la nueva cédula: ");
                            cedula[i] = Console.ReadLine();
                            Console.Write("Ingrese el nuevo nombre: ");
                            nombre[i] = Console.ReadLine();
                            Console.Write("Ingrese el nuevo apellido 1: ");
                            apellido1[i] = Console.ReadLine();
                            Console.Write("Ingrese el nuevo apellido 2: ");
                            apellido2[i] = Console.ReadLine();
                            Console.Write("Ingrese el nuevo tipo de servicio (1=Luz, 2=Teléfono, 3=Agua): ");
                            tipoServicio[i] = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Ingrese el nuevo número de factura: ");
                            numFactura[i] = Console.ReadLine();
                            Console.Write("Ingrese el nuevo monto a pagar: ");
                            montoPagar[i] = Convert.ToDouble(Console.ReadLine());

                            double comision;
                            switch (tipoServicio[i])
                            {
                                case 1:
                                    comision = montoPagar[i] * 0.04;
                                    break;
                                case 2:
                                    comision = montoPagar[i] * 0.055;
                                    break;
                                default:
                                    comision = montoPagar[i] * 0.065;
                                    break;
                            }

                            montoComision[i] = comision;
                            montoDeducido[i] = montoPagar[i] - comision;

                            Console.Write("Ingrese el nuevo monto pagado por el cliente: ");
                            montoPagaCliente[i] = Convert.ToDouble(Console.ReadLine());

                            while (montoPagaCliente[i] < montoPagar[i])
                            {
                                Console.Write("El monto pagado por el cliente debe ser mayor o igual al monto a pagar. Ingrese nuevamente: ");
                                montoPagaCliente[i] = Convert.ToDouble(Console.ReadLine());
                            }
                           validar = false;
                           vuelto[i] = montoPagaCliente[i] - montoPagar[i];

                            encontrado = true;
                            break;
                        }//
                    }//
                    if (!encontrado)
                    {
                        Console.WriteLine("Número de pago no encontrado.");
                    }//
                }//
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);


                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);
                //
            } while (Continuar);
        }

        void EliminarPagos()
        {
            Console.Clear();
            Boolean Continuar = true;
            do
            {

                Boolean validar = false;
                do
                {
                    try
                    {


                        Console.Clear();


                        
                if (numeropagos == 0)
                {
                    Console.WriteLine("No hay pagos registrados.");
                }
                else
                {
                    Console.Write("Ingrese el número de pago a eliminar: ");
                    int numPagoEliminar = Convert.ToInt32(Console.ReadLine());
                    validar = false;
                    bool encontrado = false;
                    for (int i = 0; i < numeropagos; i++)
                    {
                        if (numPago[i] == numPagoEliminar)
                        {
                            for (int j = i; j < numeropagos - 1; j++)
                            {
                                numPago[j] = numPago[j + 1];
                                fecha[j] = fecha[j + 1];
                                hora[j] = hora[j + 1];
                                cedula[j] = cedula[j + 1];
                                nombre[j] = nombre[j + 1];
                                apellido1[j] = apellido1[j + 1];
                                apellido2[j] = apellido2[j + 1];
                                numCaja[j] = numCaja[j + 1];
                                tipoServicio[j] = tipoServicio[j + 1];
                                numFactura[j] = numFactura[j + 1];
                                montoPagar[j] = montoPagar[j + 1];
                                montoComision[j] = montoComision[j + 1];
                                montoDeducido[j] = montoDeducido[j + 1];
                                montoPagaCliente[j] = montoPagaCliente[j + 1];
                                vuelto[j] = vuelto[j + 1];
                            }
                            numeropagos--;
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("Número de pago no encontrado.");
                    }
                }
                
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);


                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);
            } while (Continuar);
        }

        void Submenu_Reportes()
        {
            Console.Clear();
            Boolean validar = false;
            do
            {
                try
                {
                    while (true)
            {
                Console.WriteLine("1. Ver todos los pagos");
                Console.WriteLine("2. Ver pagos por tipo de servicio");
                Console.WriteLine("3. Ver pagos por código de caja");
                Console.WriteLine("4. Ver dinero comisionado por servicios");
                Console.WriteLine("5 Regresar al menú principal");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                        validar = false;
                switch (opcion)
                {
                    case 1:
                        mostrarPagos();
                        break;

                    case 2:
                        pagosTipoServicio();
                        break;

                    case 3:
                        pagosCodigoCaja();
                       
                        break;
                    case 4:
                        dineroComisionado();
 
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
                }
                catch (Exception)
                {
                    Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                    validar = true;

                }

            } while (validar);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Boolean validar = false;
            do
            {
                try
                {



                    while (true)
            {
                Console.WriteLine("Menú Principal");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Realizar Pagos");
                Console.WriteLine("3. Consultar Pagos");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. Submenú Reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        p.InicializarVectores();
                        break;
                    case 2:
                        p.RealizarPagos();
                        break;
                    case 3:
                        p.ConsultarPagos();
                        break;
                    case 4:
                        p.ModificarPagos();
                        break;
                    case 5:
                        p.EliminarPagos();
                        break;
                    case 6:
                        p.Submenu_Reportes();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
                }
                catch (Exception)
                {
                    Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                    validar = true;

                }

            } while (validar);
        }

        void mostrarPagos() 
        {
            Console.Clear();
            Boolean Continuar = true;
            do
            {
                Boolean validar = false;
                do
                {
                    try
                    {

                        if (numeropagos == 0)
                {
                    Console.WriteLine("No hay pagos registrados.");
                            validar = false;
                        }
                else
                {
                    for (int i = 0; i < numeropagos; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("Número de pago: " + numPago[i]);
                        Console.WriteLine("Fecha: " + fecha[i]);
                        Console.WriteLine("Hora: " + hora[i]);
                        Console.WriteLine("Cédula: " + cedula[i]);
                        Console.WriteLine("Nombre: " + nombre[i]);
                        Console.WriteLine("Apellido 1: " + apellido1[i]);
                        Console.WriteLine("Apellido 2: " + apellido2[i]);
                        Console.WriteLine("Número de caja: " + numCaja[i]);
                        Console.WriteLine("Tipo de servicio: " + tipoServicio[i]);
                        Console.WriteLine("Número de factura: " + numFactura[i]);
                        Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                        Console.WriteLine("Monto de comisión: " + montoComision[i]);
                        Console.WriteLine("Monto deducido: " + montoDeducido[i]);
                        Console.WriteLine("Monto pagado por el cliente: " + montoPagaCliente[i]);
                        Console.WriteLine("Vuelto: " + vuelto[i]);
                    }
                }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);
                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);

            } while (Continuar);

        }

        void pagosTipoServicio() 
        {
            Console.Clear();
            Boolean Continuar = true;
            do
            {
                Boolean validar = false;
                do
                {
                    try
                    {

                        Console.Write("Ingrese el tipo de servicio a buscar (1=Luz, 2=Teléfono, 3=Agua): ");
                int tipoServicioBuscar = Convert.ToInt32(Console.ReadLine());
                        validar = false;
                        bool encontrado = false;
                for (int i = 0; i < numeropagos; i++)
                {
                    if (tipoServicio[i] == tipoServicioBuscar)
                    {

                        Console.WriteLine("Número de pago: " + numPago[i]);
                        Console.WriteLine("Fecha: " + fecha[i]);
                        Console.WriteLine("Hora: " + hora[i]);
                        Console.WriteLine("Cédula: " + cedula[i]);
                        Console.WriteLine("Nombre: " + nombre[i]);
                        Console.WriteLine("Apellido 1: " + apellido1[i]);
                        Console.WriteLine("Apellido 2: " + apellido2[i]);
                        Console.WriteLine("Número de caja: " + numCaja[i]);
                        Console.WriteLine("Tipo de servicio: " + tipoServicio[i]);
                        Console.WriteLine("Número de factura: " + numFactura[i]);
                        Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                        Console.WriteLine("Monto de comisión: " + montoComision[i]);
                        Console.WriteLine("Monto deducido: " + montoDeducido[i]);
                        Console.WriteLine("Monto pagado por el cliente: " + montoPagaCliente[i]);
                        Console.WriteLine("Vuelto: " + vuelto[i]);


                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("No se encontraron pagos con el tipo de servicio seleccionado.");
                }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);
                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);

            } while (Continuar);
        }

        void pagosCodigoCaja() 
        {
            Console.Clear();
            Boolean Continuar = true;
            do
            {
                Boolean validar = false;
                do
                {
                    try
                    {
                        Console.Write("Ingrese el código de caja a buscar: ");
                int codigoCajaBuscar = Convert.ToInt32(Console.ReadLine());
                        validar = false;
                        //se volvio encontrado en bool y se le agrego un 2 al nombre
                        bool encontrado2 = false;
                for (int i = 0; i < numeropagos; i++)
                {
                    if (numCaja[i] == codigoCajaBuscar)
                    {

                        Console.WriteLine("Número de pago: " + numPago[i]);
                        Console.WriteLine("Fecha: " + fecha[i]);
                        Console.WriteLine("Hora: " + hora[i]);
                        Console.WriteLine("Cédula: " + cedula[i]);
                        Console.WriteLine("Nombre: " + nombre[i]);
                        Console.WriteLine("Apellido 1: " + apellido1[i]);
                        Console.WriteLine("Apellido 2: " + apellido2[i]);
                        Console.WriteLine("Número de caja: " + numCaja[i]);
                        Console.WriteLine("Tipo de servicio: " + tipoServicio[i]);
                        Console.WriteLine("Número de factura: " + numFactura[i]);
                        Console.WriteLine("Monto a pagar: " + montoPagar[i]);
                        Console.WriteLine("Monto de comisión: " + montoComision[i]);
                        Console.WriteLine("Monto deducido: " + montoDeducido[i]);
                        Console.WriteLine("Monto pagado por el cliente: " + montoPagaCliente[i]);
                        Console.WriteLine("Vuelto: " + vuelto[i]);

                        encontrado2 = true;
                    }
                }
                if (!encontrado2)
                {
                    Console.WriteLine("No se encontraron pagos con el código de caja seleccionado.");
                }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);
                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);

            } while (Continuar);

        }

        void dineroComisionado()
        {
            Console.Clear();
            Boolean Continuar = true;
            do
            {
                Boolean validar = false;
                do
                {
                    try
                    {

                        double totalComisionLuz = 0;
                double totalComisionTelefono = 0;
                double totalComisionAgua = 0;
                for (int i = 0; i < numeropagos; i++)
                {
                    switch (tipoServicio[i])
                    {
                        case 1:
                            totalComisionLuz += montoComision[i];
                            break;
                        case 2:
                            totalComisionTelefono += montoComision[i];
                            break;
                        case 3:
                            totalComisionAgua += montoComision[i];
                            break;
                    }
                }
                Console.WriteLine("Total comisionado por servicio de luz: " + totalComisionLuz);
                Console.WriteLine("Total comisionado por servicio de teléfono: " + totalComisionTelefono);
                Console.WriteLine("Total comisionado por servicio de agua: " + totalComisionAgua);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato no valido, ingrese de nuevo la informacion");
                        validar = true;

                    }

                } while (validar);
                Console.WriteLine("Desea Hacer otra consulta 1- Si, Enter- No");
                Continuar = int.TryParse(Console.ReadLine(), out int valor);
            } while (Continuar);

        }

    }
}