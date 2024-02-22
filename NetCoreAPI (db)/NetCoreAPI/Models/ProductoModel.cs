namespace NetCoreAPI_BD.Models
{
    public class ProductoModel
    {
        //los nombre tienen que ser identicos con las columnas
        public string IDproducto { get; set; }
        public string IDCategoria { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
    }

}
