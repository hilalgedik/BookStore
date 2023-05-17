using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetByIdBookQuery
    {
        public int id {get; set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIdBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
              _mapper = mapper;

        }

        public BooksByIdViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Where(book => book.Id == id).SingleOrDefault();
            // var result = new BooksByIdViewModel(){
            //         Title= book.Title,
            //         Genre=((GenreEnum)book.GenreId).ToString(),
            //         PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
            //         PageCount=book.PageCount
            // };

            BooksByIdViewModel vm = _mapper.Map<BooksByIdViewModel>(book);
            
            return vm;
            
        }
    }

    public class BooksByIdViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }



}