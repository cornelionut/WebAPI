using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class LeasingDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeasingDocumentId { get; set; }

        public int DocumentId { get; set; }

        public int ProductId {get;set;}

        public int CurrencyId { get; set; }

        public int PartnerId { get; set; }

        public decimal Amount { get; set; }

        public decimal Commission { get; set; }

        public decimal ResidualValue { get; set; }

        public Document Document { get; set; }

        public Partner Partner { get; set; }

        public FinancialProduct Product { get; set; }

        public Currency Currency { get; set; }
    }
}