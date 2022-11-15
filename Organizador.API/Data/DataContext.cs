using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Organizador.API.Models;

namespace Organizador.API.Data
{
    public class DataContext : DbContext
    {
        private readonly DataContext _context;

        public DataContext() {}

        public DataContext(DataContext context)
        {
            _context = context;
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("data source=localhost;Database=Organizador;User Id=sa;Password=lucas869259;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public IEnumerable<Usuario> GetUsuario()
        {
            return Usuario;
        }

        public IEnumerable<Projeto> GetProjeto()
        {
            return Projeto;
        }

        public IEnumerable<Tarefa> GetTarefa()
        {
            return Tarefa;
        }
    }
}