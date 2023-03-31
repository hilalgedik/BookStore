using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
            
        }
    }
}