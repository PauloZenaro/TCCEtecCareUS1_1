using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CareUS1_1.Helpers;

namespace CareUS1_1.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public Guid GuidPaciente { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidCliente { get; set; }
        public Cliente GuidCliente { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string? nomePaciente { get; set; }

        public DateTime? dataDeNascimentoPaciente { get; set; }


    }
}
