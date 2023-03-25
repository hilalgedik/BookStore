using WebApi.DBOperations;
using System.Linq;
using System;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Model {get; set;}
        public int id {get; set;}
        private readonly BookStoreDbContext _dbContext;
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x=>x.Id==id);
            if (genre is null)
            {
                 throw new InvalidOperationException("Kitap türü mevcut değil");
            }
            if (_dbContext.Genres.Any(x=>x.Name.ToLower()==Model.Name.ToLower() && x.Id != id))
            {
                throw new InvalidOperationException("Ayni isimli Kitap türü kayitli");
            }
            //genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name ;
            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _dbContext.SaveChanges();

        }
    }
    public class UpdateGenreModel
    {
        
         public string Name { get; set; }

         public bool IsActive {get; set;}=true;
           
    }
}