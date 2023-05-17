using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DBOperations;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
           
        }

        [Fact]
         public void IsThereABook_InvalidOperationException_ShouldBeReturn()
        {
             //Arrange,hazırlık
            var bookId = 1000;

            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId=bookId;

             //Act,çalıştırma & Assert,doğrulama
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Kitap Bulunamadi");
        }

         [Fact]
         public void WhileThereIsABook_Null_ShouldBeReturn()
        {
             //Arrange,hazırlık
            var bookId = 1;

            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId=bookId;

             //act
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(x=>x.Id == bookId);
            book.Should().BeNull();

        }





    }

}