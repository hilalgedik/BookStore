using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
         [Theory]
        [InlineData("L")]
        [InlineData("")]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null,null);
            command.Model = new CreateGenreModel() { Name = name};

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
          [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturunError()
        {
           CreateGenreCommand command = new CreateGenreCommand(null,null);
           command.Model = new CreateGenreModel() { Name = "Horror"};
           
           CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
           var result = validator.Validate(command);   
            result.Errors.Count.Should().Be(0); //Equals da kullanılabilir.   
        }

    }
}