using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreIsDoesntExist_InvalidOperationException_ShouldBeReturn()
        {
              var genre = new Genre() {Id=10000};

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.id= genre.Id;
            UpdateGenreModel model = new UpdateGenreModel(){Name="test"};
            command.Model=model;

             FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü mevcut değil");

        }
    }
}