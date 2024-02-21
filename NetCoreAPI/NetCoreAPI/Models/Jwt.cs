using System.Security.Claims;

namespace NetCoreAPI.Models
{
    public class Jwt
    {
        public string Key {  get; set; }
        public string Issuer { get; set; }
        public string Audience {  get; set; }
        public string Subject { get; set; }

        ///metodo general para validar el token
        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try{
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar si estas enviando un token",
                        result = "",
                    };
                }

                //en caso de que tenga datos
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
                UsuarioModel usuario = UsuarioModel.BD().FirstOrDefault(x => x.idUsuario == id);

                return new
                {
                    success = true,
                    message = "exito",
                    result = usuario
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Catch" + ex.Message,
                    result =""
                };
            }
        }


    }
}
