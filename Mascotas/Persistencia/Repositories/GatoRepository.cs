using Mascotas.Models;
using Mascotas.Servicios.DTO;

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

        public Gato FindByName(string nombre)
        {
            return this.context.Gatos.Where(x => x.Nombre == nombre).First();
        }

        public void Add(Gato gato)
        {
            this.context.Gatos.Add(gato);
            this.context.SaveChanges();
        }

        public void Update(Gato gato)
        {
            var gatoAModificar = this.context.Gatos.First(x => x.IdGato == gato.IdGato);
            gatoAModificar.Nombre = gato.Nombre;
            gatoAModificar.Sexo = gato.Sexo;
            gatoAModificar.Nacimiento = gato.Nacimiento;
            gatoAModificar.Raza = gato.Raza;
            this.context.SaveChanges();
        }

        public void Delete(Gato gato)
        {
            var gatoAEliminar = this.context.Gatos.First(x => x.IdGato == gato.IdGato);
            this.context.Gatos.Remove(gatoAEliminar);
            this.context.SaveChanges();
        }

        public IEnumerable<Gato> Buscar(string raza)
        {
            var gatos = context.Gatos.Where(x => x.Raza == raza);
            return gatos.ToList();
        }
    }
}
