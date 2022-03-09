namespace SistemaElectoral.Models
{
    public class EleccionModel
    {
        public uint id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}
