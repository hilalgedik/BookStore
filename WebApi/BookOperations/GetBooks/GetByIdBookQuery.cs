using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookQuery
    {
        public int id {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIdBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
              _mapper = mapper;

        }

        public BooksByIdViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == id).SingleOrDefault();
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
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }



}