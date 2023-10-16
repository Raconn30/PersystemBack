using PersystemBack2._0.Models;

namespace PersystemBack2._0.ModelsView
{
    public class MaterialVM
    {
        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public double Precio { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Unidades { get; set; } = null!;

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

    }
}
