using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CatalogueDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int IsActive { get; set; } // int(11)

    }

    public class CreateCatalogueDTO {
        public string Title { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int IsActive { get; set; } // int(11)
    }
}