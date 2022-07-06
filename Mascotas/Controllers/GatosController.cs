using Mascotas.Models;
using Mascotas.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mascotas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly GatoRepository gatoRepository;

        //public GatosController(GatoRepository gatoRepository)
        //{
        //    this.gatoRepository = gatoRepository;
        //}
        public GatosController(GatoRepository gatoRepository) => this.gatoRepository = gatoRepository;
        // GET: api/<GatosController>
        [HttpGet]
        public ActionResult<IEnumerable<Gato>> Obtener()
        {
            return Ok(this.gatoRepository.FindAll());
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
        public ActionResult Adoptar([FromBody] Gato unGato)
        {
            this.gatoRepository.Add(unGato);
            return Ok("Has adoptado al gato!");
        }

        //// PUT api/<GatosController>/Luna
        //[HttpPut("{nombre}")]
        //public ActionResult<IEnumerable<Gato>> Renombrar(string nombre, [FromBody] string nuevoNombre)
        //{
        //    var gato = listaGatos.Find(gato => gato.Nombre == nombre);
        //    if (gato != null)
        //    {
        //        gato.Nombre = nuevoNombre;
        //        return Ok(listaGatos);
        //    }
        //    else
        //    {
        //        return BadRequest($"No tienes un gato con el nombre {nombre}");
        //    }
        //}

        //// DELETE api/<GatosController>/Luna
        //[HttpDelete("{nombre}")]
        //public ActionResult Regalar(string nombre)
        //{
        //    var gatoARegalar = listaGatos.Find(gato => gato.Nombre == nombre);

        //    if (gatoARegalar != null)
        //    {
        //        listaGatos.Remove(gatoARegalar);

        //        return Ok($"Regalaste a uno de tus gatos. ¡Adios {nombre}!");
        //    }
        //    else
        //    {
        //        return BadRequest($"No pudiste regalar a {nombre}. ¿El nombre es correcto?");
        //    }
        //}
    }
}
