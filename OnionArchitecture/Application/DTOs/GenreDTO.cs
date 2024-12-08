using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int InActive { get; set; } // int(11)
       
    }

    public class CreateGenreDTO
    {
        public string Name { get; set; } // varchar(50)
        public string Description { get; set; } // text
        public int InActive { get; set; } // int(11)
    }
}