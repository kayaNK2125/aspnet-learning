using FirstMVCWebApp.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstMvcWebApp.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) //primary constructor concept
    {
        public DbSet<User> Users { get; set; }
    //   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) //constructor
    //     {
            
    //     }   
    }
}