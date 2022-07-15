using Mascotas.Models;
using Mascotas.Presentacion.ViewModels;
using Mascotas.Repositories;
using Mascotas.Servicios;
using Mascotas.Servicios.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mascotas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly GatoService gatoService;


        //public GatosController(GatoRepository gatoRepository)
        //{
        //    this.gatoRepository = gatoRepository;
        //}
        public GatosController(GatoService gatoService)
        {
            this.gatoService = gatoService;
        }
        // GET: api/<GatosController>
        [HttpGet]
        public ActionResult<IEnumerable<GatoViewModel>> Obtener()
        {
            IEnumerable<GatoDto> gatos = this.gatoService.ObtenerTodoLosGatos();
            List<GatoViewModel> gatosViewModel = new List<GatoViewModel>();
            //proceso a realizar con un mapper
            foreach (var gato in gatos)
            {
                gatosViewModel.Add(new GatoViewModel
                {
                    IdGato = gato.IdGato,
                    Nombre = gato.Nombre,
                    Edad = DateTime.Now.Year - gato.Nacimiento.Value.Year
                });
            }

            return Ok(gatosViewModel);
        }

        //// GET api/<GatosController>/Luna
        //[HttpGet("{nombre}")]
        //public ActionResult<Gato> Obtener(string nombre)
        //{
        //    var gato = listaGatos.Find(x => x.Nombre == nombre);

        //    if (gato != null)
        //        return Ok(gato);
        //    else
        //        return BadRequest($"No tienes un gato con el nombre {nombre}");
        //}

        // POST api/<GatosController>
        [HttpPost]
        public ActionResult<GatoViewModel> Adoptar([FromBody] Gato unGato)
        {
            GatoDto gato = this.gatoService.AdoptarA(unGato);
            //proceso a realizar con un mapper
            GatoViewModel gatoViewModel = new GatoViewModel
            {
                IdGato = gato.IdGato,
                Nombre = gato.Nombre,
                Edad = DateTime.Now.Year - gato.Nacimiento.Value.Year
            };
            return Ok(gatoViewModel);
        }

        //// PUT api/<GatosController>/Luna
        [HttpPut("{nombre}")]
        public ActionResult<Gato> Renombrar(string nombre, [FromBody] string nuevoNombre)
        {
            var gato = gatoService.ActualizarInfomacionDe(nombre, nuevoNombre);

            return Ok(gato);
        }

        // DELETE api/<GatosController>/Luna
        [HttpDelete("{nombre}")]
        public ActionResult Regalar(string nombre)
        {
            var gatoARegalar = gatoService.DarEnAdopcionA(nombre);

            if (!string.IsNullOrEmpty(gatoARegalar.Nombre))
            {
                return StatusCode(200, $"Regalaste a uno de tus gatos. ¡Adios {nombre}!");
            }
            else
            {
                //204 No Content
                return StatusCode(204, $"No pudiste regalar a {nombre}. ¿El nombre es correcto?");
            }
        }

        [HttpGet("{raza}/gatos")]
        public ActionResult<IEnumerable<GatoDto>> Buscar(string raza)
        {
            var gatos = gatoService.BuscarPorRaza(raza);
            
            if (!gatos.Any())
                return NoContent();

            return Ok(gatos);
        }
    }
}
