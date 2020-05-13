using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class AssetHierarchy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public bool ActiveYN { get; set; }

        public int? ParentId { get; set; }

        public int TypeId { get; set; }

        public int? ItemId { get; set; }

        public int? ItemTypeId { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public decimal? ListPrice { get; set; }

        public string ImageUrl { get; set; }

    }
}