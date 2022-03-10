namespace SistemaElectoral.Models
{
    public class EquipoModel
    {
        public uint id { get; set; }
        public string? nombre { get; set; }
        public string estado { get; set; }
        public uint fk_id_partido { get; set; }
    }
}
