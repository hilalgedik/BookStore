using AutoMapper;
using TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryTests: IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryTests(CommonTestFixture testFixture)
        {
             _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


         [Fact]
        public void GetAuthorByIdQueryShouldReturnCorrectBook()
        {
            var id=1;
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            var queryResult = query.Handle();

            var result=_context.Authors.SingleOrDefault(x=>x.Id==id);

               Assert.Equal(queryResult.Name, result.Name);
               Assert.Equal(queryResult.Surname, result.Surname);
               Assert.Equal(queryResult.Birthday, result.Birthday);

        }
    }
    
}