using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class AssetHierarchy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetHierarchyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool ActiveYN { get; set; }

        public int? ParentId { get; set; }

        public int TypeId { get; set; }

        public int? ItemId { get; set; }

        public int? ItemTypeId { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ListPrice { get; set; }

        public string ImageUrl { get; set; }

        public string CarMake { get; set; }

        //public virtual AssetHierarchy Parent { get; set; }

        //public virtual ICollection<AssetHierarchy> Children { get; set; }

        //public Item Item { get; set; }

    }
}