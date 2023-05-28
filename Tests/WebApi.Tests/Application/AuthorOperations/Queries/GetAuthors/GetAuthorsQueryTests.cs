using AutoMapper;
using TestSetup;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQueryTests: IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

         [Fact]
        public void AuthorQuantityIsItTrue()
        {
            var DbQuantity = _context.Authors.Count();
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
           var QueryQuantity = query.Handle();

             Assert.Equal(DbQuantity, QueryQuantity.Count);

        }
    }
}