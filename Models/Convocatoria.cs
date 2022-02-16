using System.ComponentModel.DataAnnotations;

namespace SistemaElectoral.Models
{
    public class Convocatoria
    {
        public uint id { get; set; }

        public string? nombre { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public uint fk_id_comite { get; set; }

        public uint fk_id_eleccion { get; set; }

        public uint fk_id_cargo { get; set; }

    }
}
