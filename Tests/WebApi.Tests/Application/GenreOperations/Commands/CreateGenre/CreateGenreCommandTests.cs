using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre { Name = "test" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            command.Model = new CreateGenreModel() { Name = genre.Name };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kayitli yazar bir daha kayit edilemez!");
        

        }


          [Fact]

        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
              CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            CreateGenreModel model = new CreateGenreModel() { Name = "test" };
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(x => x.Name == model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);

        
        }
        
    }
}