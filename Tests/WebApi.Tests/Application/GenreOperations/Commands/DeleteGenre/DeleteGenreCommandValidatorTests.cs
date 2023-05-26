using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests: IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors()
        {
            var GenreId=0;
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = GenreId;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}