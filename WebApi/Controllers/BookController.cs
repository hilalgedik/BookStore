using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Addcontrollers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //     private static List<Book> BookList = new List<Book>()
        //   {
        //      new Book
        //      {
        //         Id=1,
        //         Title="Lean Startup",
        //         GenreId=1,
        //         PageCount=200,
        //         PublishDate=new DateTime(2001,6,12)
        //      },

        //       new Book
        //      {
        //         Id=2,
        //         Title="Herland",
        //         GenreId=2,
        //         PageCount=250,
        //         PublishDate=new DateTime(2010,05,23)
        //      },
        //       new Book
        //      {
        //         Id=3,
        //         Title="Dune",
        //         GenreId=2,
        //         PageCount=540,
        //         PublishDate=new DateTime(2011,12,21)
        //      }
        //   };

        [HttpGet]
        public IActionResult GetBooks()
        {
            //     var bookList = _context.Books.OrderBy(x=>x.Id).ToList<Book>();
            //    // var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            //     return bookList;
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // var book = _context.Books.Where(x => x.Id == id).SingleOrDefault();
            // //var book = BookList.Where(x => x.Id == id).SingleOrDefault();
            // return book;
            BooksByIdViewModel result;
           
                GetByIdBookQuery query = new GetByIdBookQuery(_context, _mapper);
                query.id = id;
                GetByIdBookQueryValidator validator = new GetByIdBookQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
           
            return Ok(result);


        }

        //  [HttpGet]
        //   public Book GetById([FromQuery] string id)
        //   {
        //    var book = BookList.Where(x=>x.Id== Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //   }

        //post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            // try
            // {
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                // if (!result.IsValid)
                //     foreach (var item in result.Errors)
                //         Console.WriteLine("Özellik " + item.PropertyName + " - Error Message: " + item.ErrorMessage);
                // else
                //     command.Handle();



            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            return Ok();
            // var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            // if (book is not null)
            //     return BadRequest();

            // _context.Books.Add(newBook);
            // _context.SaveChanges();
            // return Ok();
            //ctrl+k+c command satırı yapmak için.
        }

        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
           
                command.id = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            
           
            return Ok();

            // var book = _context.Books.SingleOrDefault(x => x.Id == id);
            // if (book is null)
            //     return BadRequest();
            // book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            // book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            // book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            // book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            // _context.SaveChanges();
            // return Ok();

        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // var book = _context.Books.SingleOrDefault(x => x.Id == id);
            // if (book is null)
            //     return BadRequest();
            // _context.Books.Remove(book);
            // _context.SaveChanges();
            // return Ok();

            
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            

            return Ok();


        }


    }
}
