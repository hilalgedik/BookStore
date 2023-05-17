using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors()
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId=0;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
            
            

        }

       

    }
}