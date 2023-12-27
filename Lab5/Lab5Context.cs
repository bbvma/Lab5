using Lab5;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Lab5Context : DbContext
    {
        public object options;

        public Lab5Context() { }

        public Lab5Context(object options)
        {
            this.options = options;
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source = lab5.db");
        }
    }
}

