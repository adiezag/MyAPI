using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyNewAPI.Models;


namespace MyNewAPI.Models
{
    public class MyNewAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MyNewAPIDBContext(DbContextOptions<MyNewAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DrillingFluidAdditives");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<TypesOfAdditive_> TypesOfAdditives { get; set; } = null!;
        public DbSet<Additive_> Additives { get; set; } = null!;
    }
}
