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

        public GatoDto ActualizarInfomacionDe(string nombre, Gato unGato)
        {
            if (string.IsNullOrEmpty(unGato.Nombre))
                return new GatoDto();

            this.gatoRepository.Update(unGato);
            var gato = gatoRepository.FindByName(nombre);
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
            this.gatoRepository.Delete(unGato);
            var gatoDto = new GatoDto
            {
                IdGato = unGato.IdGato,
                Nombre = unGato.Nombre,
                Nacimiento = unGato.Nacimiento
            };
            return gatoDto;
        }
    }
}
