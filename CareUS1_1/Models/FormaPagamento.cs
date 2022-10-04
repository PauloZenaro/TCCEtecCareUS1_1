using System.ComponentModel.DataAnnotations.Schema;

namespace CareUS1_1.Models
{
      public class FormaPagamento
    {
        public int id { get; set; }

        [ForeignKey("Cliente")]
        public Guid fkGuidCliente { get; set; }
        public Cliente GuidCliente { get; set; }

        public enum tipoDePagamento { pix, dinheiro }
    }
}
