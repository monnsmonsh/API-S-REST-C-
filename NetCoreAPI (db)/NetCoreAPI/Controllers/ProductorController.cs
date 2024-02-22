using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Resoucers;
using NetCoreAPI_BD.Models;
using Newtonsoft.Json;
using System.Data;

namespace NetCoreAPI.Controllers
{

    //dominio/
    [ApiController]
    [Route("producto")]
    public class ProductorController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic ListarProductos()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Estado", "1")
            };

            DataTable tCategoria = BD_Datos.Listar("Categoria_Listar", parametros);
            DataTable tProducto = BD_Datos.Listar("Producto_Listar");

            //trasnformando los obj obtenidos a JSON (string) - convertomos la tbl json
            string jsonCategoria = JsonConvert.SerializeObject(tCategoria);
            string jsonProducto = JsonConvert.SerializeObject(tProducto);


            return new
            {
                success = true,
                message = "exito",
                result = new
                {
                    //categoria = jsonCategoria,
                    //producto = jsonProducto
                    
                    //_Para converir en lista
                    categoria =JsonConvert.DeserializeObject<List<CategoriaModel>>(jsonCategoria),
                    producto = JsonConvert.DeserializeObject<List<ProductoModel>>(jsonProducto),
                }
            };
        }
    }
}
