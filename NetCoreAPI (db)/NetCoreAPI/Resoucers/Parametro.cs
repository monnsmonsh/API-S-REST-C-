namespace NetCoreAPI.Resoucers
{
    public class Parametro
    {
        //add contructor
        public Parametro(string nombre, string valor) 
        {
            Nombre = nombre;
            Valor = valor;
        
        }

        //generamos los dos parametro para BD_Datos
        public string Nombre {  get; set; }
        public string Valor { get; set; }

    }
}
