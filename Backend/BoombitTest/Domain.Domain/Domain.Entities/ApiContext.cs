using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Default constructor of the
        /// context
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        /// <summary>
        /// Executing seeder in the
        /// database
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            BoomSeeder.SeedCountries(builder);
            BoomSeeder.SeedUsers(builder);
        }

        public DbSet<Country> Countries { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Activity> Activities { set; get; }
    }
}

