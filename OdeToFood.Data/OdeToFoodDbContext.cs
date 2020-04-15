using System;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=ap.db");
    

        #region Properties

        public DbSet<Restaurant> Restaurants { get; set; }
        
        #endregion
    }
}
