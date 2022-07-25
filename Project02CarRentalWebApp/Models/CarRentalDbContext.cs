using System.Data.Entity;
namespace Project02CarRentalWebApp.Models
{
    public class CarRentalDbContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public CarRentalDbContext() : base("MainDb")
        {
            Configuration.LazyLoadingEnabled = true;
        }
    }
}