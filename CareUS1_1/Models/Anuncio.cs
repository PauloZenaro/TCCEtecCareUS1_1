using CareUS1_1.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareUS1_1.Models
{
    [Table("Anuncios")]
    public class Anuncio
    {
        public Guid GuidAnuncio { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidCriador { get; set; }
        public Cliente? GuidCliente { get; set; }

        public ICollection<Candidato>? candidatos;

        [MaxLength(250, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string? descricao { get; set; }

        [ForeignKey("Paciente")]
        public Guid? fkGuidPaciente { get; set; }
        public Cliente? GuidPaciente { get; set; }

        public bool ativo { get; set; }

        public ICollection<FormaPagamento>? FormasPagamentos;

        public DateTime dataDoAnuncio { get; set; }

        public DateTime? dataDoServico { get; set; }
    }
}
