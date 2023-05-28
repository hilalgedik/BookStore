using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace Application.AuthorOperations.Commands.deleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
         [Fact]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId=0;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
            
            

        }

    }
}