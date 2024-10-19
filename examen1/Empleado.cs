public class Empleado
{
    // Atributos del empleado
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public decimal Salario { get; set; }

    // Constructor para inicializar el empleado
    public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }

    // Método para mostrar los detalles del empleado
    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre}, Dirección: {Direccion}, Teléfono: {Telefono}, Salario: {Salario:C}";
    }
}