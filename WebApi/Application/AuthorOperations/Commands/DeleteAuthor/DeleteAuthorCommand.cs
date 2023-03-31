using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
        //     var author = _dbContext.Authors.GroupJoin(
        // _dbContext.Books,
        // a => a.BookId,
        // b => b.Id,
        // (a, b) => new { Author = a, Books = b })
        //  .SelectMany(
        // ab => ab.Books.DefaultIfEmpty(),
        // (a, b) => new Author
        // {
        //     Id = a.Author.Id,
        //     Name = a.Author.Name,
        //     Surname = a.Author.Surname,
        //     Book = b,
        //     Birthday = a.Author.Birthday
        // }).SingleOrDefault(x => x.Id == AuthorId);
          var author = _dbContext.Authors.Include(x=>x.Book).SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Silinecek yazar Bulunamadi.");

            author = _dbContext.Authors.GroupJoin(
        _dbContext.Books,
        a => a.BookId,
        b => b.Id,
        (a, b) => new { Author = a, Books = b })
         .SelectMany(
        ab => ab.Books.DefaultIfEmpty(),
        (a, b) => new Author
        {
            Id = a.Author.Id,
            Name = a.Author.Name,
            Surname = a.Author.Surname,
            Book = b,
            Birthday = a.Author.Birthday
        }).SingleOrDefault(x => x.Id == AuthorId && x.Book != null);
        
            if (author is not null)
                throw new InvalidOperationException("Silinecek yazarin kitabi bulunduğundan silinemez.");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();

        }




    }


}