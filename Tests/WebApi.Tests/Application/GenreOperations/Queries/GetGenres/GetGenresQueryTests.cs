using AutoMapper;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQueryTests: IClassFixture<CommonTestFixture>
    {
          private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

          [Fact]
        public void GenreQuantityIsItTrue()
        {
            var amount = _context.Genres.Count();
            GetGenresQuery query = new GetGenresQuery(_mapper,_context);

            var GenreList =  query.Handle();
            Assert.Equal(amount, GenreList.Count);

        }
    }
}