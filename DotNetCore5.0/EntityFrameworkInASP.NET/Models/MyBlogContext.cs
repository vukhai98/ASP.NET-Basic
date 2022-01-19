using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkInASP.NET.Models
{
    public class MyBlogContext : DbContext
    {
        public DbSet<Article> Articles { set; get; }
     
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            //......
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
