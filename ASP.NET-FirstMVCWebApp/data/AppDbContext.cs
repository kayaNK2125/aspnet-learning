using FirstMvcWebApp.Models;
using FirstMVCWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstMvcWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) // primary Constructor, AppDbContext is the name of the class, DbContext is the base class, options is the parameter of type DbContextOptions<AppDbContext>
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Product> Products { get; set; } // Manage Product Objects in the database, it will create a table named Products in the database, and it will have columns Id, ProductName, Description, Price, Color.
        
        //   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //constructor
        //     {
        //     }   
    }
}