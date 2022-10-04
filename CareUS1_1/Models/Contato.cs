using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CareUS1_1.Helpers;

namespace CareUS1_1.Models
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public Guid GuidContato { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkIdCliente { get; set; }
        public Cliente GuidCliente { get; set; }

        [MaxLength(15, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string telefone { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string nomeContato { get; set; }


    }
}
