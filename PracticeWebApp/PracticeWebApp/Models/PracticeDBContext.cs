using Microsoft.EntityFrameworkCore;

namespace PracticeWebApp.Models
{
    public class PracticeDBContext : DbContext // This class is used to interact with the database using Entity Framework Core. It represents a session with the database and allows querying and saving data
    {
       public PracticeDBContext(DbContextOptions<PracticeDBContext> options) : base(options) // This constructor initializes the DbContext with the specified options, which include the database provider and connection string
        {

        }
       public DbSet<LINQ_Employe_Model> LINQ_Employes { get; set; } // This property represents a collection of LINQ_Employe_Model entities in the database. It allows querying and saving instances of LINQ_Employe_Model}
       public DbSet<Course> courses { get; set; }
       public DbSet<Studentcs> studentcss { get; set; }

    }
}
