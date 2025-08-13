using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : IAuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // int(11)
        public string Title { get; set; } // varchar(50)
        public string Author { get; set; } // varchar(50)
        public int Available { get; set; } // int(11)
        public string Publisher { get; set; } // varchar(50)
        public long Price { get; set; } // varchar(50)
        public DateTime CreatedOn { get; set; } // date
        public int IsActive { get; set; } // int(11)

        // Foreign Key
        public int GenreId { get; set; }
        public Genre Genre { get; set; }


        public string? CreatedBy { get; set ; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set ; }
        public DateTime? ModifiedDate { get ; set ; }
    }
}