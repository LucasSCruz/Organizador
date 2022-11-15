using System.ComponentModel.DataAnnotations.Schema;

namespace Organizador.API.Models
{
    public class Projeto : Entity
    {
        public string nomeProjeto { get; set; }
        public string descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
    }
}