using Mascotas.Models;
using Mascotas.Repositories;
using Mascotas.Servicios.DTO;

namespace Mascotas.Servicios
{
    public class GatoService
    {
        private readonly GatoRepository gatoRepository;

        public GatoService(GatoRepository gatoRepository)
        {
            this.gatoRepository = gatoRepository;
        }

        public IEnumerable<GatoDto> ObtenerTodoLosGatos()
        {
            var gatos = gatoRepository.FindAll();
            var gatosDto = new List<GatoDto>();
            foreach (var gato in gatos)
            {
                gatosDto.Add(new GatoDto
                {
                    IdGato = gato.IdGato,
                    Nombre = gato.Nombre,
                    Nacimiento = gato.Nacimiento
                });
            }
            return gatosDto;
        }

        public GatoDto AdoptarA(Gato unGato)
        {
            if (string.IsNullOrEmpty(unGato.Nombre))
                return new GatoDto();

            this.gatoRepository.Add(unGato);
            var gato = gatoRepository.FindByName(unGato.Nombre);
            var gatoDto = new GatoDto
            {
                IdGato = gato.IdGato,
                Nombre = gato.Nombre,
                Nacimiento = gato.Nacimiento
            };
            return gatoDto;
        }

        public GatoDto ActualizarInfomacionDe(string nombre, string nuevoNombre)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nuevoNombre))
                return new GatoDto();

            var gato = gatoRepository.FindByName(nombre);

            gato.Nombre = nuevoNombre;

            this.gatoRepository.Update(gato);

            gato = gatoRepository.FindByName(nuevoNombre);

            if (gato == null) 
                return new GatoDto();

            var gatoDto = new GatoDto
            {
                IdGato = gato.IdGato,
                Nombre = gato.Nombre,
                Nacimiento = gato.Nacimiento
            };
            
            return gatoDto;
        }

        public GatoDto DarEnAdopcionA(string nombre)
        {
            var gato = gatoRepository.FindByName(nombre);

            if (gato == null)
                return new GatoDto();

            this.gatoRepository.Delete(gato);
            var gatoDto = new GatoDto
            {
                IdGato = gato.IdGato,
                Nombre = gato.Nombre,
                Nacimiento = gato.Nacimiento
            };
            return gatoDto;
        }

        public IEnumerable<GatoDto> BuscarPorRaza(string raza)
        {
            var gatos = gatoRepository.Buscar(raza);
            var gatosDto = gatos.Select(x => new GatoDto
                { IdGato = x.IdGato, Nombre = x.Nombre, Nacimiento = x.Nacimiento });
            return gatosDto;
        }
    }
}
