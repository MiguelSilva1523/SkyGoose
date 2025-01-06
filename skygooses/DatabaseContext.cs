using Microsoft.EntityFrameworkCore;

namespace SkyGoose.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Jet> Jets { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=SkyGoose;Trusted_Connection=True;");
        }
    }

    public class Jet
    {
        public int JetID { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
    }

    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
