using FluentAssertions;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using TestSetup;

namespace Application.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidatorTests: IClassFixture<CommonTestFixture>
    {
         [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId=0;
           
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
            
        }

    }
}