using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookCommand
    {
        public int id {get; set;}
        private readonly BookStoreDbContext _dbContext;
        public GetByIdBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;

        }

        public BooksByIdViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==id);
            var result = new BooksByIdViewModel(){
                    Title= book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount=book.PageCount
            };
            
            return result;
            
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