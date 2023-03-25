using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IMapper mapper, BookStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Name==Model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Kitap türü zaten mevcut");
            }
            genre= _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();

            //Alternatif yöntem mapleme yapmadan.
            // genre= new Genre();
            // genre.Name=Model.Name;
            // _dbContext.Genres.Add(genre);
            // _dbContext.SaveChanges();

        }
    }

    public class CreateGenreModel
    {
       
        public string Name {get; set;}
    }
}