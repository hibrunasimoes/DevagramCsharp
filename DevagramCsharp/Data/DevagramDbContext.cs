using System;
using DevagramCsharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace DevagramCsharp.Data
{
    public class DevagramDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DevagramDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public DbSet<XYZ> XYZs { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DEVAGRAM")
            );
        }
    }
}