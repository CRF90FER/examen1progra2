using System;
using System.Collections.Generic;
using System.Linq;

public class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleados();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglo();
                    break;
                case 6:
                    MostrarSubMenuReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        } while (opcion != 7);
    }

    private void AgregarEmpleado()
    {
        Console.Write("Ingrese la cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Ingrese el teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Ingrese el salario: ");
        decimal salario = decimal.Parse(Console.ReadLine());

        Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
        empleados.Add(nuevoEmpleado);

        Console.WriteLine("Empleado agregado correctamente.\n");
    }

    private void ConsultarEmpleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.\n");
            return;
        }

        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine(empleado);
        }
    }

    private void ModificarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado != null)
        {
            Console.Write("Ingrese el nuevo nombre: ");
            empleado.Nombre = Console.ReadLine();
            Console.Write("Ingrese la nueva dirección: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Ingrese el nuevo teléfono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Ingrese el nuevo salario: ");
            empleado.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Empleado modificado correctamente.\n");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.\n");
        }
    }

    private void BorrarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();
        Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado correctamente.\n");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.\n");
        }
    }

    private void InicializarArreglo()
    {
        empleados = new List<Empleado>();
        Console.WriteLine("Arreglos inicializados.\n");
    }

    private void MostrarSubMenuReportes()
    {
        Console.WriteLine("Reportes");
        Console.WriteLine("1. Listar empleados ordenados por nombre");
        Console.WriteLine("2. Calcular promedio de salarios");
        Console.Write("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ListarEmpleadosPorNombre();
                break;
            case 2:
                CalcularPromedioSalarios();
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    private void ListarEmpleadosPorNombre()
    {
        var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
        foreach (Empleado empleado in empleadosOrdenados)
        {
            Console.WriteLine(empleado);
        }
    }

    private void CalcularPromedioSalarios()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.\n");
            return;
        }

        decimal promedio = empleados.Average(e => e.Salario);
        Console.WriteLine($"El promedio de los salarios es: {promedio:C}\n");
    }
}