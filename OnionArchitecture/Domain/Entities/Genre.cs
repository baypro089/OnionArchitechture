using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // int(11)
        public string Name { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int InActive { get; set; } // int(11)

        // Navigation Property
       
    }
}