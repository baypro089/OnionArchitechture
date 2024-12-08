using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } // varchar(50)
        public string Author { get; set; } // varchar(50)
        public int Available { get; set; } // int(11)
        public string Publisher { get; set; } // varchar(50)
        public string Price { get; set; } // varchar(50)
        public int IsActive { get; set; } // int(11)

        // Foreign Key
        public int GenreId { get; set; }

    }

    public class CreateBookDTO
    {
        public string Title { get; set; } // varchar(50)
        public string Author { get; set; } // varchar(50)
        public int Available { get; set; } // int(11)
        public string Publisher { get; set; } // varchar(50)
        public string Price { get; set; } // varchar(50)
        public int IsActive { get; set; } // int(11)

        // Foreign Key
        public int GenreId { get; set; }
    }
}