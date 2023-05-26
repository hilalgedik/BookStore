using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("1")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel()
            {
                Name = name,
            
            };

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
 [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturunError()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.id=0;
             command.Model = new UpdateGenreModel()
            {
                Name = "Lord Of The Rings",
              
            };
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0); //Equals da kullanılabilir.


        }

        

    }
}