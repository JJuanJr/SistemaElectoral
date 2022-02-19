namespace SistemaElectoral.Models
{
    public class InstitucionModel
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string registro { get; set; }
        public byte[] logo { get; set; }
        public string nombre_rector { get; set; }
        public ulong telefono { get; set; }
        public uint fk_id_ubicacion { get; set; }
    }
}
