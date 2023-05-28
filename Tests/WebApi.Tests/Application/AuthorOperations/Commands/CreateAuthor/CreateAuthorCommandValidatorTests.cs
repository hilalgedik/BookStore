using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
       
       [Theory]
        [InlineData("L", "3")]
        public void WhenInvalidInputAreGivenValidatorShouldBeReturnErrors(string name, string surname)
        {
            CreateAuthorCommand command=new CreateAuthorCommand(null,null);
            command.Model=new CreateAuthorModel(){
                Name=name,
                Surname=surname
            };
            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
              var result= validator.Validate(command);
              result.Errors.Count.Should().BeGreaterThan(0);
            
            
        }

           [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
             CreateAuthorCommand command=new CreateAuthorCommand(null,null);
            command.Model=new CreateAuthorModel(){
                Name="Hilal",
                Surname="Gedik",
                Birthday=DateTime.Now
            };

            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
            var result= validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

         [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturunError()
        {
                CreateAuthorCommand command=new CreateAuthorCommand(null,null);
            command.Model=new CreateAuthorModel(){
                Name="Hilal",
                Surname="Gedik",
                Birthday=Convert.ToDateTime("01/01/2000")
            };

            CreateAuthorCommandValidator validator=new CreateAuthorCommandValidator();
            var result= validator.Validate(command);
            result.Errors.Count.Should().Be(0);


            
        }
    }
}