using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SistemaElectoral.Models
{
    public class Convocatoria
    {
        public uint id { get; set; }

        public string? nombre { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }
        public uint cant_ganadores { get; set; }
        public string estado { get; set; }
        public List<SelectListItem> condiciones { get; set; }
        public uint fk_id_comite { get; set; }

        public uint fk_id_eleccion { get; set; }

        public uint fk_id_cargo { get; set; }

    }
}
