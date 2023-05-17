using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Queries.GetBooks;

namespace Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidatorTests: IClassFixture<CommonTestFixture>
    {
        

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            GetByIdBookQuery query = new GetByIdBookQuery(null,null);
            query.id=0;
           
            GetByIdBookQueryValidator validator = new GetByIdBookQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
            
        }

    }
}