

using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<CreateBookDTO, Book>();
        }
    }
}
