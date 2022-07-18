using JWT.Algorithms;
using JWT.Builder;
using Mascotas.Presentacion.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mascotas.Presentacion.Controllers
{
    [Route("access/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly List<AplicacionUsuarioViewModel> usuarios;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
            usuarios = configuration.GetSection("Usuarios").Get<List<AplicacionUsuarioViewModel>>();
        }

        [HttpPost]
        public ActionResult Login(AplicacionUsuarioViewModel aplicacionUsuario) 
        {
            if (!usuarios.Any(x => x.nombreUsuario == aplicacionUsuario.nombreUsuario && x.contraseña == aplicacionUsuario.contraseña))
                return Unauthorized();

            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm())
                      .WithSecret(configuration["Jwt:secret"])
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds())
                      .AddClaim("empresa", configuration["Jwt:empresa"])
                      .AddClaim("proyecto", configuration["Jwt:proyecto"])
                      .AddClaim("nombreUsuario", aplicacionUsuario.nombreUsuario)
                      .Encode();

            return Ok(token);
        }
    }
}
