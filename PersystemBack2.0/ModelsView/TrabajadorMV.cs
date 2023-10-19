namespace PersystemBack2._0.ModelsView
{ 

    public class TrabajadorMV
    {
        public string Cedula{ get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string? Correo { get; set; }

        public double Salario { get; set; }

        public double PrecioDelContrato{ get; set; } 

        
       // public string Usuario { get; set; } = null!;

    }
}
