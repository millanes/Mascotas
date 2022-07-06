using Mascotas.Models;

namespace Mascotas.Repositories
{
    public class GatoRepository
    {
        List<Gato> listaGatos;

        public GatoRepository()
        {
            listaGatos = new List<Gato> {
                new Gato { Nombre = "Luna", Edad = 14, Color = "Blanca" },
                new Gato { Nombre = "Milo", Edad = 14, Color = "Negro" }
            };
        }

        public IEnumerable<Gato> FindAll()
        {
            return listaGatos;
        }

        public void Add(Gato gato)
        {
            this.listaGatos.Add(gato);
        }
    }
}
