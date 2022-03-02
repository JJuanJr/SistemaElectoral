namespace SistemaElectoral.Models
{
    public class InstitucionModel
    {
        public string nombre { get; set; }
        public string registro { get; set; }
        public string logo { get; set; }
        public IFormFile imagen { get; set; }
        public string nombre_rector { get; set; }
        public long telefono { get; set; }
        public uint fk_id_ubicacion { get; set; }
    }
}
