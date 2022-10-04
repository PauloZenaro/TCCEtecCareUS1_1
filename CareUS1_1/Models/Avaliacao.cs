using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CareUS1_1.Helpers;


namespace CareUS1_1.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public Guid GuidAvaliacao { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidCliente { get; set; }

        public Cliente? GuidCliente { get; set; }

        public double nota { get; set; }

        [MaxLength(250, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string? Descricao { get; set; }
    }
}
