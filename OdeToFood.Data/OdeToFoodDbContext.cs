using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {        
        public OdeToFoodDbContext(
            DbContextOptions<OdeToFoodDbContext> options)
            :base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            //options.UseSqlite("Data Source=ap.db");    

        #region Properties

        public DbSet<Restaurant> Restaurants { get; set; }
        
        #endregion
    }
}
