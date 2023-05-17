using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;

namespace Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQueryTests: IClassFixture<CommonTestFixture>
    {
       private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void BookQuantityIsItTrue()
        {
            var amount = _context.Books.Count();
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);

            var BookList =  query.Handle();
            Assert.Equal(amount, BookList.Count);

        }
    }
}