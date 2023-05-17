using AutoMapper;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryTests : IClassFixture<CommonTestFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void GetBookByIdMetodShouldReturnCorrectBook()
        {
            int id =1;
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            GetByIdBookQuery query = new GetByIdBookQuery(_context, _mapper);
            query.id = id;
            var result = query.Handle();
           
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.PageCount, result.PageCount);
            Assert.Equal(book.PublishDate, result.PublishDate);
            Assert.Equal(((GenreEnum)book.GenreId).ToString(), result.Genre);
        }
        //HFGD-LQHT amazon code


    }
}