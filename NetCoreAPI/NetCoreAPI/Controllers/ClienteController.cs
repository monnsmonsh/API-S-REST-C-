using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Models;

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
                    edad ="28",
                    nombre = "Pancho"
                },
                new ClienteModel
                {
                    id = "2",
                    correo = "google2@gmail.com",
                    edad ="28",
                    nombre = "Juan"
                }
            };
           return clientes;
            
        }
        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(string _id)
        {

            //obtienes en cliente dB
            return new ClienteModel
            {
                id = _id,
                correo = "google2@gmail.com",
                edad ="28",
                nombre = "Juan"
  
            };

        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(ClienteModel cliente)
        {
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
        public dynamic eliminarCliente(ClienteModel cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //elimna en DB
            if (token != "Juan")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }
            return new
            {
                success = true,
                message = "Cliente Eliminado",
                result = cliente
            };

        }
    }
}
