using Mascotas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mascotas.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        List<Gato> listaGatos = new List<Gato> {
            new Gato { Nombre = "Luna", Edad = 14, Color = "Blanca" },
            new Gato { Nombre = "Milo", Edad = 14, Color = "Negro" }
        };
        // GET: api/<GatosController>
        [HttpGet]
        public ActionResult<IEnumerable<Gato>> Obtener()
        {
            return listaGatos;
        }

        // GET api/<GatosController>/Luna
        [HttpGet("{nombre}")]
        public ActionResult<Gato> Obtener(string nombre)
        {
            var gato = listaGatos.Find(x => x.Nombre == nombre);

            if (gato != null)
                return Ok(gato);
            else
                return BadRequest($"No tienes un gato con el nombre {nombre}");
        }

        // POST api/<GatosController>
        [HttpPost]
        public ActionResult<IEnumerable<Gato>> Adoptar([FromBody] Gato unGato)
        {
            listaGatos.Add(unGato);
            return Ok(listaGatos);
        }

        // PUT api/<GatosController>/Luna
        [HttpPut("{nombre}")]
        public ActionResult<IEnumerable<Gato>> Renombrar(string nombre, [FromBody] string nuevoNombre)
        {
            var gato = listaGatos.Find(gato => gato.Nombre == nombre);
            if (gato != null)
            {
                gato.Nombre = nuevoNombre;
                return Ok(listaGatos);
            }
            else
            {
                return BadRequest($"No tienes un gato con el nombre {nombre}");
            }
        }

        // DELETE api/<GatosController>/Luna
        [HttpDelete("{nombre}")]
        public ActionResult Regalar(string nombre)
        {
            var gatoARegalar = listaGatos.Find(gato => gato.Nombre == nombre);

            if (gatoARegalar != null)
            {
                listaGatos.Remove(gatoARegalar);

                return Ok($"Regalaste a uno de tus gatos. ¡Adios {nombre}!");
            }
            else
            {
                return BadRequest($"No pudiste regalar a {nombre}. ¿El nombre es correcto?");
            }
        }
    }
}
