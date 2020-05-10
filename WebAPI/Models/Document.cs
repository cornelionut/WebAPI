using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime DocumentDate { get; set; }

      //  public virtual ICollection<LeasingDocument> LeasingDocuments { get; set; }
    }
}