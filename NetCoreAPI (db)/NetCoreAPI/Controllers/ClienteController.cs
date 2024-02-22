using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Models;
using System.Security.Claims;

namespace NetCoreAPI.Controllers
{
    //dominio/cliente/listar
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            //Todo el codigo retornando algo
            List<ClienteModel> clientes = new List<ClienteModel>
            {
                new ClienteModel
                {
                    id = "1",
                    correo = "google@gmail.com",
                    edad = "19",
                    nombre = "Bernardo Peña"
                },
                new ClienteModel
                {
                    id = "2",
                    correo = "miguelgoogle@gmail.com",
                    edad = "23",
                    nombre = "Miguel Mantilla"
                }
            };
           return clientes;
            
        }
        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int codigo)
        {

            //obtienes en cliente dB
            return new ClienteModel
            {
                id = codigo.ToString(),
                correo = "google@gmail.com",
                edad = "19",
                nombre = "Bernardo Peña"
            };

        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(ClienteModel cliente)
        {
            //Guardar en la db y le asignas un id
            cliente.id = "3";

            return new
            {
                success = true,
                message = "Cliente Resgistrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        [Authorize]//para que si o si me envie un token valido(para ahorar recursos)
        public dynamic eliminarCliente(ClienteModel cliente)
        {
            //obtener el token
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            //respuesta token
            var rToken = Jwt.validarToken(identity);

            if (!rToken.success) return rToken;

            //
            UsuarioModel usuario = rToken.result;
            if (usuario.rol != "administrador") 
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos para eliminar clientes",
                    result = ""
                };
            }

            /*Validacion simple
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //eliminas en la db

            if (token != "marco123.")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }
            */
            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };

        }
    }
}
