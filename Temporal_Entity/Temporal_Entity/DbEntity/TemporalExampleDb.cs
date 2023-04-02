using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temporal_Entity.DbEntity.Entity;

namespace Temporal_Entity.DbEntity
{
    public class TemporalExampleDb : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DG1;Database=TemporalExampleDb;User Id=sa;Password=123654Dg; TrustServerCertificate=True");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post", x => x.IsTemporal());
        }


    }
}
