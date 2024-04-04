using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiBooks.Repository.Models;

namespace WebApiBooks.Repository
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TabUsuario> tabUsuario { get; set; }
        public DbSet<TabLivro> tabLivro { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabUsuario");
            modelBuilder.Entity<TabLivro>().ToTable("tabLivro");


        }
    }
}