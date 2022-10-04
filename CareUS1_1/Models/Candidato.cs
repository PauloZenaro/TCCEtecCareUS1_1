
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareUS1_1.Models
{
    [Table("Candidato")]
    public class Candidato
    {
        [Key]
        public Guid GuidCandidato { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidCliente { get; set; }
        public Cliente? GuidCliente { get; set; }

        [ForeignKey("Anuncio")]
        public Guid fkGuidAnuncio { get; set; }
        public Anuncio GuidAnuncio { get; set; }

    }
}
