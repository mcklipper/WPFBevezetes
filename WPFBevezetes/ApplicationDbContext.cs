using Microsoft.EntityFrameworkCore;
using WPFBevezetes.Models;

namespace WPFBevezetes
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; 
                Initial Catalog = turagyak; 
                Integrated Security = True;");

            base.OnConfiguring(options);
        }
    }
}
