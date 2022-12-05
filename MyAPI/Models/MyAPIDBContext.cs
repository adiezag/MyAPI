using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyAPI.Models;
using System.Collections.Generic;

namespace MyAPI.Models
{
    public class MyAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MyAPIDBContext(DbContextOptions<MyAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("additivedatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Additive> Additive { get; set; } = null!;
        public DbSet<AdditiveType> AdditiveType { get; set; } = null!;
    }
}
