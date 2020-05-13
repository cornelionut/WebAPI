using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public int HierarchyItemId { get; set; }

        public int ItemTypeId { get; set; }

        public int VATId { get; set; }

        public int MeasuringUnitId { get; set; }

        public AssetHierarchy AssetHierarchy { get; set; }

    }
}