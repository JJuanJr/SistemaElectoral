namespace SistemaElectoral.Models
{
    public class LoginModel
    {
        public ulong user { get; set; }
        public string password { get; set; }
        public bool recordar { get; set; }
    }
}
