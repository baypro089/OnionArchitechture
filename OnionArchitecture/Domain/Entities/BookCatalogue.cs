using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class BookCatalogue : IAuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public DateTime CreatedOn { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CatalogueId { get; set; }
        public Catalogue Catalogue { get; set; }

        public int IsActive { get; set; }
        public string? CreatedBy { get; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string? ModifiedBy { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
    }
}