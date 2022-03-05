namespace SistemaElectoral.Models
{
    public class CondicionModel
    {
        public uint id { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public IFormFile documento_file { get; set; }
    }
}
