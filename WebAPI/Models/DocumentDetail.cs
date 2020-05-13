using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class DocumentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentDetailId { get; set; }

        public int DocumentId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TVA { get; set; }

        public decimal TotalValue { get; set; }

        public Item Item { get; set; }
    }
}