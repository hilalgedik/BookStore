using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authorsList = _context.Authors.Include(x=>x.Book).OrderBy(x=>x.Id).ToList<Author>();
            
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorsList);
            return vm;
        }
    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Book { get; set; }
        public DateTime Birthday { get; set; }
    }
}