using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CareUS1_1.Helpers;

namespace CareUS1_1.Models
{
    namespace CareUs.Models
    {
        [Table("Formacoes")]
        public class Formacao
        {
            [Key]
            public Guid GuidFormacao { get; set; }

            [ForeignKey("Cliente")]
            public Guid fkGuidCliente { get; set; }
            public Cliente GuidCliente { get; set; }

            [MaxLength(250, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
            public string descricaoFormacao { get; set; }


        }
    }
}
