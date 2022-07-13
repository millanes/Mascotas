using System;
using System.Collections.Generic;

namespace Mascotas.Models
{
    public partial class Gato
    {
        public int IdGato { get; set; }
        public string Nombre { get; set; } = null!;
        public string Raza { get; set; } = null!;
        public string? Sexo { get; set; }
        public DateTime? Nacimiento { get; set; }
    }
}
