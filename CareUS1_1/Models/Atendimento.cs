using System.ComponentModel.DataAnnotations.Schema;

namespace CareUS1_1.Models
{
    public class Atendimento
    {
        public Guid GuidAtendimento { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidAnuncio { get; set; }
        public Cliente? GuidAnuncio { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidClienteContratado { get; set; }
        public Candidato? GuidCandidato { get; set; }

        public DateTime dataAtendimento { get; set; }
    }
}
