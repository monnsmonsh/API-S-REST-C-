namespace NetCoreAPI.Models
{
    public class UsuarioModel
    {
        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }

        public static List<UsuarioModel>BD()
        {
            var list = new List<UsuarioModel>()
            {
                new UsuarioModel
                {
                    idUsuario = "1",
                    usuario = "Martin",
                    password = "123",
                    rol = "empleado"
                },
                new UsuarioModel
                {
                    idUsuario = "2",
                    usuario = "Marcos",
                    password = "123",
                    rol = "asesor"
                },
                new UsuarioModel
                {
                    idUsuario = "3",
                    usuario = "Locuas",
                    password = "123",
                    rol = "administrador"
                }
            };
            return list;
        }


    }
}
