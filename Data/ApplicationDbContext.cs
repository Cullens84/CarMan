

using CarMan.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMan.Data
{
    public class ApplicationDbContext :DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Carman> Cars { get; set; } 
    }
}
