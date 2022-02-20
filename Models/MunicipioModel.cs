namespace SistemaElectoral.Models
{
    public class MunicipioModel
    {
        public uint id { get; set; }
        public string nombre { get; set; }
        public uint fk_id_departamento { get; set; }
    }
}
