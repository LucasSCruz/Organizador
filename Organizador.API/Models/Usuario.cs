namespace Organizador.API.Models
{
    public class Usuario : Entity
    {
        public string nome {get; set; }
        public string senha {get; set; }
        public DateTime dataCriacao {get; set;}
    }
}