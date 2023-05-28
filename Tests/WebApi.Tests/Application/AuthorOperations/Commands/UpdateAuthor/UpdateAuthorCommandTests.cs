using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests: IClassFixture<CommonTestFixture>
    {
         private readonly BookStoreDbContext _context;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

         [Fact]
        public void WhenAuthorIsDoesntExist_InvalidOperationException_ShouldBeReturn()
        {

             var author = new Author() {Id=100};

            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId= author.Id;
            UpdateAuthorModel model = new UpdateAuthorModel(){Name="A",Surname="B"};
            command.Model=model;

             FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar mevcut değil");

        }

    }
}