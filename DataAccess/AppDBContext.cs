using AppTest.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppTest.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)

        {
        }
        public DbSet<Folder> Folder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Folder>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Folder>()
              .Property(i => i.Id)
              .ValueGeneratedOnAdd();

            modelBuilder.Entity<Folder>()
              .Property(i => i.Name)
              .HasColumnType("nvarchar(255)");

            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 1, Name = "Creating Digital Images", ParentId = null });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 2, Name = "Resources", ParentId = 1 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 3, Name = "Evidence", ParentId = 1 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 4, Name = "Graphic Products", ParentId = 1 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 5, Name = "Primary Sources", ParentId = 2 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 6, Name = "Secondary Sources", ParentId = 2 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 7, Name = "Process", ParentId = 4 });
            modelBuilder.Entity<Folder>().HasData(new Folder { Id = 8, Name = "Final Product", ParentId = 4 });


        }
    }
}
