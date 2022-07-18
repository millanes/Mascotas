
using System.Text.Json.Serialization;
using JWT.Algorithms;
using JWT.Builder;
using Mascotas.Presentacion.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace Mascotas.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration _configuration;
        private readonly List<AplicacionUsuarioViewModel> usuarios;
        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this._configuration = configuration;
            usuarios = configuration.GetSection("Usuarios").Get<List<AplicacionUsuarioViewModel>>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string payload;

            try
            {
                payload = JwtBuilder.Create()
                         .WithAlgorithm(new HMACSHA256Algorithm())
                         .MustVerifySignature()
                         .WithSecret(_configuration["Jwt:secret"])
                         .Decode(context.Request.Headers["token"]);

            }
            catch
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var usuario = JsonConvert.DeserializeObject<AplicacionUsuarioViewModel>(payload);

            if (!usuarios.Any(x => x.nombreUsuario == usuario.nombreUsuario))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await this.next.Invoke(context);
        }
    }
}
