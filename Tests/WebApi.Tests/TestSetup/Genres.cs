using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
             context.Genres.AddRange(
                    new Genre{
                        Name="PersonalGrowth"
                    },
                    new Genre{
                        Name="ScienceFiction"
                    },
                    new Genre{
                        Name="Romance"
                    }
                );
        }

    }
}