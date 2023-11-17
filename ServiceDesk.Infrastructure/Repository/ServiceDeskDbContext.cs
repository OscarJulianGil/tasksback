using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Models;

namespace ServiceDesk.Infrastructure.Repository
{
	public class ServiceDeskDbContext : DbContext
	{
		public ServiceDeskDbContext(DbContextOptions options): base(options)
		{

		}


        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Use Fluent Api for design the tables in the database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<Domain.Models.Task>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Domain.Models.Task>().HasOne(p => p.Category);
            modelBuilder.Entity<Domain.Models.Task>().HasOne(p => p.UserAssigned);

            modelBuilder.Entity<User>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Domain.Models.Task>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Domain.Models.Task>().Property(b => b.IsCompleted).HasDefaultValue(false);
            modelBuilder.Entity<Category>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>().Property(b => b.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Domain.Models.Task>().Property(b => b.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Category>().Property(b => b.Id).HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<User>().Property(b => b.Name).HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(b => b.Email).HasColumnType("varchar(200)");

            modelBuilder.Entity<Domain.Models.Task>().Property(b => b.TaskName).HasColumnType("varchar(200)");
            modelBuilder.Entity<Domain.Models.Task>().Property(b => b.Description).HasColumnType("varchar(500)");
        }
    }
}

