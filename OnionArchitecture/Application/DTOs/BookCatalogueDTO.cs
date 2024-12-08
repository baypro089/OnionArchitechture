using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookCatalogueDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int CatalogueId { get; set; }

        public int IsActive { get; set; }
       
    }

    public class CreateBookCatalogueDTO
    {
        public int BookId { get; set; }

        public int CatalogueId { get; set; }

        public int IsActive { get; set; }

    }
}