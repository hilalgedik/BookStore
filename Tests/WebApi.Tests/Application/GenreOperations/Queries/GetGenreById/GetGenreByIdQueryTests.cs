using AutoMapper;
using TestSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;


namespace Application.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreByIdQueryTests(CommonTestFixture testFixture)
        {
              _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
         public void GetBookByIdMetodShouldReturnCorrectBook()
        {
            int id=1;
            GetGenreDetailQuery getGenreDetailQuery = new GetGenreDetailQuery(_mapper, _context);
            getGenreDetailQuery.GenreId=id;
            var QueryResult = getGenreDetailQuery.Handle();
 
             var DbResult=_context.Genres.SingleOrDefault(x=>x.Id==id);


         Assert.Equal(QueryResult.Id,DbResult.Id);
         Assert.Equal(QueryResult.Name,DbResult.Name);

        }




    }
}