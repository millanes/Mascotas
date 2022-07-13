using Mascotas.Models;

namespace Mascotas.Repositories
{
    public class GatoRepository
    {
        private readonly GatosContexto context;

        public GatoRepository(GatosContexto context)
        {
            this.context = context;
        }

        public IEnumerable<Gato> FindAll()
        {
            return this.context.Gatos.ToList();
        }

        public void Add(Gato gato)
        {
            this.context.Gatos.Add(gato);
            this.context.SaveChanges();
        }
    }
}
