using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        //dependency injection containerindan geliyor.
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_mapper,_context);
            var obj = query.Handle();
            return Ok(obj);
        }


        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper,_context);
            query.GenreId=id;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public ActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_mapper,_context);
            command.Model= newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
         public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.id=id;
            command.Model=updatedGenre;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId=id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }



    }

}