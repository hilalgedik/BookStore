
using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(query => query.id).GreaterThan(0);
        }
    }
}