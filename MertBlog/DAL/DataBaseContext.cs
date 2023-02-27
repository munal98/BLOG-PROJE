using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<User> Users { get; set; }

        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=BlogDb;trusted_connection=true; trustserverCertificate=true;multipleactiveresultsets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Name = "Admin",
                    Password = "123456",
                    UserName = "Admin",
                    Email = "admin@blog.net",
                    Phone = "1234567890",
                    SurName = "1234567890"

                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
