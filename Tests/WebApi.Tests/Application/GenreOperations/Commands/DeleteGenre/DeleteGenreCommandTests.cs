using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

         [Fact]
         public void IsThereAGenre_InvalidOperationException_ShouldBeReturn()
        {
            var GenreId=1000;
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = GenreId;
             FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Kitap Türü Bulunamadi");
        }

          [Fact]
         public void WhileThereIsAGenre_Null_ShouldBeReturn()
        {
            var GenreId=1;
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = GenreId;
            
             FluentActions.Invoking(()=>command.Handle()).Invoke();

             var genre = _context.Genres.SingleOrDefault(x=>x.Id==command.GenreId);
             
             genre.Should().BeNull();
        

        }



    }
}