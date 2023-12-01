using Microsoft.EntityFrameworkCore;
using ReptileHusbandryDomain;
namespace ReptileHusbandryData
{
    public class HusbandryContext:DbContext
    {
        public DbSet<Reptile> Reptiles { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        //these tell the database what sets I would like it to have and from what class
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HusbandryDatabase"
                );
            //this is my connection string. it uses a local database so I will need to make sure I have a method to
            //initialize a database and add data to it on the reviewer's computer when they run it.
        }
    }
}
