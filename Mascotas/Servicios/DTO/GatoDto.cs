namespace Mascotas.Servicios.DTO
{
    public class GatoDto
    {
        public int IdGato { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? Nacimiento { get; set; }
    }
}
