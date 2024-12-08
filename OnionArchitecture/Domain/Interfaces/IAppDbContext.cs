using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Book> Books { get; }

        DbSet<Genre> Genres { get; }

        DbSet<Catalogue> Catalogues { get; }

        DbSet<BookCatalogue> BookCatalogues { get; }

    }
}
