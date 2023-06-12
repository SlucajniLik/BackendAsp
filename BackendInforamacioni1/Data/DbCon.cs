using Microsoft.EntityFrameworkCore;

namespace BackendInforamacioni1.Data
{
    public class DbCon:DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        { 
        
        
        
        }

        public DbSet<Osoba> Osoba { get; set; }





    }
}
