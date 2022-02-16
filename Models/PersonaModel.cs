namespace SistemaElectoral.Models
{
    public class PersonaModel
    {
        public ulong id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public uint edad { get; set; }
        public string genero { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public uint fk_id_rol { get; set; }
    }
}
