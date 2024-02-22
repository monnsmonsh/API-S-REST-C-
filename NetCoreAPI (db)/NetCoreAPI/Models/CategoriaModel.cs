namespace NetCoreAPI_BD.Models
{
    public class CategoriaModel
    {
        //los nombre tienen que ser identicos con las columnas
        public int IDCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
