using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
                  context.Authors.AddRange(
                    new Author{
                        Name="Hakan",
                        Surname="Günday",
                        Birthday=new DateTime(1989, 8, 13),
                        BookId=0
                    },
                    new Author{
                        Name="Sinan",
                        Surname="Canan",
                        Birthday=new DateTime(1976, 8, 13)
                    },
                    new Author{
                        Name="Jojo",
                        Surname="Moyes",
                        BookId=3,
                        Birthday=new DateTime(2022, 8, 13)
                    }
                );
         }
    }
}