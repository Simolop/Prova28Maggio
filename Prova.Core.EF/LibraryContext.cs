using Microsoft.EntityFrameworkCore;
using Prova.Core.Model;
using System;

namespace Prova.Core.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        public LibraryContext() : base()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DatabaseProva;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User ID=sa;Password=Simona1996";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
        }
    }
}
