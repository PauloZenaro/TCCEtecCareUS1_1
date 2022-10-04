using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CareUS1_1.Helpers;
using CareUS1_1.Models.CareUs.Models;

namespace CareUS1_1.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public Guid GuidCliente { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string nome { get; set; }

        public DateTime? dataNascimentoCliente { get; set; }

        [MaxLength(15, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string cpf { get; set; }

        [MaxLength(15, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string? rg { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string email { get; set; }

        [PasswordPropertyText]
        public string senha { get; set; }

        public ICollection<Paciente>? Pacientes { get; set; }

        public ICollection<Contato>? Contatos { get; set; }

        public ICollection<Formacao>? Formacoes { get; set; }

        public ICollection<Experiencia>? Experiencias { get; set; }

        public ICollection<Avaliacao>? Avaliacoes { get; set; }

    }
}
