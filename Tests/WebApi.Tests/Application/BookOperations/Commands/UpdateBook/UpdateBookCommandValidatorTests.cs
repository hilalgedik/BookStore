using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests: IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",0,0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int genreId, int pageCount)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.id=0;
            command.Model = new UpdateBookModel()
            {
                Title = title,
                GenreId = genreId,
                PageCount = pageCount
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
            
        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
             command.Model = new UpdateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date,
                GenreId = 1
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);


        }

         [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturunError()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.id=0;
             command.Model = new UpdateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(2),
                GenreId = 1
            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0); //Equals da kullanılabilir.


        }



    }
}