using Microsoft.EntityFrameworkCore;
using OnlineBookStoreWeb.Models;

namespace OnlineBookStoreWeb.Data
{
    public class ApplicationDbContext :  DbContext
        
    {// creating the constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        //telling the application that it needs to use a sq server using the connection string that we defined


    }
}
