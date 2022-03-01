using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaElectoral.Models
{
    public class RolModel
    {
        public uint id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public List<SelectListItem> permisos { get; set; }
    }
}
