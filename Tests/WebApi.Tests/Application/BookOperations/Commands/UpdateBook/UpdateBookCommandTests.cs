using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests: IClassFixture<CommonTestFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenBookIsDoesntExist_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book() {Id=100};

            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.id= book.Id;
            UpdateBookModel model = new UpdateBookModel(){GenreId=1, PageCount=100, Title="AAAA"};
            command.Model=model;

             FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap mevcut değil");

        }

        

    }
}