namespace PersystemBack2._0.ModelsView
{
    public class ContratosMV
    {
        public string Codigo { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public string Servicio { get; set; } = null!;
        public string Predio { get; set; } = null!;
    }
}
