using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Commands.deleteAuthor
{
    public class DeleteAuthorCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
           
        }

         [Fact]
         public void IsThereABook_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = 100;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yazar Bulunamadi.");
        
        }

         [Fact]
         public void WhileThereIsAAuthor_Null_ShouldBeReturn()
        {
             
            var id=1;
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;

             //act
            //FluentActions.Invoking(()=>command.Handle()).Invoke();
            command.Handle();

            //assert
            var author = _context.Authors.SingleOrDefault(x=>x.Id == id);
            author.Should().BeNull();
        }


    }

}