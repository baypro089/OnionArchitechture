using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookCatalogue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public DateTime CreatedOn { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int CatalogueId { get; set; }
        public Catalogue Catalogue { get; set; }

        public int IsActive { get; set; }

       
    }
}