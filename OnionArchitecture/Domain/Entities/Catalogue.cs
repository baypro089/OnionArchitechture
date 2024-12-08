using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Catalogue
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // int(11)
        public string Title { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int IsActive { get; set; } // int(11)
       
    }
}