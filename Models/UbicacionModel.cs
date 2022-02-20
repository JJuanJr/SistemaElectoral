namespace SistemaElectoral.Models
{
    public class UbicacionModel
    {
        public uint id { get; set; }
        public string direccion { get; set; }
        public uint fk_id_municipo { get; set; }
    }
}
