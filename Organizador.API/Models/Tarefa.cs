using System.ComponentModel.DataAnnotations.Schema;

namespace Organizador.API.Models
{
    public class Tarefa : Entity
    {
        public string nomeTarefa { get; set; }
        public string descricaoTarefa {get; set; }
        public string subDescricaoTarefa { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataTerminio { get; set; }

        [ForeignKey("Projeto")]
        public Guid ProjetoId { get; set; }
    }
}