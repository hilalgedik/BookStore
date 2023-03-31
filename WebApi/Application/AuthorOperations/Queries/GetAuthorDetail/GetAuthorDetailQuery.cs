using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{

    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorByIdViewModel Handle()
        {
            var author = _context.Authors.Include(x=>x.Book).SingleOrDefault(x => x.Id == AuthorId);


            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadi");
            }
            return _mapper.Map<GetAuthorByIdViewModel>(author);
        }

    }
    
    public class GetAuthorByIdViewModel
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Book { get; set; }
        public DateTime Birthday { get; set; }
    }

}