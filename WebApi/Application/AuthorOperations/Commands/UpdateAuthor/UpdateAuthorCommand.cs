using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var author = _dbContext.Authors.Include(x=>x.Book).SingleOrDefault(x => x.Id == AuthorId);         


            if (author is null)
            {
                throw new InvalidOperationException("Yazar mevcut değil");
            }
            //author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            //author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Name = Model.Name;
            //author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            //author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.Surname = Model.Surname;
            //author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;
            author.BookId= Model.Book;
            author.Birthday=Model.Birthday;
            _dbContext.SaveChanges();

        }

    }


    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Book { get; set; }
        public DateTime Birthday { get; set; }
    }
}