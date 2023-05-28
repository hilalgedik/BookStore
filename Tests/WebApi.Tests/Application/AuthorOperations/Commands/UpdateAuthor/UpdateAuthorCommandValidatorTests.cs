using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
         [Theory]
        [InlineData("L", "3")]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors(string name, string surname)
        {
            UpdateAuthorCommand command=new UpdateAuthorCommand(null);
            command.AuthorId=1;
            command.Model=new UpdateAuthorModel(){
                Name=name,
                Surname=surname
            };
            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
              var result= validator.Validate(command);
              result.Errors.Count.Should().BeGreaterThan(0);
                
        }

          [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
             UpdateAuthorCommand command=new UpdateAuthorCommand(null);
              command.AuthorId=1;
            command.Model=new UpdateAuthorModel(){
                Name="Hilal",
                Surname="Gedik",
                Birthday=DateTime.Now
            };

            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            var result= validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }


          [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturunError()
        {
                UpdateAuthorCommand command=new UpdateAuthorCommand(null);
                  command.AuthorId=1;
            command.Model=new UpdateAuthorModel(){
                Name="Hilal",
                Surname="Gedik",
                Birthday=Convert.ToDateTime("01/01/2000")
            };

            UpdateAuthorCommandValidator validator=new UpdateAuthorCommandValidator();
            var result= validator.Validate(command);
            result.Errors.Count.Should().Be(0);


            
        }

    }
    
}