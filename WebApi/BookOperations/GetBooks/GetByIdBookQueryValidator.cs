
using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetByIdBookQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(query => query.id).GreaterThan(0);
        }
    }
}