using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidatorTests: IClassFixture<CommonTestFixture>
    {
        
      [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
            query.AuthorId=0;
           
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
            
        }
        
    }
}


        
    
