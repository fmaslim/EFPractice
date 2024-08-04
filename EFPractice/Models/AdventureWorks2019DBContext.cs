using Microsoft.EntityFrameworkCore;
using EFPractice.Model1;

namespace EFPractice.Models
{
    public class AdventureWorks2019DBContext :DbContext
    {
        public AdventureWorks2019DBContext(DbContextOptions<AdventureWorks2019DBContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.\\;Database=AdventureWorks2019;Trusted_Connection=true;TrustServerCertificate=true");
        }
        public DbSet<EFPractice.Model1.CustomEmployee> CustomEmployee { get; set; } = default!;
    }
}
